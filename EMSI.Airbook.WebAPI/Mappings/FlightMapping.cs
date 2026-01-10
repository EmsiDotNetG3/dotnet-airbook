using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Presentation.DTO;
using Mapster;

namespace EMSI.Airbook.WebAPI.Mappings;

public class FlightMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Flight, FlightDto>();
    }
}