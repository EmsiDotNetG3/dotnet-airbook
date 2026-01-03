using EMSI.Airbook.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMSI.Airbook.Infrastructure.Database.Flights;

public class FlightConfig : IEntityTypeConfiguration<FlightDao>
{
    public void Configure(EntityTypeBuilder<FlightDao> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.DepartureFrom).HasMaxLength(30);
        builder.Property(x => x.ArrivalTo).HasMaxLength(30);
    }
}