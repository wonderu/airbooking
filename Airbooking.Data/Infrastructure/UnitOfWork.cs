using System;

namespace Airbooking.Data.Infrastructure
{
    /// <summary>
    /// Unit of work
    /// </summary>
    /// <seealso cref="Airbooking.Data.Infrastructure.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private AirbookingEntities _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="dbFactory">The database factory interface.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public UnitOfWork(IDbFactory dbFactory)
        {
            if (dbFactory == null)
                throw new ArgumentNullException(nameof(dbFactory));

            _dbFactory = dbFactory;
        }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        public AirbookingEntities DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());

        /// <summary>
        /// Commits the changes.
        /// </summary>
        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
