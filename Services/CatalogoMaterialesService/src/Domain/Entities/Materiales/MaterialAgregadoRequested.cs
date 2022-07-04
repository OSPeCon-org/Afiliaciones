using MediatR;
namespace OSPeConTI.Afiliaciones.Services.CatalogoMateriales.Domain.Entities
{

    public class MaterialAgregadoRequested : INotification
    {
        public Material Material { get; set; }
        public MaterialAgregadoRequested(Material material)
        {
            Material = material;
        }
    }

}
