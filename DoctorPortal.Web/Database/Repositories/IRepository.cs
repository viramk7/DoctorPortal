using DoctorPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DoctorPortal.Web.Database.Repositories
{
    public partial interface IRepository<T> where T : class
    {
        T GetById(object id);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Insert(T entity);

        void Insert(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        IQueryable<T> Table { get; }

        IQueryable<T> TableNoTracking { get; }
    }
}
