using EMSI.Airbook.Infrastructure.DAO;

namespace EMSI.Airbook.Instraftructure.Abstractions;

public interface IEtudiantsRepository : ISupportsReadRepository<EtudiantDao, Guid>, ISupportsWriteRepository<EtudiantDao, Guid>
{
}