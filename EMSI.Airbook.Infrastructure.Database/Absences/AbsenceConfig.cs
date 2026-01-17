using EMSI.Airbook.Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMSI.Airbook.Infrastructure.Database.Absences;

public class AbsenceConfig : IEntityTypeConfiguration<AbsenceDao>
{
    public void Configure(EntityTypeBuilder<AbsenceDao> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Etudiant).WithMany().HasForeignKey(x => x.EtudiantId);

    }
}