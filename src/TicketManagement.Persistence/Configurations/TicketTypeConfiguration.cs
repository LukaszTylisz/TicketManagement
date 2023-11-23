using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManagement.Domain;

namespace TicketManagement.Persistence.Configurations
{
    public class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
    {
        public void Configure(EntityTypeBuilder<TicketType> builder)
        {
            builder.HasData(
                new TicketType
                {
                    Id = 1,
                    Name = "BusTicket",
                    DefaultDays = 10,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
            );

            builder.Property(q => q.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
