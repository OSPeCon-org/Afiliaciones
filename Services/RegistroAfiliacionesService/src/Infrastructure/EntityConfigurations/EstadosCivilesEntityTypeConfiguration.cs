using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class EstadosCivilesEntityTypeConfiguration : IEntityTypeConfiguration<EstadosCiviles>
    {
        public void Configure(EntityTypeBuilder<EstadosCiviles> EstadosCivilesConfiguration)
        {
            EstadosCivilesConfiguration.ToTable("EstadosCiviles", AfiliacionesContext.DEFAULT_SCHEMA);

            EstadosCivilesConfiguration.HasKey(o => o.Id);

            EstadosCivilesConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}