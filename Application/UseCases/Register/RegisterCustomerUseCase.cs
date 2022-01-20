using BuildingBlocks.Application;
using Domain.CustomerAggregate;

namespace Application.UseCases.Register
{
    public class RegisterCustomerUseCase : IUseCase<RegisterCustomerInput, Guid>
    {
        private readonly ICustomerRepository _customerRepository;

        public RegisterCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(RegisterCustomerInput input)
        {
            var customer = await _customerRepository.GetBySSN(input.SSN);

            if (customer != null)
                throw new InvalidOperationException($"Customer with SSN={customer.SSN} already exists");

            customer = new Customer(input.FirstName, input.LastName, input.SSN);
            await _customerRepository.Add(customer);

            return customer.Id;
        }
    }
}
