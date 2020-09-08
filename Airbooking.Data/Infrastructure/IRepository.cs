using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Airbooking.Data.Infrastructure
{
    /// <summary>
    /// Repository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Adds the specified entity. Marks an entity as new
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);

        /// <summary>
        /// Updates the specified entity. Marks an entity as modified
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes the specified entity. Marks an entity to be removed
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Deletes according to the specified expression.
        /// </summary>
        /// <param name="where">The expression.</param>
        void Delete(Expression<Func<T, bool>> where);

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity</returns>
        T GetById(int id);

        /// <summary>
        /// Gets an entity using delegate.
        /// </summary>
        /// <param name="where">The expression.</param>
        /// <returns>The entity</returns>
        T Get(Expression<Func<T, bool>> where);


        /// <summary>
        /// Gets all entities of type T.
        /// </summary>
        /// <returns>The list of entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets entities using delegate.
        /// </summary>
        /// <param name="where">The expression.</param>
        /// <returns>The list of entities</returns>
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
