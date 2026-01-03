using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;

namespace EMSI.Airbook.Infrastructure.Database.PassengerDetails;

internal class PassengerDetailsRepository : RepositoryBase<UnitOfWork, PassengerDetailsDao, Guid>, IPassengerDetailsRepository
{
    public PassengerDetailsRepository(UnitOfWork context) : base(context)
    {
    }
}