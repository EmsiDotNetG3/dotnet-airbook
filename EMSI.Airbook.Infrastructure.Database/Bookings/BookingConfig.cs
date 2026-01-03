using EMSI.Airbook.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMSI.Airbook.Infrastructure.Database.Bookings;

public class BookingConfig : IEntityTypeConfiguration<BookingDao>
{
    public void Configure(EntityTypeBuilder<BookingDao> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CheckingDate).IsRequired(false);
        builder.HasOne(x => x.Flight).WithMany().HasForeignKey(x => x.FlightId);
        builder.HasOne(x => x.Passenger).WithMany().HasForeignKey(x => x.PassengerId);
    }
}