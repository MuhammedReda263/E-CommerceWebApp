using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public ShoppingCartRepository(ApplicationDbContext DbContext) : base(DbContext) 
        {
            _DbContext = DbContext;
        }
        public void Update(ShoppingCart obj)
        {
            _DbContext.ShoppingCarts.Update(obj);
        }

       
    }
}
