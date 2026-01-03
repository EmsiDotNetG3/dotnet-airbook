using EMSI.Airbook.Domain.Models;

namespace EMSI.Airbook.Domain.Abstractions;

public interface IBookingsService
{
    Task BookFlightAsync(Booking booking);
    Task CancelFlightBookingAsync(Guid bookingId, Guid passengerId);
    Task CheckingFlightBookingAsync(Guid bookingId, Guid passengerId, string passportNumber);
}