using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Infrastructure.DAO;
using Mapster;

namespace EMSi.Airbook.Passengers;

public class PassengerMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Passenger, PassengerDao>();
        config.NewConfig<PassengerDao, Passenger>();
    }
}