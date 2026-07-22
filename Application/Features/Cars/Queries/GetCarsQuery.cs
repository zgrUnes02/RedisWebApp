using Application.Features.Cars.DTOs;
using Application.Interfaces;
using Mapster;
using MediatR;

namespace Application.Features.Cars.Queries;

public record GetCarsQuery() : IRequest<List<CarDto>?>;

public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, List<CarDto>?>
{
    private readonly ICarRepository _carRepository;

    public GetCarsQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<List<CarDto>?> Handle(GetCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAllCarsAsync(cancellationToken);
        
        if(cars is null)
        {
            return null;
        }

        return cars.Adapt<List<CarDto>>();
    }
}