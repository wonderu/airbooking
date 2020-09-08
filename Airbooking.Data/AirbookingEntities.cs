using Airbooking.Model;
using System.Data.Entity;
using Airbooking.Data.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Airbooking.Data
{
    /// <summary>
    /// Airbooking database context
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class AirbookingEntities : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirbookingEntities"/> class.
        /// </summary>
        public AirbookingEntities() : base("DefaultConnection", throwIfV1Schema: false) { }

        /// <summary>
        /// Gets or sets the airports.
        /// </summary>
        /// <value>
        /// The airports.
        /// </value>
        public virtual DbSet<Airport> Airports { get; set; }

        /// <summary>
        /// Gets or sets the airplanes.
        /// </summary>
        /// <value>
        /// The airplanes.
        /// </value>
        public virtual DbSet<Airplane> Airplanes { get; set; }

        /// <summary>
        /// Gets or sets the tickets.
        /// </summary>
        /// <value>
        /// The tickets.
        /// </value>
        public virtual DbSet<Ticket> Tickets { get; set; }

        /// <summary>
        /// Gets or sets the bookings.
        /// </summary>
        /// <value>
        /// The bookings.
        /// </value>
        public virtual DbSet<Booking> Bookings { get; set; }

        /// <summary>
        /// Gets or sets the passengers.
        /// </summary>
        /// <value>
        /// The passengers.
        /// </value>
        public virtual DbSet<Passenger> Passengers { get; set; }

        /// <summary>
        /// Gets or sets the flights.
        /// </summary>
        /// <value>
        /// The flights.
        /// </value>
        public virtual DbSet<Flight> Flights { get; set; }

        /// <summary>
        /// Gets or sets the seats.
        /// </summary>
        /// <value>
        /// The seats.
        /// </value>
        public virtual DbSet<Seat> Seats { get; set; }

        /// <summary>
        /// Gets or sets the flight schedules.
        /// </summary>
        /// <value>
        /// The flight schedules.
        /// </value>
        public virtual DbSet<FlightSchedule> FlightSchedules { get; set; }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public static AirbookingEntities Create()
        {
            return new AirbookingEntities();
        }

        /// <summary>
        /// Commits the changes.
        /// </summary>
        public virtual void Commit()
        {
            SaveChanges();
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new BookingConfiguration());
            //modelBuilder.Configurations.Add(new TicketConfiguration());

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
