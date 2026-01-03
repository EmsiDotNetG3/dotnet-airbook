namespace EMSI.Airbook.Domain.Models;

public class Flight
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
    public FlightCategoryEnum Category { get; set; }
    public FlightStatusEnum Status { get; set; }
}