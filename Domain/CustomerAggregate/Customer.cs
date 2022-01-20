using BuildingBlocks.Domain;

namespace Domain.CustomerAggregate
{
    public class Customer : Entity, IAggregateRoot
    {
        public string FirstName { get; }

        public string LastName { get; }

        public SSN SSN { get; }

        public Customer(string firstName, string lastName, SSN ssn)
        {
            FirstName = firstName;
            LastName = lastName;
            SSN = ssn;
        }
    }
}
