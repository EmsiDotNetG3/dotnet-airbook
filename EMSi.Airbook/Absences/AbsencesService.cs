using EMSI.Airbook.Domain.Abstractions;
using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;
using MapsterMapper;

namespace EMSi.Airbook.Absences;

public class AbsencesService : IAbsencesService
{
    private readonly IAbsencesRepository _absencesRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AbsencesService(IAbsencesRepository absencesRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _absencesRepository = absencesRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task DeclarerAbsenceAsync(Absence absence)
    {
        var dao = _mapper.Map<AbsenceDao>(absence);
        dao.Id = Guid.NewGuid();
        dao.Etudiant = null;
        dao.DateAbsence = DateTime.UtcNow;
        await _absencesRepository.AddAsync(dao);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IReadOnlyCollection<Absence>> GetAbsencesByEtudiantIdAsync(Guid etudiantId)
    {
        var query = _absencesRepository.GetAllQueryable()
            .Where(x => x.EtudiantId.Equals(etudiantId));

        var list = await query.ToAsyncEnumerable().ToListAsync();
        return _mapper.Map<IReadOnlyCollection<Absence>>(list);
    }
}