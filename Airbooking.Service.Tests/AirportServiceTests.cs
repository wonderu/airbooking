using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Airbooking.Model;
using Airbooking.Service.Tests.Fake;

namespace Airbooking.Service.Tests
{
    [TestClass]
    public class AirportServiceTests
    {
        [TestMethod]
        public void GetAllAirportsTest()
        {
            AirportService service = new AirportService(new TestAirportRepository(new Airport { Name = "Name", Code = "Code", City = "City", TimeZone = 999 }), new TestUnitOfWork());
            var airports = service.GetAllAirports();
            foreach (var airport in airports)
            {
                Assert.AreEqual(airport.Code, "Code");
                Assert.AreEqual(airport.City, "City");
                Assert.AreEqual(airport.Name, "Name");
                Assert.AreEqual(airport.TimeZone, 999);
            }
        }

        [TestMethod]
        public void GetAirportByCodeTest()
        {
            AirportService service = new AirportService(new TestAirportRepository(new Airport { Name = "Name", Code = "Code", City = "City", TimeZone = 999 }), new TestUnitOfWork());
            var airport = service.GetAirportByCode("COD");
            Assert.IsNotNull(airport);
            Assert.AreEqual(airport.Code, "Code");
            Assert.AreEqual(airport.City, "City");
            Assert.AreEqual(airport.Name, "Name");
            Assert.AreEqual(airport.TimeZone, 999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetGetAirportByCodeExceptionTest()
        {
            AirportService service = new AirportService(new TestAirportRepository(new Airport { Name = "Name", Code = "Code", City = "City", TimeZone = 999 }), new TestUnitOfWork());
            service.GetAirportByCode(null);
        }

        [TestMethod]
        public void GetSaveAirportTest()
        {
            var testUnitOfWork = new TestUnitOfWork {Commited = false};

            AirportService service = new AirportService(new TestAirportRepository(null), testUnitOfWork);
            service.SaveAirport();

            Assert.IsTrue(testUnitOfWork.Commited);
        }
    }
}