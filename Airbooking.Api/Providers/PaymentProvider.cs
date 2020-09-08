using System;
using Airbooking.Api.ViewModels;

namespace Airbooking.Api.Providers
{
    /// <summary>
    /// Payment Provider Class
    /// </summary>
    /// <seealso cref="Airbooking.Api.Providers.IPaymentProvider" />
    public class PaymentProvider: IPaymentProvider
    {
        /// <summary>
        /// Gets the payment.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns></returns>
        public decimal GetPayment(BookingViewModel booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));

            if (string.IsNullOrEmpty(booking.CreditCard?.CardHolder) || string.IsNullOrEmpty(booking.CreditCard.CardNumber))
                throw new ArgumentException("Credit card information is not fullfilled", nameof(booking.CreditCard));

            if (new DateTime(booking.CreditCard.ExpiryYear, booking.CreditCard.ExpiryMonth, 1) <= DateTime.Now)
                throw new ArgumentException("Credit card is expired", nameof(booking.CreditCard));

            return booking.Price;
        }
    }

    /// <summary>
    /// Payment Provider Interface
    /// </summary>
    public interface IPaymentProvider
    {
        /// <summary>
        /// Gets the payment.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns></returns>
        decimal GetPayment(BookingViewModel booking);
    }
}