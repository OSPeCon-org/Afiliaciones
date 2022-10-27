using System;
using Newtonsoft.Json;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;
namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class Cuit : SingleValueObject<string>
    {

        public Cuit(string value) : base(value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(Cuit) + " value");
            if (!IsValid(value))
                throw new IncompleteDomainException("CUIT Inválido");
        }

        private bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            if (value.Length != 11) throw new ArgumentException(nameof(value));
            bool rv = false;
            int verificador;
            int resultado = 0;
            string cuit_nro = value.Replace("-", string.Empty);
            string codes = "6789456789";
            long cuit_long = 0;
            if (long.TryParse(cuit_nro, out cuit_long))
            {
                verificador = int.Parse(cuit_nro[cuit_nro.Length - 1].ToString());
                int x = 0;
                while (x < 10)
                {
                    int digitoValidador = int.Parse(codes.Substring((x), 1));
                    int digito = int.Parse(cuit_nro.Substring((x), 1));
                    int digitoValidacion = digitoValidador * digito;
                    resultado += digitoValidacion;
                    x++;
                }
                resultado = resultado % 11;
                rv = (resultado == verificador);
            }
            return rv;

        }
    }
}