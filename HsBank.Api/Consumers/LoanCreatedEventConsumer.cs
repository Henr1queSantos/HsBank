using HsBank.Application.Events;
using MassTransit;

namespace HsBank.Api.Consumers;

public class LoanCreatedEventConsumer : IConsumer<LoanCreatedEvent>
{
    private readonly ILogger<LoanCreatedEventConsumer> _logger;

    public LoanCreatedEventConsumer(ILogger<LoanCreatedEventConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<LoanCreatedEvent> context)
    {
        var message = context.Message;

        // Simulate sending an email or processing the loan asynchronously
        _logger.LogInformation("==============================================");
        _logger.LogInformation("RABBITMQ MESSAGE RECEIVED!");
        _logger.LogInformation("Processing Loan Approval for Customer: {CustomerId}", message.CustomerId);
        _logger.LogInformation("Loan Amount: ${Amount}", message.Amount);
        
        await Task.Delay(2000); // Simulate network delay for an email API
        
        _logger.LogInformation("Email successfully sent to customer!");
        _logger.LogInformation("==============================================");
    }
}