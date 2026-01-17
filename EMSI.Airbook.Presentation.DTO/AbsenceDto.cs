namespace EMSI.Airbook.Presentation.DTO;

public class AbsenceDto
{
    public Guid Id { get; set; }
    public DateTime DateAbsence { get; set; }
    public bool Justifie { get; set; }
    public string Justification { get; set; }
    public EtudiantDto Etudiant { get; set; }
}