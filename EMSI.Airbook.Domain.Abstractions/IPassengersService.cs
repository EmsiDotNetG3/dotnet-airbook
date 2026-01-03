using EMSI.Airbook.Domain.Models;

namespace EMSI.Airbook.Domain.Abstractions;

public interface IPassengersService
{
    public Task CreatePassengerAsync(Passenger passenger);
    public Task<Passenger> GetByIdAsync(Guid id);
}