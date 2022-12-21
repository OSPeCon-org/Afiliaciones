namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class AfiliadosDocumentacionQueries
        : IAfiliadosDocumentacionQueries
    {
        private string _connectionString = string.Empty;

        public AfiliadosDocumentacionQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<AfiliadosDocumentacionDTO> GetByIdAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"Select ad.Id, ad.AfiliadosId, a.Apellido, a.Nombre, ad.URL, ad.estado, d.Descripcion as Documentacion 
                    FROM AfiliadosDocumentacion ad inner join Afiliados a on ad.AfiliadosId=a.Id 
                    inner join dbo.DetalleDocumentacion dd on ad.DetalleDocumentacionId=dd.Id
                    inner join dbo.Documentacion d on dd.DocumentacionId=d.Id
                    where ad.Id = @id;"
                    , new { id });

                var documento = multiple.Read<AfiliadosDocumentacionDTO>().First();

                if (documento == null)
                    throw new KeyNotFoundException();

                return documento;
            }
        }


        public async Task<IEnumerable<AfiliadosDocumentacionDTO>> GetByAfiliadoIdAsync(Guid afiliadoId)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                /* @"with Documentos as
                    (select dd.*, d.Descripcion as documento, a.Id as afiliadoid , a.Nombre, a.Apellido
                    from DetalleDocumentacion dd inner join Documentacion d on dd.DocumentacionId=d.Id
                    inner join Afiliados a on a.PlanId=dd.PlanId and a.ParentescoId=dd.ParentescoId
                    where a.Id=@afiliadoId)
                    select d.Id, doc.documento as Documentacion, d.id as DetalleDocumentacionId, d.DocumentacionId, d.Estado, 
                                        d.URL, doc.Apellido, doc.Nombre
                    from Documentos doc left join AfiliadosDocumentacion d on doc.afiliadoid=d.AfiliadosId and doc.Id=d.DetalleDocumentacionId" */
                    @"with Documentos as 
                    (select dd.*, d.Descripcion as documento, a.Id as afiliadoid , a.Nombre, a.Apellido
                        from DetalleDocumentacion dd 
                        left join Documentacion d on dd.DocumentacionId=d.Id
                        left join Afiliados a on a.PlanId=dd.PlanId and a.ParentescoId=dd.ParentescoId
                        where a.Id=@afiliadoId),
                    afiliado as 
                        (select max(fechaalta) as fechaalta, DetalleDocumentacionId from AfiliadosDocumentacion ad 
                        where ad.AfiliadosId=@afiliadoId group by DetalleDocumentacionId) 
                    select d.AfiliadosId, d.Id, doc.documento as documentacion, doc.Id as DetalleDocumentacionId, doc.DocumentacionId, d.Estado, d.URL, doc.Apellido, doc.Nombre from 
                    Documentos doc 
                    left join Afiliado af on doc.Id=af.DetalleDocumentacionId
                    left join AfiliadosDocumentacion d on af.DetalleDocumentacionId=d.DetalleDocumentacionId and af.fechaalta=d.FechaAlta 
                    and d.AfiliadosId=@afiliadoId"
                  , new { afiliadoId });

                var afiliado = multiple.Read<AfiliadosDocumentacionDTO>().ToList();

                if (afiliado == null)
                    throw new KeyNotFoundException();

                return afiliado;
            }

        }
    }

}