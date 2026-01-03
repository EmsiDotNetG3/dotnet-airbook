using EMSI.Airbook.Infrastructure.DAO;

namespace EMSI.Airbook.Instraftructure.Abstractions;

public interface IFlightsRepository : ISupportsReadRepository<FlightDao, Guid>, ISupportsWriteRepository<FlightDao, Guid>
{
}