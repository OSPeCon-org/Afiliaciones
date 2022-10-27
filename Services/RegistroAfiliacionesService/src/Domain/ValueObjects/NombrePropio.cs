using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class NombrePropio : SingleValueObject<string>
    {

        public NombrePropio(string value) : base(value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(NombrePropio) + " value");
            if (!IsValid(value))
                throw new IncompleteDomainException();
        }

        private bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            // start with a letter, allow letter , length between 2 to 254.
            string pattern = @"[a-zA-Z ]{2,254}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(value)) return false;
            return true;
        }
    }
}