namespace Domain.Entities;

public class Car
{
    public Guid Id { get; set; }

    public string Brand { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public int Year { get; set; } = DateTime.Now.Year;
}
