using EMSI.Airbook.Infrastructure.DAO;

namespace EMSI.Airbook.Instraftructure.Abstractions;

public interface IAbsencesRepository : ISupportsReadRepository<AbsenceDao, Guid>, ISupportsWriteRepository<AbsenceDao, Guid>
{
}