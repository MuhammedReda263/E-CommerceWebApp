﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter = null, string? includeProperties = null);
        T Get(Expression<Func<T, bool>> Filter, string? includeProperties = null , bool Tracked = false);
        void Add(T entity);
        void Remove(T entity);

        void RemoveRange(IEnumerable<T> Entitys);


    }
}
