namespace EMSI.Airbook.Presentation.DTO;

public class FlightSearchRequestDto
{
    public DateOnly DepartureDate { get; set; }
    public DateOnly? ReturnDate { get; set; }
    public string DepartureFrom { get; set; }
    public string ArrivalTo { get; set; }
    public bool DirectFlights { get; set; }
}