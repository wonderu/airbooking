using System;

namespace Airbooking.Data.Infrastructure
{
    /// <summary>
    /// Database factory interface
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IDbFactory : IDisposable
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns></returns>
        AirbookingEntities Init();
    }
}
