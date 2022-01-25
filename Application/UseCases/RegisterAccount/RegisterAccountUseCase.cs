using BuildingBlocks.Application;
using Domain.AccountAggregate;
using Domain.CustomerAggregate;

namespace Application.UseCases.RegisterAccount
{
    public class RegisterAccountUseCase : IUseCase<RegisterAccountInput, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountService _accountService;

        public RegisterAccountUseCase(ICustomerRepository customerRepository, IAccountService accountService)
        {
            _customerRepository = customerRepository;
            _accountService = accountService;
        }

        public async Task<Guid> Handle(RegisterAccountInput input)
        {
            var customer = _customerRepository.GetBySSN(input.SSN);

            if (customer == null)
                throw new ApplicationException();

            var account = new Account();
            await _accountService.Create(account);

            return account.Id;
        }
    }
}
