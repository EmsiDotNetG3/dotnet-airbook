using EMSI.Airbook.Domain.Abstractions;
using EMSI.Airbook.Domain.Models;
using EMSi.Airbook.Exceptions;
using EMSI.Airbook.Infrastructure.DAO;
using EMSI.Airbook.Instraftructure.Abstractions;
using MapsterMapper;

namespace EMSi.Airbook.Passengers;

internal class PassengersService : IPassengersService
{
    private readonly IPassengersRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public PassengersService(IPassengersRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task CreatePassengerAsync(Passenger passenger)
    {
        passenger.Id = Guid.NewGuid();
        var dao = _mapper.Map<PassengerDao>(passenger);
        await _repository.AddAsync(dao);
        await _unitOfWork.CommitAsync();
    }

    public async Task<Passenger> GetByIdAsync(Guid id)
    {
        var dao = await _repository.GetByIdAsync(id);
        if(dao is null)
            throw new FunctionalException($"Passenger#{id} not found", ExceptionTypeEnum.NotFound);
        
        return _mapper.Map<Passenger>(dao);
    }
}