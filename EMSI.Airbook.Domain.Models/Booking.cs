#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace EMSI.Airbook.Domain.Models;

public class Booking
{
    public Guid Id { get; set; }
    public DateTime BookingDate { get; set; }
    public Flight Flight { get; set; }
    public Passenger Passenger { get; set; }
    public decimal Price { get; set; }
    public int SeatNumber { get; set; }
    public int? NumberOfKg { get; set; }
    public DateTime? CheckingDate { get; set; }
    public DateTime? CancellationDate { get; set; }
}