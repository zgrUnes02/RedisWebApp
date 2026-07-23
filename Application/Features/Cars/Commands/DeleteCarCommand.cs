using Application.Interfaces;
using MediatR;

namespace Application.Features.Cars.Commands;

public record DeleteCarCommand(string Id) : IRequest<bool>;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, bool>
{
    private readonly ICarRepository _carRepository;

    public DeleteCarCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<bool> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        bool carDeleted = await _carRepository.DeleteCarAsync(request.Id, cancellationToken);
        return carDeleted;
    }
}