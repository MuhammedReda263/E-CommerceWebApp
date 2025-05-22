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
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CompanyController(IUnitOfWork UnitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _UnitOfWork = UnitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Company> categories = new List<Company>();
            categories = _UnitOfWork.Company.GetAll().ToList();
            return View(categories);
        }
        public IActionResult Upsert(int? id)
        {

      
            if (id == 0 || id == null)
            {
                return View("Upsert", new Company());
            }
            else
            {
                Company company = new Company();
                company = _UnitOfWork.Company.Get(u => u.Id == id);
                return View("Upsert", company);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Company Companyobj)
        {

            if (ModelState.IsValid)
            {
               

                if (Companyobj.Id == 0)
                {
                    _UnitOfWork.Company.Add(Companyobj);
                }
                else
                {
                    _UnitOfWork.Company.Update(Companyobj);
                }

                _UnitOfWork.Save();
                TempData["Success"] = "Company Created Successfully";
                return RedirectToAction("index");
            }
           
            return View(Companyobj);
        }


        //public IActionResult Delete(int id)
        //{

        //    if (id != 0)
        //    {
        //        Company? CompanyFromDb = _UnitOfWork.Company.Get(item => item.Id == id);
        //        _UnitOfWork.Company.Remove(CompanyFromDb);
        //        _UnitOfWork.Save();
        //        TempData["Success"] = "Company Deleted successfully";

        //        return RedirectToAction("index");
        //    }
        //    return RedirectToAction("index");
        //}


        // Api Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> categories = _UnitOfWork.Company.GetAll().ToList();
            return Json( new { data = categories });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var companyFromDb = _UnitOfWork.Company.Get(p => p.Id == id);
            if (companyFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _UnitOfWork.Company.Remove(companyFromDb);
            _UnitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }

    }

}
