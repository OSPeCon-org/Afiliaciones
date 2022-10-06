using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Autorizacion;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Infrastructure.EntityConfigurations
{
    class UsuarioAfiliadosEntityTypeConfiguration : IEntityTypeConfiguration<UsuarioAfiliados>
    {
        public void Configure(EntityTypeBuilder<UsuarioAfiliados> UsuarioAfiliadosConfiguration)
        {
            UsuarioAfiliadosConfiguration.ToTable("UsuarioAfiliados", AfiliacionesContext.DEFAULT_SCHEMA);

            UsuarioAfiliadosConfiguration.HasKey(o => o.Id);



        }
    }
}