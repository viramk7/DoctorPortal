using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DoctorPortal.Web.Database.Repositories
{
    public interface IDbContext
    {
        DbContextConfiguration ConfigurationVal { get; }

        System.Data.Entity.Database Db { get; }

        /// <summary>
        /// Get Database Set
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>Database Set</returns>
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// Save changes
        /// </summary>
        int SaveChanges();

        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : class;

        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        DbEntityEntry Entry(object entity);
    }
}
