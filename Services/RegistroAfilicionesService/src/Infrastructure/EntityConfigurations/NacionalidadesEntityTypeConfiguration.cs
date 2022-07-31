using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class NacionalidadesEntityTypeConfiguration : IEntityTypeConfiguration<Nacionalidades>
    {
        public void Configure(EntityTypeBuilder<Nacionalidades> NacionalidadesConfiguration)
        {
            NacionalidadesConfiguration.ToTable("Nacionalidades", AfiliacionesContext.DEFAULT_SCHEMA);

            NacionalidadesConfiguration.HasKey(o => o.Id);

            NacionalidadesConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}