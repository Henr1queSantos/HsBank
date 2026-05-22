using HsBank.Application.Commands.Loans;
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
}