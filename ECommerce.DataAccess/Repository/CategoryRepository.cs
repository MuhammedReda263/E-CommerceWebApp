using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public CategoryRepository(ApplicationDbContext DbContext) : base(DbContext) 
        {
            _DbContext = DbContext;
        }
        public void Update(Category obj)
        {
            _DbContext.Categories.Update(obj);
        }

       
    }
}
