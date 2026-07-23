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

    public async Task<Car> CreateCarAsync(CreateCarRequestDto request, CancellationToken cancellationToken)
    {
        var car = new Car
        {
            Id = Guid.NewGuid(),
            Brand = request.Brand,
            Model = request.Model,
            Year = request.Year
        };

        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();

        return car;
    }

    public async Task<bool> DeleteCarAsync(string id, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(id, out var carId))
        {
            return false;
        }

        var deleteCar = await _context.Cars
            .Where(c => c.Id == carId)
            .ExecuteDeleteAsync(cancellationToken);

        return deleteCar > 0;
    }

    public async Task<List<Car>?> GetAllCarsAsync(CancellationToken cancellationToken)
    {
        var cars = await _context.Cars
            .AsNoTracking()
            .ToListAsync();
        return cars;
    }

    public async Task<Car?> GetOneCarAsync(string id, CancellationToken cancellationToken)
    {
        var car = await _context.Cars
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id.ToString() == id);
        return car;
    }

    public async Task<Car?> UpdateCarAsync(string id, UpdateCarRequestDto request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(id, out var carId))
        {
            return null;
        }

        var car = await _context.Cars
            .FirstOrDefaultAsync(c => c.Id == carId, cancellationToken);

        if (car is null)
        {
            return null;
        }

        // Update properties
        car.Brand = request.Brand;
        car.Model = request.Model;
        car.Year = request.Year;

        // Save asynchronously with cancellation token
        await _context.SaveChangesAsync(cancellationToken);

        return car;
    }
}
