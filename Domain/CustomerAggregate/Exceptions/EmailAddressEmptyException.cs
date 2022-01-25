using BuildingBlocks.Domain;

namespace Domain.CustomerAggregate.Exceptions;

public class EmailAddressEmptyException : DomainException
{
    public EmailAddressEmptyException(string businessMessage) : base(businessMessage)
    {
    }
}