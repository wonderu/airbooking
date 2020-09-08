namespace Airbooking.Model
{
    /// <summary>
    /// Airplane seat class
    /// </summary>
    /// <seealso cref="Airbooking.Model.BaseModel" />
    public class Seat: BaseModel
    {
        /// <summary>
        /// Gets or sets the airplane.
        /// </summary>
        /// <value>
        /// The airplane.
        /// </value>
        public Airplane Airplane { get; set; }

        /// <summary>
        /// Gets or sets the seating number.
        /// </summary>
        /// <value>
        /// The seating number.
        /// </value>
        public string SeatingNumber { get; set; }

        /// <summary>
        /// X coordinate on airplane map.
        /// </summary>
        /// <value>
        /// X coordinate on airplane map.
        /// </value>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate on airplane map.
        /// </summary>
        /// <value>
        /// Y coordinate on airplane map.
        /// </value>
        public int Y { get; set; }
    }
}
