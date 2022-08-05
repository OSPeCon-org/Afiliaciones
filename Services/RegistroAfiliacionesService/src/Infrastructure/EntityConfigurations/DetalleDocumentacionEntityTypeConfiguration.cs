using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class DetalleDocumentacionEntityTypeConfiguration : IEntityTypeConfiguration<DetalleDocumentacion>
    {
        public void Configure(EntityTypeBuilder<DetalleDocumentacion> DetalleDocumentacionConfiguration)
        {
            DetalleDocumentacionConfiguration.ToTable("DetalleDocumentacion", AfiliacionesContext.DEFAULT_SCHEMA);

            DetalleDocumentacionConfiguration.HasKey(o => o.Id);

            DetalleDocumentacionConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}