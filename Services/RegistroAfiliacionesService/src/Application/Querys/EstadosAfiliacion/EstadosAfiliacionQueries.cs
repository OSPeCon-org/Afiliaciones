namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class EstadosAfiliacionQueries
        : IEstadosAfiliacionQueries
    {
        private string _connectionString = string.Empty;

        public EstadosAfiliacionQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<EstadoAfiliacionDTO> GetEstadosAfiliacionAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion
                    FROM     dbo.EstadoAfiliacion c where c.Id = @id;"
                    , new { id });

                var estadoAfiliacion = multiple.Read<EstadoAfiliacionDTO>().First();

                if (estadoAfiliacion == null)
                    throw new KeyNotFoundException();

                return estadoAfiliacion;
            }
        }

        public async Task<IEnumerable<EstadoAfiliacionDTO>> GetEstadosAfiliacionByNameAsync(string descripcion)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion, c.CodigoSSS
                    FROM     dbo.EstadoAfiliacion c where c.Descripcion like '%' + @descripcion + '%' Order by c.Descripcion;"
                    , new { descripcion });

                var estadoAfiliacion = multiple.Read<EstadoAfiliacionDTO>().ToList();

                if (estadoAfiliacion == null)
                    throw new KeyNotFoundException();

                return estadoAfiliacion;
            }
        }

        public async Task<IEnumerable<EstadoAfiliacionDTO>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                    @"SELECT c.Id, c.Descripcion, c.CodigoSSS
                    FROM     dbo.EstadoAfiliacion c Order by c.Descripcion desc;");

                var estadoAfiliacion = multiple.Read<EstadoAfiliacionDTO>().ToList();

                return estadoAfiliacion;
            }
        }


    }

}