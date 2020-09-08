namespace Airbooking.Model
{
    /// <summary>
    /// Ticket class
    /// </summary>
    /// <seealso cref="Airbooking.Model.BaseModel" />
    public class Ticket:BaseModel
    {
        /// <summary>
        /// Gets or sets the booking identifier.
        /// </summary>
        /// <value>
        /// The booking identifier.
        /// </value>
        public int BookingId { get; set; }

        /// <summary>
        /// Gets or sets the booking.
        /// </summary>
        /// <value>
        /// The booking.
        /// </value>
        public Booking Booking { get; set; }

        /// <summary>
        /// Gets or sets the flight schedule identifier.
        /// </summary>
        /// <value>
        /// The flight schedule identifier.
        /// </value>
        public int FlightScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the flight schedule.
        /// </summary>
        /// <value>
        /// The flight schedule.
        /// </value>
        public FlightSchedule FlightSchedule { get; set; }

        /// <summary>
        /// Gets or sets the passenger.
        /// </summary>
        /// <value>
        /// The passenger.
        /// </value>
        public Passenger Passenger { get; set; }

        /// <summary>
        /// Gets or sets the seat.
        /// </summary>
        /// <value>
        /// The seat.
        /// </value>
        public Seat Seat { get; set; }

        /// <summary>
        /// Gets or sets the electronic ticket number.
        /// </summary>
        /// <value>
        /// The electronic ticket number.
        /// </value>
        public string ElectronicTicketNumber { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public int Status { get; set; } 
    }
}