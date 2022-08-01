using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class TipoDocumentoEntityTypeConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> TipoDocumentoConfiguration)
        {
            TipoDocumentoConfiguration.ToTable("TipoDocumento", AfiliacionesContext.DEFAULT_SCHEMA);

            TipoDocumentoConfiguration.HasKey(o => o.Id);

            TipoDocumentoConfiguration.Ignore(b => b.DomainEvents);

        }
    }
}