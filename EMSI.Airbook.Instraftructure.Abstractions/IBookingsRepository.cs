using EMSI.Airbook.Infrastructure.DAO;

namespace EMSI.Airbook.Instraftructure.Abstractions;

public interface IBookingsRepository : ISupportsReadRepository<BookingDao, Guid>, ISupportsWriteRepository<BookingDao, Guid>
{
    
}