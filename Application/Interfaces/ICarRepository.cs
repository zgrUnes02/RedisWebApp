using Application.Dtos.Cars;
using Application.Features.Cars.DTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface ICarRepository
{
    Task<List<Car>?> GetAllCarsAsync(CancellationToken cancellationToken);
    Task<Car?> GetOneCarAsync(string id, CancellationToken cancellationToken);
    Task<Car> CreateCarAsync(CreateCarRequestDto car, CancellationToken cancellationToken);
    Task<Car?> UpdateCarAsync(string id, UpdateCarRequestDto car, CancellationToken cancellationToken);
    Task<bool> DeleteCarAsync(string id, CancellationToken cancellationToken);
}
