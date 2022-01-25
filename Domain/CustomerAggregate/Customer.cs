using BuildingBlocks.Domain;

namespace Domain.CustomerAggregate
{
    public class Customer : Entity, IAggregateRoot
    {
        public string FirstName { get; }

        public string LastName { get; }

        public SSN SSN { get; }

        private List<Guid> _accounts;
        public IReadOnlyList<Guid> Accounts => _accounts.AsReadOnly();

        private Customer()
        {
            _accounts = new List<Guid>();
        }

        public Customer(string firstName, string lastName, SSN ssn) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            SSN = ssn;
        }
    }
}
