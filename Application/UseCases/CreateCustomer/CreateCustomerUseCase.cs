using BuildingBlocks.Application;
using Domain.CustomerAggregate;

namespace Application.UseCases.CreateCustomer
{
    public class CreateCustomerUseCase : IUseCase<CreateCustomerInput, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailSender _emailSender;

        public CreateCustomerUseCase(ICustomerRepository customerRepository, IEmailSender emailSender)
        {
            _customerRepository = customerRepository;
            _emailSender = emailSender;
        }

        public async Task<Guid> Handle(CreateCustomerInput input)
        {
            var customer = await _customerRepository.GetBySSN(input.SSN);

            if (customer != null)
                throw new InvalidOperationException($"Customer with SSN={customer.SSN} already exists");

            customer = new Customer(input.FirstName, input.LastName, input.SSN);
            await _customerRepository.Create(customer);

            await _emailSender.Send("john.doe@void.com", input.EmailAddress.ToString(), "Confirmation of account creation", "Welcome !");

            return customer.Id;
        }
    }
}
