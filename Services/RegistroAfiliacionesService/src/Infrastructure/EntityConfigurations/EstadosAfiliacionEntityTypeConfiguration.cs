using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class EstadosAfiliacionEntityTypeConfiguration : IEntityTypeConfiguration<EstadosAfiliacion>
    {
        public void Configure(EntityTypeBuilder<EstadosAfiliacion> EstadosAfiliacionConfiguration)
        {
            EstadosAfiliacionConfiguration.ToTable("EstadosAfiliacion", AfiliacionesContext.DEFAULT_SCHEMA);

            EstadosAfiliacionConfiguration.HasKey(o => o.Id);

            EstadosAfiliacionConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}