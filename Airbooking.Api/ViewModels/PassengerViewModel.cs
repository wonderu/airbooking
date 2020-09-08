using System;

namespace Airbooking.Api.ViewModels
{
    /// <summary>
    /// Passenger ViewModel Class
    /// </summary>
    public class PassengerViewModel
    {
        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the passport number.
        /// </summary>
        /// <value>
        /// The passport number.
        /// </value>
        public string PassportNumber { get; set; }

        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        /// <value>
        /// The sex.
        /// </value>
        public int Sex { get; set; }
    }
}