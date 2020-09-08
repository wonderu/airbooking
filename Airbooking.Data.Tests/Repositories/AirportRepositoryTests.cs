using Airbooking.Data.Repositories;
using Airbooking.Data.Tests.Fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airbooking.Data.Tests.Repositories
{
    [TestClass]
    public class AirportRepositoryTests
    {
        [TestMethod]
        public void GetAirportByCodeTest()
        {
            AirportRepository repository = new AirportRepository(new TestDbFactory());
            var airport = repository.GetAirportByCode("Code");
            Assert.IsNotNull(airport);
            Assert.AreEqual(airport.Code, "Code");
            Assert.AreEqual(airport.City, "City");
            Assert.AreEqual(airport.Name, "Name");
            Assert.AreEqual(airport.TimeZone, 999);
        }

        [TestMethod]
        public void GetAirportByCodeNotFoundTest()
        {
            AirportRepository repository = new AirportRepository(new TestDbFactory());
            var airport = repository.GetAirportByCode("KOD");
            Assert.IsNull(airport);
        }
    }
}