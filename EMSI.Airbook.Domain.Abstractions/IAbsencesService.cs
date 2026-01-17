using EMSI.Airbook.Domain.Models;

namespace EMSI.Airbook.Domain.Abstractions;

public interface IAbsencesService
{
    Task DeclarerAbsenceAsync(Absence absence);
    Task<IReadOnlyCollection<Absence>> GetAbsencesByEtudiantIdAsync(Guid etudiantId);
}