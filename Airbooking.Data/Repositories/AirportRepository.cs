using System.Linq;
using Airbooking.Data.Infrastructure;
using Airbooking.Model;

namespace Airbooking.Data.Repositories
{
    /// <summary>
    /// Airport Repository Class
    /// </summary>
    public class AirportRepository : RepositoryBase<Airport>, IAirportRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirportRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The database factory.</param>
        public AirportRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        /// <summary>
        /// Gets the airport by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Airport</returns>
        public Airport GetAirportByCode(string code)
        {
            return DbContext.Airports.FirstOrDefault(a=>a.Code == code);
        }
    }

    /// <summary>
    /// Airport Repository Interface
    /// </summary>
    public interface IAirportRepository : IRepository<Airport>
    {
        /// <summary>
        /// Gets the airport by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        Airport GetAirportByCode(string code);
    }
}
