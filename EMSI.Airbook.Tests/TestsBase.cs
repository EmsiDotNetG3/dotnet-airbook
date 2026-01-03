using AutoFixture;
using EMSi.Airbook;
using Mapster;
using MapsterMapper;

namespace EMSI.Airbook.Tests;

public abstract class TestsBase
{
    protected readonly IMapper Mapper;
    protected readonly Fixture Fixture;
    
    protected TestsBase()
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(Registration).Assembly);
        Mapper = new Mapper(config);
        
        Fixture = new Fixture();
    }
}