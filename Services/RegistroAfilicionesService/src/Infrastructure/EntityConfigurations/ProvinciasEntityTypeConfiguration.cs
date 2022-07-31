using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class ProvinciasEntityTypeConfiguration : IEntityTypeConfiguration<Provincias>
    {
        public void Configure(EntityTypeBuilder<Provincias> ProvinciasConfiguration)
        {
            ProvinciasConfiguration.ToTable("Provincias", AfiliacionesContext.DEFAULT_SCHEMA);

            ProvinciasConfiguration.HasKey(o => o.Id);

            ProvinciasConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}