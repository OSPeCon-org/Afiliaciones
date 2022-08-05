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

        public async Task<AfiliadosDocumentacionDTO> GetAfiliadosDocumentacionAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT  SELECT  ad.Id, ad.AfiliadosId, a.Apellido, a.Nombre, ad.URL, ad.Aprobado, d.Descripcion as Documentacion, case 
                    FROM dbo.AfiliadosDocumentacion ad inner join Afiliados a on ad.AfiliadosId=a.Id 
                    inner join dbo.DetalleDocumentacion dd on a.DetalleDocumentacionId=dd.Id
                    inner join dbo.Documentacion d on dd.DocumentacionId=d.Id
                    where ad.Id = @id;"
                    , new { id });

                var afiliado = multiple.Read<AfiliadosDocumentacionDTO>().First();

                if (afiliado == null)
                    throw new KeyNotFoundException();

                return afiliado;
            }
        }

        public async Task<IEnumerable<AfiliadosDocumentacionDTO>> GetAfiliadosDocumentacionByAfiliadoIdAsync(Guid afiliadoId)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                @"SELECT  SELECT  ad.Id, ad.AfiliadosId, a.Apellido, a.Nombre, ad.URL, ad.Aprobado, d.Descripcion as Documentacion, case 
                    FROM dbo.AfiliadosDocumentacion ad inner join Afiliados a on ad.AfiliadosId=a.Id 
                    inner join dbo.DetalleDocumentacion dd on a.DetalleDocumentacionId=dd.Id
                    inner join dbo.Documentacion d on dd.DocumentacionId=d.Id
                    where ad.AfiliadosId = @afiliadoId"
                    , new { afiliadoId });

                var afiliado = multiple.Read<AfiliadosDocumentacionDTO>().ToList();

                if (afiliado == null)
                    throw new KeyNotFoundException();

                return afiliado;
            }

        }

        

        public async Task<IEnumerable<AfiliadosDocumentacionDTO>> GetDocumentacion(Guid afiliadoId)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                @"Select ad.Id, d.Descripcion as Documentacion, d.id as DetalleDocumentacionId, ad.DocumentacionId, ad.Aprobado, 
					ad.URL, a.Apellido, a.Nombre, d.Descripcion as Documento 
					from DetalleDocumentacion dd left join 
					(select * from  AfiliadosDocumentacion ad where ad.AfiliadosId=@afiliadoId)
					ad on dd.id=ad.DetalleDocumentacionId
					left join afiliados a on a.id=ad.AfiliadosId
					left join Documentacion d on dd.DocumentacionId=d.id"
                    , new { afiliadoId });

                var afiliado = multiple.Read<AfiliadosDocumentacionDTO>().ToList();

                if (afiliado == null)
                    throw new KeyNotFoundException();

                return afiliado;
            }
            
        }
       


    }

}