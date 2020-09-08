using System;
using Airbooking.Data.Repositories;
using Airbooking.Data.Tests.Fake;
using Airbooking.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Airbooking.Data.Tests.Repositories
{
    [TestClass]
    public class BookingRepositoryTests
    {
        [TestMethod]
        public void AddBookingAndCommitTest()
        {
            var testDbFactory = new TestDbFactory();
            var repository = new BookingRepository(testDbFactory);
            repository.AddBookingAndCommit(new Booking {Id = 54321, Payment = 4321, Pnr = "WEQWSDD"});
            testDbFactory.MockSetBooking.Verify(m=>m.Add(It.IsAny<Booking>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddBookingAndCommitNullTest()
        {
            var testDbFactory = new TestDbFactory();
            var repository = new BookingRepository(testDbFactory);
            repository.AddBookingAndCommit(null);
        }
    }
}
