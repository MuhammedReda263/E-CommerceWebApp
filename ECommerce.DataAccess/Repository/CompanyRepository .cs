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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public CompanyRepository(ApplicationDbContext DbContext) : base(DbContext) 
        {
            _DbContext = DbContext;
        }
        public void Update(Company obj)
        {
            _DbContext.Companies.Update(obj);
        }

       
    }
}
