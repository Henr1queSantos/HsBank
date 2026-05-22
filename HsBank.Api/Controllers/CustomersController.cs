using HsBank.Application.Commands.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HsBank.Application.Queries.Customers;

namespace HsBank.Api.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
    {
        var customerId = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateCustomer), new { id = customerId }, command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var query = new GetAllCustomersQuery();
        var customers = await _mediator.Send(query);
        
        return Ok(customers); 
    }
}