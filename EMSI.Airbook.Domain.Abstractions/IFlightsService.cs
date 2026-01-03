using EMSI.Airbook.Domain.Models;

namespace EMSI.Airbook.Domain.Abstractions;

public interface IFlightsService
{
    Task<IReadOnlyCollection<Flight>> SearchFlightsAsync(string departureFrom, string arrivalTo, DateOnly departureDate, DateOnly? returnDate, bool directFlightsOnly);
}