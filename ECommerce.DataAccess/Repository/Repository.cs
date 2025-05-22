using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repository
{
    public class Repository <T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _DbContext;
        internal DbSet <T> dbset; 
        public Repository(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
            dbset = _DbContext.Set<T>();
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> Filter, string? includeProperties = null , bool Tracked = false)
        {
            IQueryable<T> Query;
            if (Tracked)
            {
                Query = dbset;
            }
            else
            {
                Query = dbset.AsNoTracking();
            }
            Query = Query.Where (Filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(property);
                }
            }
            return Query.FirstOrDefault();
            
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter = null, string? includeProperties = null)
        {
            IQueryable<T> Query = dbset;
            if (Filter != null)
            {
                Query = Query.Where(Filter);
            }
            
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(property);
                }
            }
            return Query.ToList();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> Entitys)
        {
            dbset.RemoveRange (Entitys);
        }
    }
}
