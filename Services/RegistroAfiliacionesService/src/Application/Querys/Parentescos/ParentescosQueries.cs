namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class ParentescosQueries
        : IParentescosQueries
    {
        private string _connectionString = string.Empty;

        public ParentescosQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<ParentescosDTO> GetParentescosAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion
                    FROM     dbo.Parentescos c where c.Id = @id;"
                    , new { id });

                var parentescos = multiple.Read<ParentescosDTO>().First();

                if (parentescos == null)
                    throw new KeyNotFoundException();

                return parentescos;
            }
        }

        public async Task<IEnumerable<ParentescosDTO>> GetParentescosByNameAsync(string descripcion)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion, c.CodigoSSS
                    FROM     dbo.Parentescos c where c.Descripcion like '%' + @descripcion + '%' Order by c.Descripcion;"
                    , new { descripcion });

                var parentescos = multiple.Read<ParentescosDTO>().ToList();

                if (parentescos == null)
                    throw new KeyNotFoundException();

                return parentescos;
            }
        }

        public async Task<IEnumerable<ParentescosDTO>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                    @"SELECT c.Id, c.Descripcion, c.CodigoSSS
                    FROM     dbo.Parentescos c Order by c.Descripcion desc;");

                var parentescos = multiple.Read<ParentescosDTO>().ToList();

                return parentescos;
            }
        }


    }

}