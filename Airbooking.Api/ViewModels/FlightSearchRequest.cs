using System;

namespace Airbooking.Api.ViewModels
{
    /// <summary>
    /// Flight Search Request Class
    /// </summary>
    public class FlightSearchRequest
    {
        /// <summary>
        /// Gets or sets from airport code.
        /// </summary>
        /// <value>
        /// From airport code.
        /// </value>
        public string FromAirportCode { get; set; }

        /// <summary>
        /// Gets or sets to airport code.
        /// </summary>
        /// <value>
        /// To airport code.
        /// </value>
        public string ToAirportCode { get; set; }

        /// <summary>
        /// Gets or sets the start date time.
        /// </summary>
        /// <value>
        /// The start date time.
        /// </value>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Gets or sets the end date time.
        /// </summary>
        /// <value>
        /// The end date time.
        /// </value>
        public DateTime? EndDateTime { get; set; }

        /// <summary>
        /// Gets or sets the adult count.
        /// </summary>
        /// <value>
        /// The adult count.
        /// </value>
        public int AdultCount { get; set; }

        /// <summary>
        /// Gets or sets the infant count.
        /// </summary>
        /// <value>
        /// The infant count.
        /// </value>
        public int InfantCount { get; set; }

        /// <summary>
        /// Gets or sets the children count.
        /// </summary>
        /// <value>
        /// The children count.
        /// </value>
        public int ChildrenCount { get; set; }
    }
}