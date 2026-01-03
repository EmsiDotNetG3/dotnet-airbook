using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;

namespace EMSI.Airbook.Infrastructure.Database.Bookings;

internal class BookingsRepository : RepositoryBase<UnitOfWork, BookingDao, Guid>, IBookingsRepository
{
    protected BookingsRepository(UnitOfWork context) : base(context)
    {
    }
}