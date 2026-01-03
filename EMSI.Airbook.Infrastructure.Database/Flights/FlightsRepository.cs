using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;

namespace EMSI.Airbook.Infrastructure.Database.Flights;

internal class FlightsRepository : RepositoryBase<UnitOfWork, FlightDao, Guid>, IFlightsRepository
{
    protected FlightsRepository(UnitOfWork context) : base(context)
    {
    }
}