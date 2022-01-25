using BuildingBlocks.Domain;

namespace Domain.AccountAggregate
{
    public class Money : ValueObject
    {
        public decimal Amount { get; }

        public Money(decimal amount)
        {
            Amount = amount;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Math.Round(Amount, 2);
        }
    }
}
