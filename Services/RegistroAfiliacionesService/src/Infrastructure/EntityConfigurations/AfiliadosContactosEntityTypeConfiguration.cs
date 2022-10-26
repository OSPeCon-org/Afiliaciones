using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class AfiliadosContactosEntityTypeConfiguration : IEntityTypeConfiguration<AfiliadosContactos>
    {
        public void Configure(EntityTypeBuilder<AfiliadosContactos> AfiliadosContactosConfiguration)
        {
            AfiliadosContactosConfiguration.ToTable("AfiliadosContactos", AfiliacionesContext.DEFAULT_SCHEMA);

            AfiliadosContactosConfiguration.HasKey(o => o.Id);

            AfiliadosContactosConfiguration.Ignore(b => b.DomainEvents);

            AfiliadosContactosConfiguration.Property(x => x.Mail).HasConversion(new ValueConverter<Email, string>(email => email.Value, value => new Email(value)));
            AfiliadosContactosConfiguration.Property(x => x.Mail2).HasConversion(new ValueConverter<Email, string>(email => email.Value, value => new Email(value)));

        }
    }
}