using System;
using System.Collections.Generic;
using Airbooking.Model;
using Airbooking.Data.Infrastructure;
using Airbooking.Data.Repositories;

namespace Airbooking.Service
{
    /// <summary>
    /// Airport Service Class
    /// </summary>
    /// <seealso cref="Airbooking.Service.IAirportService" />
    public class AirportService: IAirportService
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirportService" /> class.
        /// </summary>
        /// <param name="airportRepository">The airport repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public AirportService(IAirportRepository airportRepository, IUnitOfWork unitOfWork)
        {
            if (airportRepository == null)
                throw new ArgumentNullException(nameof(airportRepository));

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _airportRepository = airportRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all airports.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Airport> GetAllAirports()
        {
            return _airportRepository.GetAll();
        }

        /// <summary>
        /// Gets the airport by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public Airport GetAirportByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException(nameof(code));

            return _airportRepository.GetAirportByCode(code);
        }

        /// <summary>
        /// Saves the airport.
        /// </summary>
        public void SaveAirport()
        {
            _unitOfWork.Commit();
        }
    }

    /// <summary>
    /// Airport Service Interface
    /// </summary>
    public interface IAirportService
    {
        /// <summary>
        /// Gets all airports.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Airport> GetAllAirports();

        /// <summary>
        /// Gets the airport by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        Airport GetAirportByCode(string code);

        /// <summary>
        /// Saves the airport.
        /// </summary>
        void SaveAirport();
    }
}
