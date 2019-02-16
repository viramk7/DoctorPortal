using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DoctorPortal.Web.AdminServices.Entity
{
    public interface IEntityService<T>
    {
        T GetById(object id);

        IQueryable<T> GetAll();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Insert(T entity);

        void Insert(IEnumerable<T> entities);

        void Update(T entity);

        void Update(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : class;
        
    }
}
