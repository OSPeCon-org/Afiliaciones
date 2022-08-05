using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class AfiliadosDocumentacionEntityTypeConfiguration : IEntityTypeConfiguration<AfiliadosDocumentacion>
    {
        public void Configure(EntityTypeBuilder<AfiliadosDocumentacion> AfiliadosDocumentacionConfiguration)
        {
            AfiliadosDocumentacionConfiguration.ToTable("AfiliadosDocumentacion", AfiliacionesContext.DEFAULT_SCHEMA);

            AfiliadosDocumentacionConfiguration.HasKey(o => o.Id);

            AfiliadosDocumentacionConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}