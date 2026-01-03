using EMSI.Airbook.Infrastructure.DAO;

namespace EMSI.Airbook.Instraftructure.Abstractions;

public interface IPassengersRepository : ISupportsReadRepository<PassengerDao, Guid>, ISupportsWriteRepository<PassengerDao, Guid>
{
}