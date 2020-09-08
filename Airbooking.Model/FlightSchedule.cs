using System;
using System.Collections.Generic;

namespace Airbooking.Model
{
    /// <summary>
    /// Flight schedule class
    /// </summary>
    /// <seealso cref="Airbooking.Model.BaseModel" />
    public class FlightSchedule:BaseModel
    {
        /// <summary>
        /// Gets or sets the airplane.
        /// </summary>
        /// <value>
        /// The airplane.
        /// </value>
        public Airplane Airplane { get; set; }

        /// <summary>
        /// Gets or sets the flight.
        /// </summary>
        /// <value>
        /// The flight.
        /// </value>
        public Flight Flight { get; set; }

        /// <summary>
        /// Gets or sets the departure date.
        /// </summary>
        /// <value>
        /// The departure date.
        /// </value>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the tickets.
        /// </summary>
        /// <value>
        /// The tickets.
        /// </value>
        public virtual List<Ticket> Tickets { get; set; }
    }
}
