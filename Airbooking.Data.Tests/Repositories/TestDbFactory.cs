using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Airbooking.Data.Infrastructure;
using Airbooking.Model;
using Moq;

namespace Airbooking.Data.Tests.Repositories
{
    public class TestDbFactory : IDbFactory
    {
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

            var mockContext = new Mock<AirbookingEntities>();
            mockContext.Setup(m => m.Airports).Returns(mockSet.Object);

            return mockContext.Object;
        }
    }
}