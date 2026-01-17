namespace EMSI.Airbook.Infrastructure.DAO;

public class AbsenceDao : EntityBase<Guid>
{
    public DateTime DateAbsence { get; set; }
    public bool Justifie { get; set; }
    public string Justification { get; set; }
    public Guid EtudiantId { get; set; }
    public EtudiantDao Etudiant { get; set; }
}