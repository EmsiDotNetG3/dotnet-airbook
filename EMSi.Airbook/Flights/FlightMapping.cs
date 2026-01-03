using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Infrastructure.DAO;
using Mapster;

namespace EMSi.Airbook.Flights;

public class FlightMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<FlightDao, Flight>();
        config.NewConfig<Flight, FlightDao>();
    }
}