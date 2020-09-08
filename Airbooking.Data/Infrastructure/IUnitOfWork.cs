namespace Airbooking.Data.Infrastructure
{
    /// <summary>
    /// Unit of work interface
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits the changes.
        /// </summary>
        void Commit();
    }
}
