using Airbooking.Api.Providers;
using Airbooking.Api.ViewModels;

namespace Airbooking.Api.Tests.Fake
{
    public class TestPaymentProvider: IPaymentProvider
    {
        public decimal GetPayment(BookingViewModel booking)
        {
            return 123;
        }
    }
}
