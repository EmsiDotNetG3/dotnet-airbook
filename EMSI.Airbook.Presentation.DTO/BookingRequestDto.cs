namespace EMSI.Airbook.Presentation.DTO;

public class BookingRequestDto
{
    public Guid FlightId { get; set; }
    public Guid PassengerId { get; set; }
    public decimal Price { get; set; }
    public int SeatNumber { get; set; }
    public int? NumberOfKg { get; set; }
}