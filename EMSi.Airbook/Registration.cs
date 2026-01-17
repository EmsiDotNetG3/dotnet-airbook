using EMSi.Airbook.Absences;
using EMSi.Airbook.Bookings;
using EMSI.Airbook.Domain.Abstractions;
using EMSi.Airbook.Flights;
using EMSi.Airbook.Passengers;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace EMSi.Airbook;

public static class Registration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        //services
        services.AddScoped<IPassengersService, PassengersService>();
        services.AddScoped<IFlightsService, FlightsService>();
        services.AddScoped<IBookingsService, BookingsService>();
        services.AddScoped<IAbsencesService, AbsencesService>();
        
        //mapster
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(Registration).Assembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, Mapper>();
        
        return services;
    }
}