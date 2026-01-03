using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;

namespace EMSI.Airbook.Infrastructure.Database.Bookings;

internal class BookingsRepository : RepositoryBase<UnitOfWork, BookingDao, Guid>, IBookingsRepository
{
    public BookingsRepository(UnitOfWork context) : base(context)
    {
    }
}