using System.Collections.Generic;

namespace Airbooking.Api.ViewModels
{
    /// <summary>
    /// Flight Search Response
    /// </summary>
    public class FlightSearchResponse
    {
        /// <summary>
        /// Gets or sets the outbound flights.
        /// </summary>
        /// <value>
        /// The outbound flights.
        /// </value>
        public IEnumerable<FlightScheduleViewModel> OutboundFlights { get; set; }

        /// <summary>
        /// Gets or sets the return flights.
        /// </summary>
        /// <value>
        /// The return flights.
        /// </value>
        public IEnumerable<FlightScheduleViewModel> ReturnFlights { get; set; }
    }
}