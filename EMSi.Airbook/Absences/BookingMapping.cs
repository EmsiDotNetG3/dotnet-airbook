using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Infrastructure.DAO;
using Mapster;

namespace EMSi.Airbook.Absences;

public class AbsenceMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AbsenceDao, Absence>();
        config.NewConfig<Absence, AbsenceDao>()
            .Map(dest => dest.EtudiantId, src =>src.Etudiant.Id);
    }
}