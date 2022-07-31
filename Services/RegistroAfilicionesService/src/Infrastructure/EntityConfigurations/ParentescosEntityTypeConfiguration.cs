using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class ParentescosEntityTypeConfiguration : IEntityTypeConfiguration<Parentescos>
    {
        public void Configure(EntityTypeBuilder<Parentescos> ParentescosConfiguration)
        {
            ParentescosConfiguration.ToTable("Parentescos", AfiliacionesContext.DEFAULT_SCHEMA);

            ParentescosConfiguration.HasKey(o => o.Id);

            ParentescosConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}