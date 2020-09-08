using System;

namespace Airbooking.Model
{
    /// <summary>
    /// Flight info class
    /// </summary>
    /// <seealso cref="Airbooking.Model.BaseModel" />
    public class FlightInfo:BaseModel
    {
        /// <summary>
        /// Gets or sets the airport.
        /// </summary>
        /// <value>
        /// The airport.
        /// </value>
        public Airport Airport { get; set; }

        /// <summary>
        /// Gets or sets the gate.
        /// </summary>
        /// <value>
        /// The gate.
        /// </value>
        public string Gate { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public TimeSpan Time { get; set; }
    }
}
