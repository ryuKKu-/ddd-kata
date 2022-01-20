using BuildingBlocks.Domain;

namespace Domain.CustomerAggregate
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task Add(Customer customer);

        Task<Customer> GetBySSN(SSN ssn);
    }
}
