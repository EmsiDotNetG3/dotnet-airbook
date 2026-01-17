using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;

namespace EMSI.Airbook.Infrastructure.Database.Etudiants;

internal class EtudiantsRepository : RepositoryBase<UnitOfWork, EtudiantDao, Guid>, IEtudiantsRepository
{
    public EtudiantsRepository(UnitOfWork context) : base(context)
    {
    }
}