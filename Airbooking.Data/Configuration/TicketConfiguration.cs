using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airbooking.Model;

namespace Airbooking.Data.Configuration
{
    internal class TicketConfiguration : EntityTypeConfiguration<Ticket>
    {
        public TicketConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Booking)      
                .WithMany()                         
                .HasForeignKey(x => x.BookingId);

            HasRequired(x => x.FlightSchedule)
                .WithMany()
                .HasForeignKey(x => x.FlightScheduleId);
        }
    }
}
