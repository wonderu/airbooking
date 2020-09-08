using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Airbooking.Data.Infrastructure;
using Airbooking.Model;

namespace Airbooking.Data.Repositories
{
    /// <summary>
    /// Flight Schedule Repository class
    /// </summary>
    public class FlightScheduleRepository : RepositoryBase<FlightSchedule>, IFlightScheduleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlightScheduleRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The database factory.</param>
        public FlightScheduleRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        /// <summary>
        /// Gets the flight schedules.
        /// </summary>
        /// <param name="fromAirportCode">From airport code.</param>
        /// <param name="toAirportCode">To airport code.</param>
        /// <param name="date">The date.</param>
        /// <param name="adultCount">The adult count.</param>
        /// <param name="infantCount">The infant count.</param>
        /// <param name="childrenCount">The children count.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Date should be greater than today
        /// or
        /// Adults count should be in [1, 5]
        /// or
        /// Infants count should be in [0, 5]
        /// or
        /// Children count should be in [0, 5]</exception>
        public IEnumerable<FlightSchedule> GetFlightSchedules(string fromAirportCode, string toAirportCode, DateTime date,
            int adultCount, int infantCount, int childrenCount)
        {
            if (string.IsNullOrEmpty(toAirportCode))
                throw new ArgumentNullException(nameof(toAirportCode));

            if (string.IsNullOrEmpty(fromAirportCode))
                throw new ArgumentNullException(nameof(fromAirportCode));

           // if (date < DateTime.Now)
          //      throw new ArgumentOutOfRangeException(nameof(date), "Date should be greater than today");

            if (adultCount < 1 || adultCount > 5)
                throw new ArgumentOutOfRangeException(nameof(adultCount), "Adults count should be in [1, 5]");

            if (infantCount < 0 || infantCount > 5)
                throw new ArgumentOutOfRangeException(nameof(infantCount), "Infants count should be in [0, 5]");

            if (childrenCount < 0 || childrenCount > 5)
                throw new ArgumentOutOfRangeException(nameof(childrenCount), "Children count should be in [0, 5]");

            return DbContext.FlightSchedules
                .Include(fs=>fs.Airplane)
                .Include(fs => fs.Flight)
                .Include(fs => fs.Flight.DepartureInfo)
                .Include(fs => fs.Flight.DepartureInfo.Airport)
                .Include(fs => fs.Flight.ArrivalInfo)
                .Include(fs => fs.Flight.ArrivalInfo.Airport)
                .Where(fs=>fs.DepartureDate == date.Date
                & fs.Flight.DepartureInfo.Airport.Code == fromAirportCode
                & fs.Flight.ArrivalInfo.Airport.Code == toAirportCode)
                .OrderBy(fs=>fs.Flight.DepartureInfo.Time)
                .Take(50);
        }
    }

    /// <summary>
    /// Flight Schedule Repository interface
    /// </summary>
    public interface IFlightScheduleRepository : IRepository<FlightSchedule>
    {
        /// <summary>
        /// Gets the flight schedules.
        /// </summary>
        /// <param name="fromAirportCode">From airport code.</param>
        /// <param name="toAirportCode">To airport code.</param>
        /// <param name="date">The date.</param>
        /// <param name="adultCount">The adult count.</param>
        /// <param name="infantCount">The infant count.</param>
        /// <param name="childrenCount">The children count.</param>
        /// <returns></returns>
        IEnumerable<FlightSchedule> GetFlightSchedules(string fromAirportCode, string toAirportCode, DateTime date, int adultCount, int infantCount, int childrenCount);
    }
}
