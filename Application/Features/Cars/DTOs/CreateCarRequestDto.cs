namespace Application.Features.Cars.DTOs;

public record CreateCarRequestDto(
    string Make,
    string Model,
    int Year
);