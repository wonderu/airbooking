using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Airbooking.Api.Controllers;
using Airbooking.Api.Tests.Fake;
using Airbooking.Api.ViewModels;
using Airbooking.Model;
using Airbooking.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airbooking.Api.Tests.Controllers
{
    [TestClass]
    public class BookingControllerTests
    {
        [TestInitialize]
        public void Init()
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IAssembliesResolver),
                new TestAssembliesResolver());

            BootStrapper.Run();
        }

        private List<Booking> GetBookings()
        {
            return new List<Booking>
            {
                new Booking()
            };
        }

        [TestMethod]
        public void CreateBookingReturnTest()
        {
            var testBookingService = new TestBookingService(GetBookings());
            var controller = new BookingController(testBookingService,
               new TestPaymentProvider(),
               new TestLoggingService(),
               new TestEmailService(), new TestHttpAuthorizationProvider());

            var bookingViewModel = new BookingViewModel
            {
                CreditCard = new CreditCardViewModel
                {
                    CardHolder = "John Snow",
                    CardNumber = "5277056705647128",
                    ExpiryMonth = 12,
                    ExpiryYear = 2016,
                    SecretCode = 122
                },
                OutboundFlightScheduleId = 123,
                ReturnFlightScheduleId = 321,
                Price = 544,
                Passengers = new List<PassengerViewModel>
                {
                    new PassengerViewModel
                    {
                        BirthDate = new DateTime(1980, 02, 03),
                        Sex = 1,
                        FirstName = "John",
                        LastName = "Snow",
                        PassportNumber = "2244333S"
                    },
                    new PassengerViewModel
                    {
                        BirthDate = new DateTime(1989, 02, 03),
                        Sex = 2,
                        FirstName = "Taylor",
                        LastName = "Swift",
                        PassportNumber = "224D4333S"
                    }
                }
            };
            Assert.AreEqual(controller.Post(bookingViewModel), 6543);
            Assert.AreEqual(testBookingService.CreatedBooking.Price, bookingViewModel.Price);
            Assert.IsFalse(string.IsNullOrEmpty(testBookingService.CreatedBooking.Pnr));
            Assert.AreEqual(testBookingService.CreatedBooking.Payment, 123);
            Assert.IsNotNull(testBookingService.CreatedBooking.Tickets);

            foreach (var ticket in testBookingService.CreatedBooking.Tickets)
            {
                //TODO: test tickets here
            }
        }

        [TestMethod]
        public void CreateBookingOneWayTest()
        {
            var testBookingService = new TestBookingService(GetBookings());
            var controller = new BookingController(testBookingService,
               new TestPaymentProvider(),
               new TestLoggingService(),
               new TestEmailService(),
               new TestHttpAuthorizationProvider());

            var bookingViewModel = new BookingViewModel
            {
                CreditCard = new CreditCardViewModel
                {
                    CardHolder = "John Snow",
                    CardNumber = "5277056705647128",
                    ExpiryMonth = 12,
                    ExpiryYear = 2016,
                    SecretCode = 122
                },
                OutboundFlightScheduleId = 123,
                Price = 544,
                Passengers = new List<PassengerViewModel>
                {
                    new PassengerViewModel
                    {
                        BirthDate = new DateTime(1980, 02, 03),
                        Sex = 1,
                        FirstName = "John",
                        LastName = "Snow",
                        PassportNumber = "2244333S"
                    },
                    new PassengerViewModel
                    {
                        BirthDate = new DateTime(1989, 02, 03),
                        Sex = 2,
                        FirstName = "Taylor",
                        LastName = "Swift",
                        PassportNumber = "224D4333S"
                    }
                }
            };

            Assert.AreEqual(controller.Post(bookingViewModel), 6543);
            Assert.AreEqual(testBookingService.CreatedBooking.Price, bookingViewModel.Price);
            Assert.IsFalse(string.IsNullOrEmpty(testBookingService.CreatedBooking.Pnr));
            Assert.AreEqual(testBookingService.CreatedBooking.Payment, 123);
            Assert.IsNotNull(testBookingService.CreatedBooking.Tickets);

            foreach (var ticket in testBookingService.CreatedBooking.Tickets)
            {
                //TODO: test tickets here
            }
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void CreateBookingNullTest()
        {
            var testBookingService = new TestBookingService(GetBookings());
            var controller = new BookingController(testBookingService,
               new TestPaymentProvider(),
               new TestLoggingService(),
               new TestEmailService(), new TestHttpAuthorizationProvider());
            controller.Post(null);
        }
    }

    public class TestBookingService : IBookingService
    {
        private readonly IEnumerable<Booking> _bookings;
        private readonly Booking _booking;

        public Booking CreatedBooking { get; set; }

        public TestBookingService(Booking booking)
        {
            _booking = booking;
        }

        public TestBookingService(IEnumerable<Booking> bookings)
        {
            _bookings = bookings;
        }

        public IEnumerable<Booking> GetAllBookingsByUser(string userId)
        {
            return _bookings;
        }

        public Booking GetBooking(int bookingId)
        {
            return _booking;
        }

        public int CreateBooking(Booking booking)
        {
            booking.Id = 6543;
            CreatedBooking = booking;
            return booking.Id;
        }

        public void GetBookingPdf(int bookingId, Stream stream)
        {
            throw new NotImplementedException();
        }

        public void SaveBooking()
        {
            
        }
    }
}