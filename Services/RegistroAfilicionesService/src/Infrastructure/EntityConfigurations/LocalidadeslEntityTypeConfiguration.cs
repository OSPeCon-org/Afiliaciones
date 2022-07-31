using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class LocalidadesEntityTypeConfiguration : IEntityTypeConfiguration<Localidades>
    {
        public void Configure(EntityTypeBuilder<Localidades> LocalidadesConfiguration)
        {
            LocalidadesConfiguration.ToTable("Localidades", AfiliacionesContext.DEFAULT_SCHEMA);

            LocalidadesConfiguration.HasKey(o => o.Id);

            LocalidadesConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}