#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace EMSI.Airbook.Infrastructure.DAO;

public class PassengerDetailsDao : EntityBase<Guid>
{
    public Guid PassengerId { get; set; }
    public PassengerDao Passenger { get; set; }
    public int TotalReservations { get; set; }
    public DateTime LastBookingDate { get; set; }
    public decimal TotalSpent { get; set; }
}