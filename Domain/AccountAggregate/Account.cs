using BuildingBlocks.Domain;

namespace Domain.AccountAggregate
{
    public class Account : Entity, IAggregateRoot
    {
        public Guid CustomerId { get; }

        private List<ITransaction> _transactions;
        public IReadOnlyList<ITransaction> Transactions => _transactions.AsReadOnly();

        public Account(Guid customerId, Money initialDeposit)
        {
            CustomerId = customerId;
        }

        public void Deposit(Money amount, string description)
        {
            _transactions.Add(new Credit(Id, amount, description));
        }
    }


    public interface ITransaction
    {
        public Money Amount { get; }
        public string Description { get; }
        public DateTime Date { get; }
    }

    public class Credit : Entity, ITransaction
    {
        public Guid AccountId { get; }
        public Money Amount { get; }
        public string Description { get; }
        public DateTime Date { get; }

        public Credit(Guid accountId, Money amount, string description)
        {
            AccountId = accountId;
            Amount = amount;
            Description = description;
            Date = DateTime.UtcNow;
        }
    }
}
