using EMSI.Airbook.Infrastructure.Database.Bookings;
using EMSI.Airbook.Infrastructure.Database.Flights;
using EMSI.Airbook.Infrastructure.Database.PassengerDetails;
using EMSI.Airbook.Infrastructure.Database.Passengers;
using EMSI.Airbook.Instraftructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EMSI.Airbook.Infrastructure.Database;

public static class Registration
{
    public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services, string connectionString)
    {
        // create all objects in IOS container
        
        //Repositories
        services.AddScoped<IPassengersRepository, PassengersRepository>();
        services.AddScoped<IPassengerDetailsRepository, PassengerDetailsRepository>();
        services.AddScoped<IBookingsRepository, BookingsRepository>();
        services.AddScoped<IFlightsRepository, FlightsRepository>();
        
        //Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>(provider => provider.GetRequiredService<UnitOfWork>());
        
        //Db Context
        services.AddDbContext<UnitOfWork>(options => options.UseNpgsql(connectionString));
        return services;
    }
}