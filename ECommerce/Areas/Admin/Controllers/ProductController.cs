using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using ECommerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork UnitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _UnitOfWork = UnitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> categories = new List<Product>();
            categories = _UnitOfWork.Product.GetAll(includeProperties : "Category").ToList();
            return View(categories);
        }
        public IActionResult Upsert(int? id)
        {

            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                selectList = _UnitOfWork.Category
                .GetAll().Select(u => new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.Id.ToString()

                })

            };
            if (id == 0 || id == null)
            {
                return View("Upsert", productVM);
            }
            else
            {
                productVM.Product = new Product();
                productVM.Product = _UnitOfWork.Product.Get(u => u.Id == id);
                return View("Upsert", productVM);
            }

        }
        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!string.IsNullOrEmpty(obj.Product.ImageUrl))
                    {
                        //Delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.Product.ImageUrl = @"\images\product\" + fileName;
                }

                if (obj.Product.Id == 0)
                {
                    _UnitOfWork.Product.Add(obj.Product);
                }
                else
                {
                    _UnitOfWork.Product.Update(obj.Product);
                }

                _UnitOfWork.Save();
                TempData["Success"] = "Product Created Successfully";
                return RedirectToAction("index");
            }
            obj.selectList = _UnitOfWork.Category
                .GetAll().Select(u => new SelectListItem()
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            return View(obj);
        }


        //public IActionResult Delete(int id)
        //{

        //    if (id != 0)
        //    {
        //        Product? ProductFromDb = _UnitOfWork.Product.Get(item => item.Id == id);
        //        _UnitOfWork.Product.Remove(ProductFromDb);
        //        _UnitOfWork.Save();
        //        TempData["Success"] = "Product Deleted successfully";

        //        return RedirectToAction("index");
        //    }
        //    return RedirectToAction("index");
        //}


        // Api Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> categories = _UnitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json( new { data = categories });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var productFromDb = _UnitOfWork.Product.Get(p => p.Id == id);
            if (productFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var OldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productFromDb.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(OldImagePath))
            {
                System.IO.File.Delete(OldImagePath);
            }
            _UnitOfWork.Product.Remove(productFromDb);
            _UnitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }

    }

}
