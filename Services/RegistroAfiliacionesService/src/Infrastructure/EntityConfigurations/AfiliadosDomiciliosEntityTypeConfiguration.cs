using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class AfiliadosDomiciliosEntityTypeConfiguration : IEntityTypeConfiguration<AfiliadosDomicilios>
    {
        public void Configure(EntityTypeBuilder<AfiliadosDomicilios> AfiliadosDomiciliosConfiguration)
        {
            AfiliadosDomiciliosConfiguration.ToTable("AfiliadosDomicilios", AfiliacionesContext.DEFAULT_SCHEMA);

            AfiliadosDomiciliosConfiguration.HasKey(o => o.Id);

            AfiliadosDomiciliosConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}