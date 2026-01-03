namespace EMSI.Airbook.Infrastructure.DAO;

public class FlightDao
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
    public int Category { get; set; }
    public int Status { get; set; }
    public bool DirectFlight { get; set; }
}