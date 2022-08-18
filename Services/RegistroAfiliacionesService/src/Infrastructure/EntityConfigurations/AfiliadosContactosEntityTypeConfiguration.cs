using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class AfiliadosContactosEntityTypeConfiguration : IEntityTypeConfiguration<AfiliadosContactos>
    {
        public void Configure(EntityTypeBuilder<AfiliadosContactos> AfiliadosContactosConfiguration)
        {
            AfiliadosContactosConfiguration.ToTable("AfiliadosContactos", AfiliacionesContext.DEFAULT_SCHEMA);

            AfiliadosContactosConfiguration.HasKey(o => o.Id);

            AfiliadosContactosConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}