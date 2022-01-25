using BuildingBlocks.Application;
using Domain.CustomerAggregate;

namespace Application.UseCases.CreateCustomer;

public record CreateCustomerInput(string FirstName, string LastName, SSN SSN, EmailAddress EmailAddress) : IUseCaseInput<Guid>;