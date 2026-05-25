using HsBank.Application.Commands.Loans;
using HsBank.Domain.Entities;
using HsBank.Domain.Repositories;
using Moq;
using Xunit;

namespace HsBank.Application.Tests.Commands;

public class CreateLoanCommandHandlerTests
{
    [Fact]
    public async Task Handle_Should_Create_Loan_And_Return_Id()
    {
        // 1. ARRANGE: Set up the scenario and our "fake" database
        var command = new CreateLoanCommand 
        { 
            CustomerId = Guid.NewGuid(), 
            Amount = 5000, 
            TermInMonths = 24 
        };

        var loanRepositoryMock = new Mock<ILoanRepository>();

        var handler = new CreateLoanCommandHandler(loanRepositoryMock.Object);

        // 2. ACT: Execute the method 
        var resultId = await handler.Handle(command, CancellationToken.None);

        // 3. ASSERT: Verify the outcome
        
        // Check that a real Guid was returned (not an empty one)
        Assert.NotEqual(Guid.Empty, resultId); 

        loanRepositoryMock.Verify(repo => repo.AddAsync(
            It.IsAny<Loan>(), 
            It.IsAny<CancellationToken>()), 
            Times.Once);
    }
}