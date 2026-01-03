using EMSI.Airbook.Domain.Abstractions;
using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Instraftructure.Abstractions;
using MapsterMapper;

namespace EMSi.Airbook.Flights;

internal class FlightsService : IFlightsService
{
    private readonly IFlightsRepository _flightsRepository;
    private readonly IMapper _mapper;

    public FlightsService(IFlightsRepository flightsRepository, IMapper mapper)
    {
        _flightsRepository = flightsRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<Flight>> SearchFlightsAsync(string departureFrom, string arrivalTo, DateOnly departureDate, DateOnly? returnDate,
        bool directFlightsOnly)
    {
        var departureDateTime = departureDate.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
        var flightsQuery = _flightsRepository.GetAllQueryable()
            .Where(f => f.DepartureFrom == departureFrom
                && f.ArrivalTo == arrivalTo
                && f.DepartureDate.Date == departureDateTime);
        
        if(directFlightsOnly)
            flightsQuery = flightsQuery.Where(f => f.DirectFlight);
        
        var flightsDao = await flightsQuery.ToAsyncEnumerable().ToListAsync();
            
        var flights = flightsDao.Select(f => _mapper.Map<Flight>(f)).ToList();

        if (returnDate is not null)
        {
            var returnFlights = await SearchFlightsAsync(arrivalTo, departureFrom, returnDate.Value, null, directFlightsOnly);
            flights.AddRange(returnFlights);
        }

        return flights;
    }
}