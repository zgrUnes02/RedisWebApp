using Application.Features.Cars.DTOs;
using Application.Interfaces;
using Mapster;
using MediatR;

namespace Application.Features.Cars.Commands;

public record CreateCarCommand(CreateCarRequestDto CreateCarRequest) : IRequest<CarDto>;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CarDto>
{
    private readonly ICarRepository _carRepository;

    public CreateCarCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<CarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.CreateCarAsync(request.CreateCarRequest, cancellationToken);
        return car.Adapt<CarDto>();
    }
}