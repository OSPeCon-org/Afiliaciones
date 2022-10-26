using System;
using Newtonsoft.Json;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;


namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class Email : SingleValueObject<string>
    {

        public Email(string value) : base(value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(Email) + " value");
            if (!IsValid(value))
                throw new IncompleteDomainException();
        }

        private bool IsValid(string value)
        {
            if (value.Contains(" ")) return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(value);
                return addr.Address == value;
            }
            catch
            {
                return false;
            }
        }
    }
}