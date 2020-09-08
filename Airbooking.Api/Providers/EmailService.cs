using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Airbooking.Service;
using Postal;

namespace Airbooking.Api.Providers
{
    /// <summary>
    /// Email Service Class
    /// </summary>
    /// <seealso cref="Airbooking.Api.Providers.IEmailService" />
    public class EmailService : IEmailService
    {
        private readonly IBookingService _bookingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailService"/> class.
        /// </summary>
        /// <param name="bookingService">The booking service.</param>
        public EmailService(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        /// <summary>
        /// Sends the booking to email.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        /// <param name="emailAddress">The email address.</param>
        public void SendBookingToEmail(int bookingId, string emailAddress)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                _bookingService.GetBookingPdf(bookingId, stream);
                var path = Path.GetTempFileName();
                try
                {
                    File.WriteAllBytes(path, stream.GetBuffer());

                    dynamic email = new Email("Booking");
                    email.To = emailAddress;
                    email.Attach(new Attachment(path, "attachment/mime") {ContentDisposition = { FileName = $"booking_{bookingId}.pdf" } });
                    email.Send();
                }
                finally
                {
                    File.Delete(path);
                }
            }
        }
    }

    /// <summary>
    /// Email Service Interface
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends the booking to email.
        /// </summary>
        /// <param name="bookingId">The booking identifier.</param>
        /// <param name="emailAddress">The email address.</param>
        void SendBookingToEmail(int bookingId, string emailAddress);
    }
}