namespace EMSI.Airbook.Domain.Models;

public class Absence
{
    public Guid Id { get; set; }
    public DateTime DateAbsence { get; set; }
    public bool Justifie { get; set; }
    public string Justification { get; set; }
    public Etudiant Etudiant { get; set; }
}