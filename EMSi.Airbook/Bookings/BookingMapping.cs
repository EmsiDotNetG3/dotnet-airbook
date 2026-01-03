using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Infrastructure.DAO;
using Mapster;

namespace EMSi.Airbook.Bookings;

public class BookingMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<BookingDao, Booking>();
        config.NewConfig<Booking, BookingDao>();
    }
}