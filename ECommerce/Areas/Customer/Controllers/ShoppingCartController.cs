using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        IUnitOfWork _UnitOfWork { get; set; }
        IEnumerable<ShoppingCart> shoppingCarts { get; set; }
        public ShoppingCartController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCarts = _UnitOfWork.ShoppingCart.GetAll(i=>i.ApplicationUserId==userId,includeProperties: "Product");
            ShoppingCartVM shoppingCartVM = new ShoppingCartVM()
            {
                shoppingCartList = shoppingCarts,
            };
            foreach (var item in shoppingCartVM.shoppingCartList)
            {
                item.Price = GetPriceBasedOnQuantity(item);
                shoppingCartVM.OrderTotal =+ (item.Price*item.Count);
            }

            return View(shoppingCartVM);
        }
        private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Count <= 50)
            {
                return shoppingCart.Product.Price;
            }
            else if (shoppingCart.Count <= 100)
            {
                return shoppingCart.Product.Price50;
            }
            else
            {
                return shoppingCart.Product.Price100;
            }
        }
    }
}
