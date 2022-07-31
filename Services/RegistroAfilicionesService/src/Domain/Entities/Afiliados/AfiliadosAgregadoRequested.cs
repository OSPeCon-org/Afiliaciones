using MediatR;
namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities
{

    public class AfiliadosAgregadoRequested : INotification
    {
        public Afiliados Afiliado { get; set; }
        public AfiliadosAgregadoRequested(Afiliados afiliado)
        {
            Afiliado = afiliado;
        }
    }

}
