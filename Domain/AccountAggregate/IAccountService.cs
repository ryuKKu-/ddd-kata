using BuildingBlocks.Domain;

namespace Domain.AccountAggregate
{
    public interface IAccountService : IRepository<Account>
    {
        Task<Guid> Create(Account account);
    }
}
