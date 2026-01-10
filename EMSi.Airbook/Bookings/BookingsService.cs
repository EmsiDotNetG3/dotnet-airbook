using EMSI.Airbook.Domain.Abstractions;
using EMSI.Airbook.Domain.Models;
using EMSi.Airbook.Exceptions;
using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;
using MapsterMapper;

namespace EMSi.Airbook.Bookings;

internal class BookingsService : IBookingsService
{
    private readonly IBookingsRepository _bookingsRepository;
    private readonly IPassengersRepository _passengersRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookingsService(IBookingsRepository bookingsRepository, IPassengersRepository passengersRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _bookingsRepository = bookingsRepository;
        _passengersRepository = passengersRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task BookFlightAsync(Booking booking)
    {
        var dao = _mapper.Map<BookingDao>(booking);
        dao.Id = Guid.NewGuid();
        dao.BookingDate = DateTime.UtcNow;
        dao.CancellationDate = null;
        dao.CheckingDate = null;
        dao.Passenger = null;
        dao.Flight = null;
        
        await CheckPassengerAsync(dao.PassengerId);
        
        await _bookingsRepository.AddAsync(dao);
        await _unitOfWork.CommitAsync();
    }

    public async Task CancelFlightBookingAsync(Guid bookingId, Guid passengerId)
    {
        var booking = await GetBookingOrThrowErrorAsync(bookingId, passengerId);

        booking!.CancellationDate = DateTime.UtcNow;
        _bookingsRepository.Update(booking);
        await _unitOfWork.CommitAsync();
    }

    public async Task CheckingFlightBookingAsync(Guid bookingId, Guid passengerId, string passportNumber)
    {
        var booking = await GetBookingOrThrowErrorAsync(bookingId, passengerId);
        booking!.CheckingDate = DateTime.UtcNow;
        _bookingsRepository.Update(booking);
        
        var passenger = await CheckPassengerAsync(passengerId);

        passenger.PassportNumber = passportNumber;
        _passengersRepository.Update(passenger);
        
        await _unitOfWork.CommitAsync();
    }

    private async Task<PassengerDao?> CheckPassengerAsync(Guid passengerId)
    {
        var passenger = await _passengersRepository.GetByIdAsync(passengerId);
        if(passenger is null)
            throw new FunctionalException($"Passenger#{passengerId} not found", ExceptionTypeEnum.NotFound);
        return passenger;
    }

    private async Task<BookingDao?> GetBookingOrThrowErrorAsync(Guid bookingId, Guid passengerId)
    {
        var booking = await _bookingsRepository.GetByIdAsync(bookingId);
        if(booking is null)
            throw new FunctionalException($"Booking not found#{bookingId}", ExceptionTypeEnum.NotFound);
        
        if(booking.PassengerId != passengerId)
            throw new FunctionalException($"Booking#{bookingId} doesn't belong to passenger#{passengerId}", ExceptionTypeEnum.InvalidInput);
        
        return booking;
    }
}