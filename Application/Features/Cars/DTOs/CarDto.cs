namespace Application.Features.Cars.DTOs;

public record CarDto(
    Guid Id,
    string Brand,
    string Model,
    int Year
);
