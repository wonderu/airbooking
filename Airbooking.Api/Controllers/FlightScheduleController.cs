using System;
using System.Collections.Generic;
using System.Web.Http;
using Airbooking.Api.Providers;
using Airbooking.Api.ViewModels;
using Airbooking.Model;
using Airbooking.Service;
using Airbooking.Utils;
using Airbooking.Utils.Logging;
using AutoMapper;
using Microsoft.Ajax.Utilities;

namespace Airbooking.Api.Controllers
{
    /// <summary>
    /// Flight Schedule Controller Class
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class FlightScheduleController : ApiController
    {
        private readonly IFlightScheduleService _flightScheduleService;
        private readonly IPriceCalculatorProvider _priceCalculator;
        private readonly ILoggingService _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightScheduleController" /> class.
        /// </summary>
        /// <param name="flightScheduleService">The flight schedule service.</param>
        /// <param name="priceCalculator">The price calculator.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public FlightScheduleController(IFlightScheduleService flightScheduleService, 
            IPriceCalculatorProvider priceCalculator,
            ILoggingService logger)
        {
            if (flightScheduleService == null)
                throw new ArgumentNullException(nameof(flightScheduleService));

            if (priceCalculator == null)
                throw new ArgumentNullException(nameof(priceCalculator));

            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _flightScheduleService = flightScheduleService;
            _priceCalculator = priceCalculator;
            _logger = logger;
        }

        /// <summary>
        /// Flight search request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// FlightSearchResponse
        /// </returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        [HttpPost]
        public FlightSearchResponse Post(FlightSearchRequest request)
        {
            return ApiExceptionHelper.WrapException(() =>
            {
                if (request == null)
                    throw new ArgumentNullException(nameof(request));

                _logger.Info("Try flight search: Request='{0}'", request.ToJson());

                var response = new FlightSearchResponse
                {
                    OutboundFlights = Mapper.Map<IEnumerable<FlightSchedule>, IEnumerable<FlightScheduleViewModel>>(
                        _flightScheduleService.GetFlightSchedules(
                            request.FromAirportCode,
                            request.ToAirportCode,
                            request.StartDateTime,
                            request.AdultCount,
                            request.InfantCount,
                            request.ChildrenCount)
                        ),
                    ReturnFlights = request.EndDateTime.HasValue
                        ? Mapper.Map<IEnumerable<FlightSchedule>, IEnumerable<FlightScheduleViewModel>>(
                            _flightScheduleService
                                .GetFlightSchedules(
                                    request.ToAirportCode,
                                    request.FromAirportCode,
                                    request.EndDateTime.Value,
                                    request.AdultCount,
                                    request.InfantCount,
                                    request.ChildrenCount))
                        : null
                };

                response.OutboundFlights.ForEach(f => f.Price = _priceCalculator.Calculate(f));
                response.ReturnFlights?.ForEach(f => f.Price = _priceCalculator.Calculate(f));

                _logger.Info("Flight found: Response='{0}'", response.ToJson());

                return response;
            },_logger);
        }
    }
}
