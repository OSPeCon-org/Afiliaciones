using System;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Attributes;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Middlewares
{
    public class BasicResultError : IResultError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        [NotShowInProduction]
        public string Detail { get; set; }

        public void Map(Exception ex)
        {
            Message = ex.Message;
            StatusCode = 500;
            Detail = ex.StackTrace;
        }
    }
}
