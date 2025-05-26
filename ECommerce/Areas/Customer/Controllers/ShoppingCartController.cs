using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
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
                shoppingCartVM.OrderTotal += (item.Price*item.Count);
            }

            return View(shoppingCartVM);
        }

        public IActionResult plus(int cartid)
        {
            var shoppingcart = _UnitOfWork.ShoppingCart.Get(x=> x.Id == cartid);
            shoppingcart.Count++;
            _UnitOfWork.ShoppingCart.Update(shoppingcart);
            _UnitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult minus(int cartid)
        {
            var shoppingcart = _UnitOfWork.ShoppingCart.Get(x=> x.Id == cartid);
            if (shoppingcart.Count <= 0)
            {
                _UnitOfWork.ShoppingCart.Remove(shoppingcart);
            }
            else
            {
                shoppingcart.Count--;
                _UnitOfWork.ShoppingCart.Update(shoppingcart);
            }
            
            _UnitOfWork.Save();
            return RedirectToAction(nameof(Index));
        } 
        
        public IActionResult remove(int cartid)
        {
            var shoppingcart = _UnitOfWork.ShoppingCart.Get(x=> x.Id == cartid);
            _UnitOfWork.ShoppingCart.Remove(shoppingcart);
            _UnitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult summary(int cartid)
        {
            return View("summary");
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
