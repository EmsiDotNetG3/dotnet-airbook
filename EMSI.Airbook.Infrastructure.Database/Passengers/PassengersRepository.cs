using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;

namespace EMSI.Airbook.Infrastructure.Database.Passengers;

internal class PassengersRepository : RepositoryBase<UnitOfWork, PassengerDao, Guid>, IPassengersRepository
{
    protected PassengersRepository(UnitOfWork context) : base(context)
    {
    }
}