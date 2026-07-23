namespace Application.Features.Cars.DTOs;

public record CreateCarRequestDto(
    string Brand,
    string Model,
    int Year
);