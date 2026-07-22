using Application.Features.Cars.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.Cars.Queries;

public record GetCarByIdQuery(string Id) : IRequest<CarDto?>;

public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarDto?>
{
    private readonly ICarRepository _carRepository;

    public GetCarByIdQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<CarDto?> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetOneCarAsync(request.Id, cancellationToken);

        if (car is null)
        {
            return null;
        }

        return car.Adapt<CarDto>();
    }
}