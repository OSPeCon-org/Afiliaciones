namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class EstadosCivilesQueries
        : IEstadosCivilesQueries
    {
        private string _connectionString = string.Empty;

        public EstadosCivilesQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<EstadosCivilesDTO> GetEstadosCivilesAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion
                    FROM     dbo.EstadosCiviles c where c.Id = @id;"
                    , new { id });

                var estadosCiviles = multiple.Read<EstadosCivilesDTO>().First();

                if (estadosCiviles == null)
                    throw new KeyNotFoundException();

                return estadosCiviles;
            }
        }

        public async Task<IEnumerable<EstadosCivilesDTO>> GetEstadosCivilesByNameAsync(string descripcion)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion, c.CodigoSSS
                    FROM     dbo.EstadosCiviles c where c.Descripcion like '%' + @descripcion + '%' Order by c.Descripcion;"
                    , new { descripcion });

                var estadosCiviles = multiple.Read<EstadosCivilesDTO>().ToList();

                if (estadosCiviles == null)
                    throw new KeyNotFoundException();

                return estadosCiviles;
            }
        }

        public async Task<IEnumerable<EstadosCivilesDTO>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                    @"SELECT c.Id, c.Descripcion, c.CodigoSSS
                    FROM     dbo.EstadosCiviles c Order by c.Descripcion desc;");

                var estadosCiviles = multiple.Read<EstadosCivilesDTO>().ToList();

                return estadosCiviles;
            }
        }


    }

}