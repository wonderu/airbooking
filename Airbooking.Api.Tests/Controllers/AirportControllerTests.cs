using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Airbooking.Api.Controllers;
using Airbooking.Api.Tests.Fake;
using Airbooking.Model;
using Airbooking.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airbooking.Api.Tests.Controllers
{
    [TestClass]
    public class AirportControllerTests
    {
        [TestInitialize]
        public void Init()
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IAssembliesResolver),
                new TestAssembliesResolver());

            BootStrapper.Run();
        }

        [TestMethod]
        public void GetAllAirports()
        {
            var controller = new AirportController(new TestAirportService(new Airport { Name = "Name", Code = "Code", City = "City", TimeZone = 999 }), new TestLoggingService());
            var airports = controller.Get();
            Assert.IsNotNull(airports, "airports != null");
            Assert.AreEqual(airports.Count(), 1);
            foreach (var airportViewModel in airports)
            {
                Assert.AreEqual(airportViewModel.Code, "Code");
                Assert.AreEqual(airportViewModel.City, "City");
                Assert.AreEqual(airportViewModel.Name, "Name");
                Assert.AreEqual(airportViewModel.TimeZone, 999);
            }
        }

        [TestMethod]
        public void GetAirportByCode()
        {
            var controller = new AirportController(new TestAirportService(new Airport { Name = "Name", Code = "Code", City = "City", TimeZone = 999 }), new TestLoggingService());
            var airportViewModel = controller.Get("Code");
            Assert.IsNotNull(airportViewModel, "airportViewModel != null");
            Assert.AreEqual(airportViewModel.Code, "Code");
            Assert.AreEqual(airportViewModel.City, "City");
            Assert.AreEqual(airportViewModel.Name, "Name");
            Assert.AreEqual(airportViewModel.TimeZone, 999);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void GetAirportByCodeNull()
        {
            var controller = new AirportController(new TestAirportService(new Airport { Name = "Name", Code = "Code", City = "City", TimeZone = 999 }), new TestLoggingService());
            controller.Get(null);
        }
    }

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
