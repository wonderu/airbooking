using System.Collections.Generic;
using Airbooking.Model;
using Airbooking.Service;

namespace Airbooking.Api.Tests.Controllers
{
    public class TestAirportService : IAirportService
    {
        private readonly Airport _airport;
        public TestAirportService(Airport airport)
        {
            _airport = airport;
        }

        public IEnumerable<Airport> GetAllAirports()
        {
            return new List<Airport> { _airport };
        }

        public Airport GetAirportByCode(string code)
        {
            return _airport;
        }

        public void SaveAirport()
        {
            
        }
    }
}