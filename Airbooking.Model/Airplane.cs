using System.Collections.Generic;

namespace Airbooking.Model
{
    /// <summary>
    /// Airplane class
    /// </summary>
    /// <seealso cref="Airbooking.Model.BaseModel" />
    public class Airplane: BaseModel
    {
        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the seating capacity of airplane.
        /// </summary>
        /// <value>
        /// The seating capacity.
        /// </value>
        public int SeatingCapacity { get; set; }

        /// <summary>
        /// Gets or sets the image of airplane map.
        /// </summary>
        /// <value>
        /// The image of airplane map.
        /// </value>
        public string AirplaneMapImage { get; set; }

        /// <summary>
        /// Gets or sets the seats.
        /// </summary>
        /// <value>
        /// The seats.
        /// </value>
        public virtual List<Seat> Seats { get; set; }
    }
}
