using System.Text.RegularExpressions;
using BuildingBlocks.Domain;
using Domain.CustomerAggregate.Exceptions;

namespace Domain.CustomerAggregate
{
    public class SSN : ValueObject
    {
        private const string RegExForValidation = @"^\d{6,8}[-|(\s)]{0,1}\d{4}$";

        private readonly string _text;

        public SSN(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new SSNEmptyException($"The {nameof(text)} field is required.");
            }

            var regex = new Regex(RegExForValidation);
            var match = regex.Match(text);

            if (!match.Success)
            {
                throw new SSNInvalidException($"Invalid {nameof(text)} format. Use YYMMDDNNNN.");
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
