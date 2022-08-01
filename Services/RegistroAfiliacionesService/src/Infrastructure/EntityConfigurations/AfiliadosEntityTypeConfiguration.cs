using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class AfiliadosEntityTypeConfiguration : IEntityTypeConfiguration<Afiliados>
    {
        public void Configure(EntityTypeBuilder<Afiliados> AfiliadosConfiguration)
        {
            AfiliadosConfiguration.ToTable("Afiliados", AfiliacionesContext.DEFAULT_SCHEMA);

            AfiliadosConfiguration.HasKey(o => o.Id);

            AfiliadosConfiguration.Ignore(b => b.DomainEvents);

           // AfiliadosConfiguration.Property(b => b.Costo).HasPrecision(18, 2);

        }
    }
}