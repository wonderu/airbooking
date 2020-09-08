using System;
using Airbooking.Api.ViewModels;

namespace Airbooking.Api.Providers
{
    /// <summary>
    /// Price Calculator Provider class
    /// </summary>
    public class PriceCalculatorProvider: IPriceCalculatorProvider
    {
        private readonly Random _randomizer = new Random();

        /// <summary>
        /// Calculates the price of the specified flight.
        /// </summary>
        /// <param name="flight">The flight.</param>
        /// <returns>
        /// Price
        /// </returns>
        public decimal Calculate(FlightScheduleViewModel flight)
        {
            return 200 + _randomizer.Next(200); 
        }
    }

    /// <summary>
    /// Price Calculator Provider Interface
    /// </summary>
    public interface IPriceCalculatorProvider
    {
        /// <summary>
        /// Calculates the price of the specified flight.
        /// </summary>
        /// <param name="flight">The flight.</param>
        /// <returns>Price</returns>
        decimal Calculate(FlightScheduleViewModel flight);
    }
}