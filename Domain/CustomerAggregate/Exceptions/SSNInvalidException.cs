using BuildingBlocks.Domain;

namespace Domain.CustomerAggregate.Exceptions
{
    public class SSNInvalidException : DomainException
    {
        public SSNInvalidException(string businessMessage) : base(businessMessage)
        {
        }
    }
}
