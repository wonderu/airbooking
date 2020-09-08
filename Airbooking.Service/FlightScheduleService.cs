using System;
using System.Collections.Generic;
using Airbooking.Data.Infrastructure;
using Airbooking.Data.Repositories;
using Airbooking.Model;

namespace Airbooking.Service
{
    /// <summary>
    /// Flight Schedule Service Class
    /// </summary>
    /// <seealso cref="Airbooking.Service.IFlightScheduleService" />
    public class FlightScheduleService: IFlightScheduleService
    {
        private readonly IFlightScheduleRepository _flightScheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightScheduleService" /> class.
        /// </summary>
        /// <param name="flightScheduleRepository">The flight schedule repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public FlightScheduleService(IFlightScheduleRepository flightScheduleRepository, IUnitOfWork unitOfWork)
        {
            if (flightScheduleRepository == null)
                throw new ArgumentNullException(nameof(flightScheduleRepository));

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _flightScheduleRepository = flightScheduleRepository;
            _unitOfWork = unitOfWork;
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
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Date should be greater than today
        /// or
        /// Adults count should be in [1, 5]
        /// or
        /// Infants count should be in [0, 5]
        /// or
        /// Children count should be in [0, 5]
        /// </exception>
        public IEnumerable<FlightSchedule> GetFlightSchedules(string fromAirportCode, string toAirportCode, DateTime date,
            int adultCount, int infantCount, int childrenCount)
        {
            if (string.IsNullOrEmpty(toAirportCode))
                throw new ArgumentNullException(nameof(toAirportCode));

            if (string.IsNullOrEmpty(fromAirportCode))
                throw new ArgumentNullException(nameof(fromAirportCode));

            //if (date <DateTime.Now)
            //    throw new ArgumentOutOfRangeException(nameof(date), "Date should be greater than today");

            if (adultCount < 1 || adultCount > 5)
                throw new ArgumentOutOfRangeException(nameof(adultCount), "Adults count should be in [1, 5]");

            if (infantCount < 0 || infantCount > 5)
                throw new ArgumentOutOfRangeException(nameof(infantCount), "Infants count should be in [0, 5]");

            if (childrenCount < 0 || childrenCount > 5)
                throw new ArgumentOutOfRangeException(nameof(childrenCount), "Children count should be in [0, 5]");

            return _flightScheduleRepository.GetFlightSchedules(fromAirportCode, toAirportCode, date, adultCount, infantCount, childrenCount);
        }

        /// <summary>
        /// Saves the flight schedule.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void SaveFlightSchedule()
        {
            _unitOfWork.Commit();
        }
    }

    /// <summary>
    /// Flight Schedule Service Interface
    /// </summary>
    public interface IFlightScheduleService
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

        /// <summary>
        /// Saves the flight schedule.
        /// </summary>
        void SaveFlightSchedule();
    }
}
