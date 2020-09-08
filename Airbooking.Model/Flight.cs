using System.Collections.Generic;

namespace Airbooking.Model
{
    /// <summary>
    /// Flight class
    /// </summary>
    /// <seealso cref="Airbooking.Model.BaseModel" />
    public class Flight: BaseModel
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the departure information.
        /// </summary>
        /// <value>
        /// The departure information.
        /// </value>
        public FlightInfo DepartureInfo { get; set; }

        /// <summary>
        /// Gets or sets the arrival information.
        /// </summary>
        /// <value>
        /// The arrival information.
        /// </value>
        public FlightInfo ArrivalInfo { get; set; }

        /// <summary>
        /// Gets or sets the flight schedules.
        /// </summary>
        /// <value>
        /// The flight schedules.
        /// </value>
        public virtual List<FlightSchedule> FlightSchedules { get; set; }
    }
}
