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
            //AfiliadosDomiciliosConfiguration.Ignore(b => b.Direccion);
            //AfiliadosDomiciliosConfiguration.OwnsOne(o => o.Direccion);
            AfiliadosDomiciliosConfiguration.OwnsOne(p => p.Direccion).Property(p => p.Calle).HasColumnName("Calle");
            AfiliadosDomiciliosConfiguration.OwnsOne(p => p.Direccion).Property(p => p.Altura).HasColumnName("Altura");
            AfiliadosDomiciliosConfiguration.OwnsOne(p => p.Direccion).Property(p => p.Piso).HasColumnName("Piso");
            AfiliadosDomiciliosConfiguration.OwnsOne(p => p.Direccion).Property(p => p.Departamento).HasColumnName("Departamento");
            AfiliadosDomiciliosConfiguration.OwnsOne(p => p.Direccion).Property(p => p.LocalidadesId).HasColumnName("LocalidadesId");
            AfiliadosDomiciliosConfiguration.OwnsOne(p => p.Direccion).Property(p => p.CodigoPostal).HasColumnName("CodigoPostal");


        }
    }
}