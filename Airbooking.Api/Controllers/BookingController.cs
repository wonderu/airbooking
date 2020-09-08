using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Airbooking.Api.Providers;
using Airbooking.Api.ViewModels;
using Airbooking.Model;
using Airbooking.Service;
using Airbooking.Utils;
using Airbooking.Utils.Logging;
using AutoMapper;
using WebGrease.Css.Extensions;

namespace Airbooking.Api.Controllers
{
    /// <summary>
    /// Booking Controller Class
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    //[System.Web.Http.Authorize]
    //    [RequireHttps]
    public class BookingController : ApiController
    {
        private readonly IBookingService _bookingService;
        private readonly IPaymentProvider _paymentProvider;
        private readonly ILoggingService _logger;
        private readonly IEmailService _emailService;
        private readonly IHttpAuthorizationProvider _httpAuthorizationProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingController" /> class.
        /// </summary>
        /// <param name="bookingService">The booking service.</param>
        /// <param name="paymentProvider">The payment provider.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="emailService">The email service.</param>
        /// <param name="httpAuthorizationProvider">The HTTP authorization provider.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public BookingController(IBookingService bookingService, 
            IPaymentProvider paymentProvider, 
            ILoggingService logger,
            IEmailService emailService,
            IHttpAuthorizationProvider httpAuthorizationProvider)
        {
            if (bookingService == null)
                throw new ArgumentNullException(nameof(bookingService));

            if (paymentProvider == null)
                throw new ArgumentNullException(nameof(paymentProvider));

            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            if (emailService == null)
                throw new ArgumentNullException(nameof(emailService));

            if (httpAuthorizationProvider == null)
                throw new ArgumentNullException(nameof(httpAuthorizationProvider));

            _bookingService = bookingService;
            _paymentProvider = paymentProvider;
            _logger = logger;
            _emailService = emailService;
            _httpAuthorizationProvider = httpAuthorizationProvider;
        }

        /// <summary>
        /// Gets bookings of current user.
        /// </summary>
        /// <returns>List of bookings</returns>
        [Authorize]
        public IEnumerable<BookingViewModel> Get()
        {
            return ApiExceptionHelper.WrapException(() =>
            {
                throw new NotImplementedException();
                _logger.Info("Get all bookings of user");
                return
                    Mapper.Map<IEnumerable<Booking>, IEnumerable<BookingViewModel>>(
                        _bookingService.GetAllBookingsByUser(_httpAuthorizationProvider.UserId));
            }, _logger);
        }

        /// <summary>
        /// Gets the booking by Id.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        /// <returns>
        /// Booking
        /// </returns>
        public BookingViewModel Get(int bookingId)
        {
            return ApiExceptionHelper.WrapException(() =>
            {
                throw new NotImplementedException();
                if (bookingId <= 0)
                    throw new ArgumentOutOfRangeException(nameof(bookingId));

                _logger.Info("Get booking by '{0}'", bookingId);
                return
                    Mapper.Map<Booking, BookingViewModel>(_bookingService.GetBooking(
                        bookingId));
            }, _logger);
        }

        /// <summary>
        /// Gets PDF document.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        /// <param name="needPdf">if set to <c>true</c> [need PDF].</param>
        /// <returns>PDF document</returns>
        public HttpResponseMessage Get(int bookingId, bool needPdf)
        {
            return ApiExceptionHelper.WrapException(() =>
            {
                if (bookingId <= 0)
                    throw new ArgumentOutOfRangeException(nameof(bookingId));

                _logger.Info("Get PDF-booking by '{0}'", bookingId);

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                using (var stream = new MemoryStream())
{
                    _bookingService.GetBookingPdf(bookingId, stream);

                    result.Content = new ByteArrayContent(stream.GetBuffer());

                    result.Content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/pdf");
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = $"booking_{bookingId}.pdf"
                    };
                }
                
                return result;
            }, _logger);
        }

        /// <summary>
        /// Create booking.
        /// </summary>
        /// <param name="bookingViewModel">The booking view model.</param>
        /// <returns>
        /// Booking Id
        /// </returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        [HttpPost]
        [Authorize]
        public int Post(BookingViewModel bookingViewModel)
        {
            return ApiExceptionHelper.WrapException(() =>
            {
                if (bookingViewModel == null)
                    throw new ArgumentNullException(nameof(bookingViewModel));

                _logger.Info("Attempt to create new booking. Booking='{0}'", bookingViewModel.ToJson());

                var booking = Mapper.Map<BookingViewModel, Booking>(bookingViewModel);
                booking.PaymentDateTime = DateTime.Now;
                booking.ApplicationUserId = _httpAuthorizationProvider.UserId;
                booking.Pnr = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

                booking.Tickets = new List<Ticket>();
                bookingViewModel.Passengers.ForEach(p =>
                {
                    var passenger = Mapper.Map<PassengerViewModel, Passenger>(p);
                    booking.Tickets.Add(new Ticket
                    {
                        //Booking = booking,
                        ElectronicTicketNumber = Guid.NewGuid().ToString("N").Substring(0, 16).ToUpper(),
                        FlightScheduleId = bookingViewModel.OutboundFlightScheduleId,
                        Passenger = passenger
                    });

                    if (bookingViewModel.ReturnFlightScheduleId.HasValue)
                    {
                        booking.Tickets.Add(new Ticket
                        {
                            //Booking = booking,
                            ElectronicTicketNumber = Guid.NewGuid().ToString("N").Substring(0, 16).ToUpper(),
                            FlightScheduleId = bookingViewModel.ReturnFlightScheduleId.Value,
                            Passenger = passenger
                        });
                    }
                });
                 
                booking.Payment = _paymentProvider.GetPayment(bookingViewModel);

                var bookingId = _bookingService.CreateBooking(booking);
                _bookingService.SaveBooking();
                _logger.Info("Created new booking. BookingId='{0}'", bookingId);
                _emailService.SendBookingToEmail(bookingId,_httpAuthorizationProvider.CurrentEmail);
                return bookingId;
            }, _logger);
        }
    }
}