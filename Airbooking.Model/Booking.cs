using System;
using System.Collections.Generic;

namespace Airbooking.Model
{
    /// <summary>
    /// Booking class
    /// </summary>
    /// <seealso cref="Airbooking.Model.BaseModel" />
    public class Booking: BaseModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string ApplicationUserId { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// The PNR/booking number
        /// </summary>
        /// <value>
        /// The PNR.
        /// </value>
        public string Pnr { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the payment.
        /// </summary>
        /// <value>
        /// The payment.
        /// </value>
        public decimal Payment { get; set; }

        /// <summary>
        /// Gets or sets the payment date time.
        /// </summary>
        /// <value>
        /// The payment date time.
        /// </value>
        public DateTime PaymentDateTime { get; set; }

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
