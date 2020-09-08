using System;

namespace Airbooking.Api.ViewModels
{
    /// <summary>
    /// Flight Schedule View Model class
    /// </summary>
    public class FlightScheduleViewModel
    {
        /// <summary>
        /// Gets or sets the flight schedule identifier.
        /// </summary>
        /// <value>
        /// The flight schedule identifier.
        /// </value>
        public int FlightScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the flight code.
        /// </summary>
        /// <value>
        /// The flight code.
        /// </value>
        public string FlightCode { get; set; }

        /// <summary>
        /// Gets or sets the flight duration in minutes.
        /// </summary>
        /// <value>
        /// The flight duration in minutes.
        /// </value>
        public int FlightDurationInMinutes
        {
            get
            {
                return Convert.ToInt32((ArrivalTime - DepartureTime).TotalMinutes);
            }
        }

        /// <summary>
        /// Gets or sets the departure date.
        /// </summary>
        /// <value>
        /// The departure date.
        /// </value>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Gets or sets the airplane model.
        /// </summary>
        /// <value>
        /// The airplane model.
        /// </value>
        public string AirplaneModel { get; set; }

        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        /// <value>
        /// The departure time.
        /// </value>
        public TimeSpan DepartureTime { get; set; }

        /// <summary>
        /// Gets or sets the name of the departure airport.
        /// </summary>
        /// <value>
        /// The name of the departure airport.
        /// </value>
        public string DepartureAirportName { get; set; }

        /// <summary>
        /// Gets or sets the departure airport code.
        /// </summary>
        /// <value>
        /// The departure airport code.
        /// </value>
        public string DepartureAirportCode { get; set; }

        /// <summary>
        /// Gets or sets the departure airport city.
        /// </summary>
        /// <value>
        /// The departure airport city.
        /// </value>
        public string DepartureAirportCity { get; set; }

        /// <summary>
        /// Gets or sets the departure airport gate.
        /// </summary>
        /// <value>
        /// The departure airport gate.
        /// </value>
        public string DepartureAirportGate { get; set; }

        /// <summary>
        /// Gets or sets the arrival time.
        /// </summary>
        /// <value>
        /// The arrival time.
        /// </value>
        public TimeSpan ArrivalTime { get; set; }

        /// <summary>
        /// Gets or sets the name of the arrival airport.
        /// </summary>
        /// <value>
        /// The name of the arrival airport.
        /// </value>
        public string ArrivalAirportName { get; set; }

        /// <summary>
        /// Gets or sets the arrival airport code.
        /// </summary>
        /// <value>
        /// The arrival airport code.
        /// </value>
        public string ArrivalAirportCode { get; set; }

        /// <summary>
        /// Gets or sets the arrival airport city.
        /// </summary>
        /// <value>
        /// The arrival airport city.
        /// </value>
        public string ArrivalAirportCity { get; set; }

        /// <summary>
        /// Gets or sets the arrival airport gate.
        /// </summary>
        /// <value>
        /// The arrival airport gate.
        /// </value>
        public string ArrivalAirportGate { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }
    }
}