using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DoctorPortal.Web.Database.Repositories;

namespace DoctorPortal.Web.AdminServices.Entity
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        protected readonly IRepository<T> _repository;

        public EntityService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IQueryable<T> GetAll()
        {
            return _repository.Table;
        }

        public T GetById(object id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public void Insert(T entity)
        {
            _repository.Insert(entity);
        }

        public void Insert(IEnumerable<T> entities)
        {
            _repository.Insert(entities);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            _repository.Update(entities);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _repository.Delete(entities);
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
            where TEntity : class
        {
            return _repository.ExecuteStoredProcedureList<TEntity>(commandText, parameters);
        }
        
    }
}