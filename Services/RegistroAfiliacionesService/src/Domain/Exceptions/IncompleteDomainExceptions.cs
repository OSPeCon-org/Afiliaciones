using System;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class IncompleteDomainException : Exception
    {
        public IncompleteDomainException()
        { }

        public IncompleteDomainException(string message)
            : base(message)
        { }

        public IncompleteDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}