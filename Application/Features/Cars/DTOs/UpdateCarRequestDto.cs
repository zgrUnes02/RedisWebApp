namespace Application.Dtos.Cars;

public record UpdateCarRequestDto(
    string Make,
    string Model,
    int Year
);