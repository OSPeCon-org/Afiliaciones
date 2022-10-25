using MediatR;
namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{

    public class AfiliadosActualizadoRequested : INotification
    {
        public Afiliados Afiliado { get; set; }
        public AfiliadosActualizadoRequested(Afiliados afiliado)
        {
            Afiliado = afiliado;
        }
    }

}
