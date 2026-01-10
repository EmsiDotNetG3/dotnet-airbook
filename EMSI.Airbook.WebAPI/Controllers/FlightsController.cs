using EMSI.Airbook.Domain.Abstractions;
using EMSI.Airbook.Presentation.DTO;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace EMSI.Airbook.WebAPI.Controllers;

[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly IFlightsService _flightsService;
    private readonly IMapper _mapper;
    
    public FlightsController(IFlightsService flightsService, IMapper mapper)
    {
        _flightsService = flightsService;
        _mapper = mapper;
    }
    
    [HttpPost("search")]
    public async Task<IActionResult> SearchFlightsAsync([FromBody]FlightSearchRequestDto request)
    {
        var flights = await _flightsService.SearchFlightsAsync(
            request.DepartureFrom,
            request.ArrivalTo,
            request.DepartureDate,
            request.ReturnDate,
            request.DirectFlights);

        if (flights.Count == 0)
            return NoContent();
        
        return OkEncapsulated(_mapper.Map<IEnumerable<FlightDto>>(flights));
    }
}