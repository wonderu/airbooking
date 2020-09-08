using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Airbooking.Data.Infrastructure;
using Airbooking.Model;
using Moq;

namespace Airbooking.Data.Tests.Fake
{
    public class TestDbFactory : IDbFactory
    {
        public Mock<DbSet<Booking>> MockSetBooking { get; private set; }
        public Mock<AirbookingEntities> MockContext { get; private set; }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public AirbookingEntities Init()
        {
            var mockSet = new Mock<DbSet<Airport>>();

            var data = new List<Airport>
            {
                new Airport { Name = "Name", Code = "Code", City = "City", TimeZone = 999 }
            }.AsQueryable();

            mockSet.As<IQueryable<Airport>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Airport>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Airport>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Airport>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            

            MockSetBooking = new Mock<DbSet<Booking>>();

            var data2 = new List<Booking>().AsQueryable();

            MockSetBooking.As<IQueryable<Booking>>().Setup(m => m.Provider).Returns(data2.Provider);
            MockSetBooking.As<IQueryable<Booking>>().Setup(m => m.Expression).Returns(data2.Expression);
            MockSetBooking.As<IQueryable<Booking>>().Setup(m => m.ElementType).Returns(data2.ElementType);
            MockSetBooking.As<IQueryable<Booking>>().Setup(m => m.GetEnumerator()).Returns(data2.GetEnumerator());

            MockContext = new Mock<AirbookingEntities>();
            MockContext.Setup(m => m.Airports).Returns(mockSet.Object);
            MockContext.Setup(m => m.Bookings).Returns(MockSetBooking.Object);

            return MockContext.Object;
        }

        
    }
}