using Application.Dtos.Cars;
using Application.Features.Cars.DTOs;
using Application.Interfaces;
using Mapster;
using MediatR;

namespace Application.Features.Cars.Commands;

public record UpdateCarCommand(string Id, UpdateCarRequestDto UpdateCarRequest) : IRequest<CarDto?>;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, CarDto?>
{
    private readonly ICarRepository _carRepository;

    public UpdateCarCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<CarDto?> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.UpdateCarAsync(request.Id, request.UpdateCarRequest, cancellationToken);

        if(car is null)
        {
            return null;
        }

        return car.Adapt<CarDto>();
    }
}