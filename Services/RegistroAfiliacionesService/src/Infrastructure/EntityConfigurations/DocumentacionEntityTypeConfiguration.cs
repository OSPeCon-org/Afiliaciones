using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class DocumentacionEntityTypeConfiguration : IEntityTypeConfiguration<Documentacion>
    {
        public void Configure(EntityTypeBuilder<Documentacion> DocumentacionConfiguration)
        {
            DocumentacionConfiguration.ToTable("Documentacion", AfiliacionesContext.DEFAULT_SCHEMA);

            DocumentacionConfiguration.HasKey(o => o.Id);

            DocumentacionConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}