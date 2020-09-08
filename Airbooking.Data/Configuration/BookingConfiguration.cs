using System.Data.Entity.ModelConfiguration;
using Airbooking.Model;

namespace Airbooking.Data.Configuration
{
    internal class BookingConfiguration : EntityTypeConfiguration<Booking>
    {
        public BookingConfiguration()
        {
            HasKey(p => p.Id);
        }
    }
}