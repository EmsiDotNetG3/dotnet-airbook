using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Presentation.DTO;
using Mapster;

namespace EMSI.Airbook.WebAPI.Mappings;

public class AbsenceMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Absence, AbsenceDto>();
        config.NewConfig<AbsenceDto, Absence>();
    }
}