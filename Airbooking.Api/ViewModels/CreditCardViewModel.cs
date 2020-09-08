using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airbooking.Api.ViewModels
{
    /// <summary>
    /// Credit Card ViewModel Class
    /// </summary>
    public class CreditCardViewModel
    {
        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>
        /// The card number.
        /// </value>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the card holder.
        /// </summary>
        /// <value>
        /// The card holder.
        /// </value>
        public string CardHolder { get; set; }

        /// <summary>
        /// Gets or sets the expiry month.
        /// </summary>
        /// <value>
        /// The expiry month.
        /// </value>
        public int ExpiryMonth { get; set; }

        /// <summary>
        /// Gets or sets the expiry year.
        /// </summary>
        /// <value>
        /// The expiry year.
        /// </value>
        public int ExpiryYear { get; set; }

        /// <summary>
        /// Secret code CVC.
        /// </summary>
        /// <value>
        /// The CVC.
        /// </value>
        public int SecretCode { get; set; }
    }
}