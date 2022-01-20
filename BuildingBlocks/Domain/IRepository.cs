namespace BuildingBlocks.Domain
{
    public interface IRepository<T> : IUnitOfWork where T : IAggregateRoot
    {
    }
}
