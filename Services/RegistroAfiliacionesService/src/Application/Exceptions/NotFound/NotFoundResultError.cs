using System;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Attributes;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Middlewares;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Exceptions
{
    public class NotFoundResultError : IResultError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        [NotShowInProduction]
        public string Detail { get; set; }
        public string ID { get; set; }

        public void Map(Exception ex)
        {
            Message = ex.Message;
            StatusCode = 404;
            Detail = ex.StackTrace;
            ID = ((INotFoundException)ex).ID;
        }

    }


}