using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Presentation.DTO;
using Mapster;

namespace EMSI.Airbook.WebAPI.Mappings;

public class BookingMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<BookingRequestDto, Booking>()
            .Map(dest => dest.Passenger, src => new Passenger
            {
                Id = src.PassengerId
            })
            .Map(dest => dest.Flight, src => new Flight
            {
                Id = src.FlightId
            });
    }
}