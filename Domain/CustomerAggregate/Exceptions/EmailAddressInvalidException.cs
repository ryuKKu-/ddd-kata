using BuildingBlocks.Domain;

namespace Domain.CustomerAggregate.Exceptions
{
    public class EmailAddressInvalidException : DomainException
    {
        public EmailAddressInvalidException(string businessMessage) : base(businessMessage)
        {
        }
    }
}
