using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;

namespace EMSI.Airbook.Infrastructure.Database.Absences;

internal class AbsencesRepository : RepositoryBase<UnitOfWork, AbsenceDao, Guid>, IAbsencesRepository
{
    public AbsencesRepository(UnitOfWork context) : base(context)
    {
    }
}