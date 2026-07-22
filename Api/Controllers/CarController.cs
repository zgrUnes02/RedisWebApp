using Application.Features.Cars.DTOs;
using Application.Features.Cars.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/cars")]
public class CarController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CarDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CarDto>>> GetAllCars(CancellationToken cancellationToken)
    {
        var cars = await _mediator.Send(new GetCarsQuery(), cancellationToken);
        return Ok(cars ?? new List<CarDto>());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CarDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CarDto>> GetCarById(string id, CancellationToken cancellationToken)
    {
        var car = await _mediator.Send(new GetCarByIdQuery(id), cancellationToken);
        return car is not null ? Ok(car) : NotFound();
    }
}