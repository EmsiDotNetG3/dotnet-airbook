using EMSI.Airbook.Domain.Abstractions;
using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Presentation.DTO;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
namespace EMSI.Airbook.WebAPI.Controllers;

[Route("[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingsService _bookingsService;
    private readonly IMapper _mapper;

    public BookingsController(IBookingsService bookingsService, IMapper mapper)
    {
        _bookingsService = bookingsService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] BookingRequestDto request)
    {
        await _bookingsService.BookFlightAsync(_mapper.Map<Booking>(request));
        return Ok();
    }
}