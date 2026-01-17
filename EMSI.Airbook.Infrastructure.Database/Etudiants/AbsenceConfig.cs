using EMSI.Airbook.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMSI.Airbook.Infrastructure.Database.Etudiants;

public class EtudiantConfig : IEntityTypeConfiguration<EtudiantDao>
{
    public void Configure(EntityTypeBuilder<EtudiantDao> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(30);
    }
}