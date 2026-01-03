using EMSI.Airbook.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMSI.Airbook.Infrastructure.Database.Passengers;

public class PassengerConfig : IEntityTypeConfiguration<PassengerDao>
{
    public void Configure(EntityTypeBuilder<PassengerDao> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FullName).HasMaxLength(30);
        builder.Property(x => x.Email).HasMaxLength(30);
        builder.Property(x => x.PhoneNumber).HasMaxLength(30);
        builder.Property(x => x.PassportNumber).IsRequired(false).HasMaxLength(30);
    }
}