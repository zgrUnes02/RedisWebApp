namespace Application.Dtos.Cars;

public record UpdateCarRequestDto(
    string Brand,
    string Model,
    int Year
);