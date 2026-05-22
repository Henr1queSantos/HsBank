using HsBank.Application.Commands.Loans;
using HsBank.Application.Queries.Loans;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HsBank.Api.Controllers;

[ApiController]
[Route("api/[controller]")] // This maps to URL: /api/loans
public class LoansController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoansController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLoan([FromBody] CreateLoanCommand command)
    {
        var loanId = await _mediator.Send(command);

        return CreatedAtAction(nameof(CreateLoan), new { id = loanId }, command);
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetLoansByCustomer(Guid customerId)
    {
        var query = new GetLoansByCustomerQuery(customerId);
        var loans = await _mediator.Send(query);

        return Ok(loans);
    }
}