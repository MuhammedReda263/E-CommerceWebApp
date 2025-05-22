using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace ECommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         private readonly IUnitOfWork _unitOfWork;


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(products);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                Product = _unitOfWork.Product.Get(i => i.Id == id, includeProperties: "Category"),
                ProductId = id,
                Count = 1
            };
            
            return View(shoppingCart);
        }

          [HttpPost]
          [Authorize]
          public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId= userId;
            ShoppingCart shoppingCartfromDb = _unitOfWork.ShoppingCart.Get(i => i.ApplicationUserId == userId && i.ProductId == shoppingCart.ProductId);
            if (shoppingCartfromDb != null)
            {
                shoppingCartfromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(shoppingCartfromDb);
            }
            else
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            }
            TempData["Success"] = "Cart Updated Successfully";
         
            _unitOfWork.Save();
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
