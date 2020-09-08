using System.Collections.Generic;

namespace Airbooking.Model
{
    /// <summary>
    /// Airport class
    /// </summary>
    /// <seealso cref="Airbooking.Model.BaseModel" />
    public class Airport : BaseModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the time zone.
        /// </summary>
        /// <value>
        /// The time zone.
        /// </value>
        public int TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the flight infos.
        /// </summary>
        /// <value>
        /// The flight infos.
        /// </value>
        public virtual List<FlightInfo> FlightInfos { get; set; }
    }
}
