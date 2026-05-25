using FluentValidation;
using HsBank.Api.Middlewares;
using HsBank.Application.Commands.Customers;
using HsBank.Domain.Repositories;
using HsBank.Infrastructure.Persistence;
using HsBank.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<HsBankDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

builder.Services.AddValidatorsFromAssembly(typeof(CreateCustomerCommand).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(HsBank.Application.Behaviors.ValidationBehavior<,>));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();