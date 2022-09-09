namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class PlanesQueries
        : IPlanesQueries
    {
        private string _connectionString = string.Empty;

        public PlanesQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<PlanesDTO> GetPlanesAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion
                    FROM     dbo.Planes c where c.Id = @id;"
                    , new { id });

                var plan = multiple.Read<PlanesDTO>().First();

                if (plan == null)
                    throw new KeyNotFoundException();

                return plan;
            }
        }

        public async Task<IEnumerable<PlanesDTO>> GetPlanesByNameAsync(string descripcion)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion, c.CodigoSSS
                    FROM     dbo.Planes c where c.Descripcion like '%' + @descripcion + '%' Order by c.Descripcion;"
                    , new { descripcion });

                var plan = multiple.Read<PlanesDTO>().ToList();

                if (plan == null)
                    throw new KeyNotFoundException();

                return plan;
            }
        }

        public async Task<IEnumerable<PlanesDTO>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                    @"SELECT c.Id, c.Descripcion, c.CodigoSSS
                    FROM     dbo.Planes c Order by c.Descripcion;");

                var planes = multiple.Read<PlanesDTO>().ToList();

                return planes;
            }
        }


    }

}