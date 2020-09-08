using System.Collections.Generic;

namespace Airbooking.Api.ViewModels
{
    /// <summary>
    /// Booking ViewModel Class
    /// </summary>
    public class BookingViewModel
    {
        /// <summary>
        /// Gets or sets the outbound flight schedule identifier.
        /// </summary>
        /// <value>
        /// The outbound flight schedule identifier.
        /// </value>
        public int OutboundFlightScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the return flight schedule identifier.
        /// </summary>
        /// <value>
        /// The return flight schedule identifier.
        /// </value>
        public int? ReturnFlightScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the passengers.
        /// </summary>
        /// <value>
        /// The passengers.
        /// </value>
        public IEnumerable<PassengerViewModel> Passengers { get; set; }

        /// <summary>
        /// Gets or sets the credit card.
        /// </summary>
        /// <value>
        /// The credit card.
        /// </value>
        public CreditCardViewModel CreditCard { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }
    }
}