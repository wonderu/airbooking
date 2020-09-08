using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Airbooking.Data.Infrastructure
{
    /// <summary>
    /// Repository base
    /// </summary>
    /// <typeparam name="T">Entity class</typeparam>
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private AirbookingEntities _dataContext;
        private readonly IDbSet<T> _dbSet;

        /// <summary>
        /// Gets the database factory.
        /// </summary>
        /// <value>
        /// The database factory.
        /// </value>
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        protected AirbookingEntities DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}" /> class.
        /// </summary>
        /// <param name="dbFactory">The database factory.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        protected RepositoryBase(IDbFactory dbFactory)
        {
            if (dbFactory == null)
                throw new ArgumentNullException(nameof(dbFactory));

            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        #region Implementation
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Deletes according the specified expression.
        /// </summary>
        /// <param name="where">The expression.</param>
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where(where).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// Gets the many entities.
        /// </summary>
        /// <param name="where">The expression.</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        /// <summary>
        /// Gets the entity according specified expression.
        /// </summary>
        /// <param name="where">The expression.</param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        #endregion

    }
}
