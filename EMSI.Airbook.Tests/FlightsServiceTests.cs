using AutoFixture;
using AutoFixture.Xunit2;
using EMSi.Airbook.Flights;
using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;
using Moq;
using Xunit;

namespace EMSI.Airbook.Tests;

public class FlightsServiceTests : TestsBase
{
    //System under test
    private readonly FlightsService _sut;
    
    private readonly Mock<IFlightsRepository> _flightsRepositoryMock = new();

    public FlightsServiceTests()
    {
        _sut = new FlightsService(_flightsRepositoryMock.Object, Mapper);
    }

    [Theory]
    [AutoData]
    public async Task SearchFlightsAsync_DepartureOnly_ReturnsFlights(string departureFrom, string arrivalTo, DateTime departureDateTime, bool directFlightsOnly)
    {
        //arrange
        var flights = Fixture.Build<FlightDao>().CreateMany(5).ToList();
        _flightsRepositoryMock.Setup(x => x.GetAllQueryable()).Returns(flights.AsQueryable());
        var departureDate = DateOnly.FromDateTime(departureDateTime);
        
        flights[0].DepartureDate = departureDateTime;
        flights[0].DepartureFrom = departureFrom;
        flights[0].ArrivalTo = arrivalTo;
        
        if(directFlightsOnly)
            flights[0].DirectFlight = true;
        
        //act
        var actual = await _sut.SearchFlightsAsync(departureFrom, arrivalTo, departureDate, null, directFlightsOnly);
        
        //assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
        Assert.Single(actual);
    }
    
    [Theory]
    [AutoData]
    public async Task SearchFlightsAsync_RoundTrip_ReturnsFlights(string departureFrom, string arrivalTo, DateTime departureDateTime, DateTime returnDateTime, bool directFlightsOnly)
    {
        //arrange
        var flights = Fixture.Build<FlightDao>().CreateMany(5).ToList();
        _flightsRepositoryMock.Setup(x => x.GetAllQueryable()).Returns(flights.AsQueryable());
        var departureDate = DateOnly.FromDateTime(departureDateTime);
        var returnDate = DateOnly.FromDateTime(returnDateTime);
        
        //departure
        flights[0].DepartureDate = departureDateTime;
        flights[0].DepartureFrom = departureFrom;
        flights[0].ArrivalTo = arrivalTo;
        
        if(directFlightsOnly)
            flights[0].DirectFlight = true;
        
        //return
        flights[1].DepartureDate = returnDateTime;
        flights[1].DepartureFrom = arrivalTo;
        flights[1].ArrivalTo = departureFrom;
        
        if(directFlightsOnly)
            flights[1].DirectFlight = true;
        
        //act
        var actual = await _sut.SearchFlightsAsync(departureFrom, arrivalTo, departureDate, returnDate, directFlightsOnly);
        
        //assert
        Assert.NotNull(actual);
        Assert.NotEmpty(actual);
        Assert.Equal(2, actual.Count);
    }
}