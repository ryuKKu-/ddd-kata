using BuildingBlocks.Application;
using Domain.CustomerAggregate;

namespace Application.UseCases.Register;

public record RegisterCustomerInput(string FirstName, string LastName, SSN SSN) : IUseCaseInput<Guid>
{
}