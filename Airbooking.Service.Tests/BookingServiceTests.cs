using System;
using System.Collections.Generic;
using Airbooking.Model;
using Airbooking.Service.Tests.Fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airbooking.Service.Tests
{
    [TestClass]
    public class BookingServiceTests
    {
        [TestMethod]
        public void SaveBookingTest()
        {
            var testUnitOfWork = new TestUnitOfWork();
            var service = new BookingService(new TestBookingRepository(GetBookings()), testUnitOfWork);
            service.SaveBooking();
            Assert.IsTrue(testUnitOfWork.Commited);
        }

        [TestMethod]
        public void CreateBookingTest()
        {
            var service = new BookingService(new TestBookingRepository(GetBookings()), new TestUnitOfWork());
            Assert.AreEqual(service.CreateBooking(new Booking()), 543);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateBookingNullTest()
        {
            var service = new BookingService(new TestBookingRepository(GetBookings()), new TestUnitOfWork());
            service.CreateBooking(null);
        }

        [TestMethod]
        public void GetBookingsOfUserTest()
        {
            var service = new BookingService(new TestBookingRepository(GetBookings()), new TestUnitOfWork());
            var bookings= service.GetAllBookingsByUser("userId");
            Assert.IsNotNull(bookings);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetBookingsOfUserNullTest()
        {
            var service = new BookingService(new TestBookingRepository(GetBookings()), new TestUnitOfWork());
            service.GetAllBookingsByUser(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetBookingOutOfRangeTest()
        {
            var service = new BookingService(new TestBookingRepository(GetBooking()), new TestUnitOfWork());
            service.GetBooking(-1);
        }

        private IEnumerable<Booking> GetBookings()
        {
            return new List<Booking> { new Booking(), new Booking(), new Booking() };
        }

        private Booking GetBooking()
        {
            return new Booking();
        }
    }
}
