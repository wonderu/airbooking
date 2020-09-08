using System;
using System.Collections.Generic;
using System.Web.Http;
using Airbooking.Api.ViewModels;
using Airbooking.Model;
using Airbooking.Service;
using Airbooking.Utils;
using Airbooking.Utils.Logging;
using AutoMapper;

namespace Airbooking.Api.Controllers
{
    /// <summary>
    /// Airport Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class AirportController : ApiController
    {
        private readonly IAirportService _airportService;
        private readonly ILoggingService _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirportController" /> class.
        /// </summary>
        /// <param name="airportService">The airport service.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public AirportController(IAirportService airportService, ILoggingService logger)
        {
            if (airportService == null)
                throw new ArgumentNullException(nameof(airportService));

            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _airportService = airportService;
            _logger = logger;
        }

        /// <summary>
        /// Gets all airports.
        /// </summary>
        /// <returns>List of airports</returns>
        public IEnumerable<AirportViewModel> Get()
        {
            return ApiExceptionHelper.WrapException(() =>
            {
                _logger.Info("Get all airports.");
                var airportViewModels = Mapper.Map<IEnumerable<Airport>, IEnumerable<AirportViewModel>>(_airportService.GetAllAirports());
                _logger.Info("Returned all airports. Airports='{0}'", airportViewModels.ToJson());
                return airportViewModels;
            }, _logger);
        }

        /// <summary>
        /// Gets the specified airport by id.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>
        /// Airport
        /// </returns>
        public AirportViewModel Get(string code)
        {
            return ApiExceptionHelper.WrapException(() =>
            {
                if (string.IsNullOrEmpty(code))
                    throw new ArgumentNullException(nameof(code));

                _logger.Info("Get airport by code '{0}'", code);
                var airportViewModel = Mapper.Map<Airport, AirportViewModel>(_airportService.GetAirportByCode(code));
                _logger.Info("Returned Airport. Airport='{0}'", airportViewModel.ToJson());
                return airportViewModel;
            }, _logger);
        }
    }
}