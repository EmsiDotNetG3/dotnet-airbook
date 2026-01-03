using AutoFixture.Xunit2;
using EMSi.Airbook.Bookings;
using EMSI.Airbook.Domain.Models;
using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;
using Moq;
using Xunit;

namespace EMSI.Airbook.Tests;

public class BookingsServiceTests : TestsBase
{
    //System under test
    private readonly BookingsService _sut;

    private readonly Mock<IBookingsRepository> _bookingsRepositoryMock = new();
    private readonly Mock<IPassengersRepository> _passengersRepositoryMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    
    public BookingsServiceTests()
    {
        _bookingsRepositoryMock = new Mock<IBookingsRepository>();
        _sut = new BookingsService(_bookingsRepositoryMock.Object,
            _passengersRepositoryMock.Object, _unitOfWorkMock.Object, Mapper);
    }

    [Theory]
    [AutoData]
    public async Task BookFlightAsync_ValidBooking_Ok(Booking booking)
    {
        //act
        await _sut.BookFlightAsync(booking);
        
        //assert
        _bookingsRepositoryMock.Verify(m => m.AddAsync(It.IsAny<BookingDao>()), Times.Once);
        _unitOfWorkMock.Verify(m => m.CommitAsync(), Times.Once);
    }

    [Theory]
    [AutoData]
    public async Task CancelFlightBookingAsync_ValidData_Ok(BookingDao bookingDao, PassengerDao passengerDao)
    {
        //arrange
        bookingDao.PassengerId = passengerDao.Id;
        bookingDao.Passenger = passengerDao;
        
        _bookingsRepositoryMock.Setup(m => m.GetByIdAsync(bookingDao.Id)).ReturnsAsync(bookingDao);
        _passengersRepositoryMock.Setup(m => m.GetByIdAsync(passengerDao.Id)).ReturnsAsync(passengerDao);
        
        //act
        await _sut.CancelFlightBookingAsync(bookingDao.Id, passengerDao.Id);

        //assert
        _bookingsRepositoryMock.Verify(m => m.Update(It.IsAny<BookingDao>()), Times.Once);
        _unitOfWorkMock.Verify(m => m.CommitAsync(), Times.Once);
    }
    
    [Theory]
    [AutoData]
    public async Task CheckingFlightBookingAsync_ValidData_Ok(BookingDao bookingDao, PassengerDao passengerDao, string passportNumber)
    {
        //arrange
        bookingDao.PassengerId = passengerDao.Id;
        bookingDao.Passenger = passengerDao;
        
        _bookingsRepositoryMock.Setup(m => m.GetByIdAsync(bookingDao.Id)).ReturnsAsync(bookingDao);
        _passengersRepositoryMock.Setup(m => m.GetByIdAsync(passengerDao.Id)).ReturnsAsync(passengerDao);
        
        //act
        await _sut.CheckingFlightBookingAsync(bookingDao.Id, passengerDao.Id, passportNumber);

        //assert
        _bookingsRepositoryMock.Verify(m => m.Update(It.IsAny<BookingDao>()), Times.Once);
        _passengersRepositoryMock.Verify(m => m.Update(It.IsAny<PassengerDao>()), Times.Once);
        _unitOfWorkMock.Verify(m => m.CommitAsync(), Times.Once);
    }
}