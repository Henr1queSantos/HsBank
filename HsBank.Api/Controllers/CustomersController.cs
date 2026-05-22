using HsBank.Application.Commands.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
}