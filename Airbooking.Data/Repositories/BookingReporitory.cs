using System;
using System.Data.Entity;
using System.Linq;
using Airbooking.Data.Infrastructure;
using Airbooking.Model;

namespace Airbooking.Data.Repositories
{
    /// <summary>
    /// Booking Repository Class
    /// </summary>
    public class BookingRepository:RepositoryBase<Booking>, IBookingRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The database factory.</param>
        public BookingRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns></returns>
        public override Booking GetById(int id)
        {
            return DbContext.Bookings
                .Include(b => b.Tickets.Select(t => t.Passenger))
                .Include(b => b.Tickets.Select(t => t.FlightSchedule))
                .Include(b => b.Tickets.Select(t => t.FlightSchedule.Flight))
                .Include(b => b.Tickets.Select(t => t.FlightSchedule.Airplane))
                .Include(b => b.Tickets.Select(t => t.FlightSchedule.Flight.DepartureInfo))
                .Include(b => b.Tickets.Select(t => t.FlightSchedule.Flight.DepartureInfo.Airport))
                .Include(b => b.Tickets.Select(t => t.FlightSchedule.Flight.ArrivalInfo))
                .Include(b => b.Tickets.Select(t => t.FlightSchedule.Flight.ArrivalInfo.Airport))
                .FirstOrDefault(b=>b.Id == id);
        }

        /// <summary>
        /// Adds the booking and commits.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public int AddBookingAndCommit(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));

            DbContext.Bookings.Add(booking);
            DbContext.Commit();
            return booking.Id;
        }
    }

    /// <summary>
    /// Booking Reporitory Interface
    /// </summary>
    public interface IBookingRepository:IRepository<Booking>
    {
        /// <summary>
        /// Adds the booking and commits.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns></returns>
        int AddBookingAndCommit(Booking booking);
    }
}
