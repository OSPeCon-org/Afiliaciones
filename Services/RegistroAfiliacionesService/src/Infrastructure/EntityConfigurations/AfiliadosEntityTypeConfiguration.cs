using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class AfiliadosEntityTypeConfiguration : IEntityTypeConfiguration<Afiliados>
    {
        public void Configure(EntityTypeBuilder<Afiliados> AfiliadosConfiguration)
        {
            AfiliadosConfiguration.ToTable("Afiliados", AfiliacionesContext.DEFAULT_SCHEMA);

            AfiliadosConfiguration.HasKey(o => o.Id);

            AfiliadosConfiguration.Ignore(b => b.DomainEvents);
            AfiliadosConfiguration.HasOne(o => o.Titular).WithMany().OnDelete(DeleteBehavior.NoAction).HasForeignKey(k => k.TitularId);
            AfiliadosConfiguration.Property(x => x.CUIL).HasConversion(new ValueConverter<Cuit, string>(cuil => cuil.Value, value => new Cuit(value)));
            AfiliadosConfiguration.Property(x => x.Apellido).HasConversion(new ValueConverter<NombrePropio, string>(apellido => apellido.Value, value => new NombrePropio(value)));
        }
    }
}