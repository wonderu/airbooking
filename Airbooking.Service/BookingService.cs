using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices.ComTypes;
using Airbooking.Data.Infrastructure;
using Airbooking.Data.Repositories;
using Airbooking.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Airbooking.Service
{
    /// <summary>
    /// Booking Service Class
    /// </summary>
    /// <seealso cref="Airbooking.Service.IBookingService" />
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingService" /> class.
        /// </summary>
        /// <param name="bookingRepository">The booking repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public BookingService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
        {
            if (bookingRepository == null)
                throw new ArgumentNullException(nameof(bookingRepository));

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all bookings by user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public IEnumerable<Booking> GetAllBookingsByUser(string userId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            return _bookingRepository.GetMany(b => b.User.Id == userId);
        }

        /// <summary>
        /// Gets the booking.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public Booking GetBooking(int bookingId)
        {
            if (bookingId <= 0)
                throw new ArgumentOutOfRangeException(nameof(bookingId));

            return _bookingRepository.GetById(bookingId);
        }

        /// <summary>
        /// Creates the booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns>
        /// Booking Id
        /// </returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public int CreateBooking(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));

            return _bookingRepository.AddBookingAndCommit(booking);
        }

        /// <summary>
        /// Gets the booking PDF.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        /// <param name="stream">The stream.</param>
        public void GetBookingPdf(int bookingId, Stream stream)
        {
            var booking = GetBooking(bookingId);
            var doc = new Document();

            PdfWriter.GetInstance(doc, stream);
            doc.Open();
            var table = new PdfPTable(2);

            table.AddCell(new PdfPCell(new Phrase($"ELECTRONIC TICKET. PNR: {booking.Pnr}",
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
                    iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))))
            {
                BackgroundColor = new BaseColor(Color.Wheat),
                Padding = 5,
                Colspan = 2,
                HorizontalAlignment = Element.ALIGN_LEFT
            });

            table.AddCell($"PNR: {booking.Pnr}");
            table.AddCell("");
            foreach (var passenger in booking.Tickets.Select(t => t.Passenger).Distinct())
            {
                table.AddCell($"Passenger: {passenger.FirstName} {passenger.LastName}");
                table.AddCell($"ELECTRONIC TICKETS: {string.Join(", ", passenger.Tickets.Select(t => t.ElectronicTicketNumber).ToArray())}");
            }

            table.AddCell(new PdfPCell(new Phrase("ITINERARY",
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
                    iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))))
            {
                BackgroundColor = new BaseColor(Color.Wheat),
                Padding = 5,
                Colspan = 2,
                HorizontalAlignment = Element.ALIGN_LEFT
            });

            foreach (var flight in booking.Tickets.Select(t => t.FlightSchedule).Distinct().OrderBy(f=>f.DepartureDate))
            {
                var str =
                    string.Format("{0}: {1} ({2}) - ", flight.DepartureDate.ToShortDateString(),
                        flight.Flight.DepartureInfo.Airport.City, flight.Flight.DepartureInfo.Airport.Code) +
                    string.Format("{0} ({1}){2}", flight.Flight.ArrivalInfo.Airport.City,
                        flight.Flight.ArrivalInfo.Airport.Code, Environment.NewLine) +
                    string.Format("{0} - {1} {2} ({3})", flight.Flight.DepartureInfo.Time.ToString(@"hh\:mm"),
                        flight.Flight.ArrivalInfo.Time.ToString(@"hh\:mm"), flight.Flight.Code, flight.Airplane.Model);

                table.AddCell(new PdfPCell(new Phrase(str,
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
                    iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))))
                {
                    //BackgroundColor = new BaseColor(Color.Wheat),
                    Padding = 5,
                    Colspan = 2,
                    HorizontalAlignment = Element.ALIGN_LEFT
                });
            }

            table.AddCell(new PdfPCell(new Phrase("CALCULATION",
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
                    iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))))
            {
                BackgroundColor = new BaseColor(Color.Wheat),
                Padding = 5,
                Colspan = 2,
                HorizontalAlignment = Element.ALIGN_LEFT
            });

            table.AddCell("");
            table.AddCell($"Total price: {booking.Price}");
            
            doc.Add(table);
            doc.Close();
        }

        /// <summary>
        /// Saves the booking.
        /// </summary>
        public void SaveBooking()
        {
            _unitOfWork.Commit();
        }
    }

    /// <summary>
    /// Booking Service Interface
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Gets all bookings by user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IEnumerable<Booking> GetAllBookingsByUser(string userId);

        /// <summary>
        /// Gets the booking.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        /// <returns></returns>
        Booking GetBooking(int bookingId);

        /// <summary>
        /// Creates the booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns>
        /// Booking Id
        /// </returns>
        int CreateBooking(Booking booking);

        /// <summary>
        /// Gets the booking PDF.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        /// <param name="stream">The stream.</param>
        void GetBookingPdf(int bookingId, Stream stream);

        /// <summary>
        /// Saves the booking.
        /// </summary>
        void SaveBooking();
    }
}
