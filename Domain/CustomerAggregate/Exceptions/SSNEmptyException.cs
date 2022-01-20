using BuildingBlocks.Domain;

namespace Domain.CustomerAggregate.Exceptions
{
    public class SSNEmptyException : DomainException
    {
        public SSNEmptyException(string businessMessage) : base(businessMessage)
        {
        }
    }
}
