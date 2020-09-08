namespace Airbooking.Data.Infrastructure
{
    /// <summary>
    /// Database factory class
    /// </summary>
    /// <seealso cref="Airbooking.Data.Infrastructure.Disposable" />
    /// <seealso cref="Airbooking.Data.Infrastructure.IDbFactory" />
    public class DbFactory : Disposable, IDbFactory
    {
        AirbookingEntities _dbContext;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns></returns>
        public AirbookingEntities Init()
        {
            return _dbContext ?? (_dbContext = new AirbookingEntities());
        }

        /// <summary>
        /// Disposes the core.
        /// </summary>
        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
