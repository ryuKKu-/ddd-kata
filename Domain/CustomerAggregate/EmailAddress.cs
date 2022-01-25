using System.Text.RegularExpressions;
using BuildingBlocks.Domain;
using Domain.CustomerAggregate.Exceptions;

namespace Domain.CustomerAggregate
{
    public class EmailAddress : ValueObject
    {
        private const string RegExForValidation = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

        private readonly string _text;

        public EmailAddress(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new EmailAddressEmptyException($"The {nameof(text)} field is required.");
            }

            var regex = new Regex(RegExForValidation);
            var match = regex.Match(text);

            if (!match.Success)
            {
                throw new EmailAddressInvalidException($"Invalid {nameof(text)} format.");
            }

            _text = text;
        }

        /// <summary>
        /// Converts into string.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString() => _text;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _text;
        }
    }
}
