namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class DocumentacionQueries
        : IDocumentacionQueries
    {
        private string _connectionString = string.Empty;

        public DocumentacionQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<DocumentacionDTO> GetDocumentacionAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT d.*
                    FROM     dbo.Documentacion d where d.Id = @id;"
                    , new { id });

                var documentacion = multiple.Read<DocumentacionDTO>().First();

                if (documentacion == null)
                    throw new KeyNotFoundException();

                return documentacion;
            }
        }

        public async Task<IEnumerable<DocumentacionDTO>> GetDocumentacionByNameAsync(string descripcion)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT d.*
                    FROM     dbo.Documentacion d where c.Descripcion like '%' + @descripcion + '%' Order by c.Descripcion;"
                    , new { descripcion });

                var documentacion = multiple.Read<DocumentacionDTO>().ToList();

                if (documentacion == null)
                    throw new KeyNotFoundException();

                return documentacion;
            }
        }

        public async Task<IEnumerable<DocumentacionDTO>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                    @"SELECT d.*
                    FROM     dbo.Documentacion d Order by d.Descripcion desc;");

                var documentaciones = multiple.Read<DocumentacionDTO>().ToList();

                return documentaciones;
            }
        }


    }

}