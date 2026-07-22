using Application.Dtos.Cars;
using Application.Features.Cars.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _context;

    public CarRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Car> CreateCarAsync(CreateCarRequestDto car, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCarAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Car>?> GetAllCarsAsync(CancellationToken cancellationToken)
    {
        var cars = await _context.Cars.ToListAsync();
        return cars;
    }

    public async Task<Car?> GetOneCarAsync(string id, CancellationToken cancellationToken)
    {
        var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id.ToString() == id);
        return car;
    }

    public Task<Car> UpdateCarAsync(string id, UpdateCarRequestDto car, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
