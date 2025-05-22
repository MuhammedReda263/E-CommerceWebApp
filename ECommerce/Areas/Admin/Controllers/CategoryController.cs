using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize (Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public CategoryController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>();
            categories = _UnitOfWork.Category.GetAll().ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order Cann't be exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Add(obj);
                _UnitOfWork.Save();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("index");
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            if (id != 0)
            {
                Category? CategoryFromDb = _UnitOfWork.Category.Get(item => item.Id == id);
                return View("EditCategory", CategoryFromDb);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Edit(Category EditionCategory)
        {
            if (EditionCategory.Name == EditionCategory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order Cann't be exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Update(EditionCategory);
                _UnitOfWork.Save();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("index");
            }
            return View("EditCategory", EditionCategory);
        }

        public IActionResult Delete(int id)
        {

            if (id != 0)
            {
                Category? CategoryFromDb = _UnitOfWork.Category.Get(item => item.Id == id);
                _UnitOfWork.Category.Remove(CategoryFromDb);
                _UnitOfWork.Save();
                TempData["Success"] = "Category Deleted successfully";

                return RedirectToAction("index");
            }
            return RedirectToAction("index");
        }

    }

}
