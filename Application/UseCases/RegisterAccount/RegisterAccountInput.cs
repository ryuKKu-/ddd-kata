using BuildingBlocks.Application;
using Domain.AccountAggregate;
using Domain.CustomerAggregate;

namespace Application.UseCases.RegisterAccount;

public record RegisterAccountInput(SSN SSN, Money Amount) : IUseCaseInput<Guid>;
