using BuildingBlocks.Domain;

namespace Domain.CustomerAggregate
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task Create(Customer customer);

        Task<Customer> GetBySSN(SSN ssn);
    }
}
