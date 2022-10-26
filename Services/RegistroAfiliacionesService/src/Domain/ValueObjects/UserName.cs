using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class UserName : SingleValueObject<string>
    {

        public UserName(string value) : base(value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(UserName) + " value");
            if (!IsValid(value))
                throw new IncompleteDomainException();
        }

        private bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            // start with a letter, allow letter or number, length between 6 to 12.
            string pattern = @"^[a-zA-Z][a-zA-Z0-9]{5,11}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(value)) return false;
            return true;
        }
    }
}