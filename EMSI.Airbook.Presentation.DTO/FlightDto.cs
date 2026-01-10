#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace EMSI.Airbook.Presentation.DTO;

public class FlightDto
{
    public Guid Id { get; set; }
    public string DepartureFrom { get; set; }
    public string ArrivalTo { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public int TotalSeats { get; set; }
    public int AvailableSeats { get; set; }
    public decimal Price { get; set; }
    public int PlaneNumber { get; set; }
    public bool DirectFlight { get; set; }
    public FlightCategoryEnumDto Category { get; set; }
    public FlightStatusEnumDto Status { get; set; }
}