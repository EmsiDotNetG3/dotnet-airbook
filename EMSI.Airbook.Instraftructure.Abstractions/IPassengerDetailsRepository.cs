using EMSI.Airbook.Infrastructure.DAO;

namespace EMSI.Airbook.Instraftructure.Abstractions;

public interface IPassengerDetailsRepository : ISupportsReadRepository<PassengerDetailsDao, Guid>
{
    
}