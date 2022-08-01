using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class PlanesEntityTypeConfiguration : IEntityTypeConfiguration<Planes>
    {
        public void Configure(EntityTypeBuilder<Planes> PlanesConfiguration)
        {
            PlanesConfiguration.ToTable("Planes", AfiliacionesContext.DEFAULT_SCHEMA);

            PlanesConfiguration.HasKey(o => o.Id);

            PlanesConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}