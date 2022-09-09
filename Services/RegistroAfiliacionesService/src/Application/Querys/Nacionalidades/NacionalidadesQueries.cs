namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class NacionalidadesQueries
        : INacionalidadesQueries
    {
        private string _connectionString = string.Empty;

        public NacionalidadesQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<NacionalidadDTO> GetNacionalidadesAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion
                    FROM     dbo.Nacionalidades c where c.Id = @id;"
                    , new { id });

                var nacionalidades = multiple.Read<NacionalidadDTO>().First();

                if (nacionalidades == null)
                    throw new KeyNotFoundException();

                return nacionalidades;
            }
        }

        public async Task<IEnumerable<NacionalidadDTO>> GetNacionalidadesByNameAsync(string descripcion)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion, c.CodigoSSS
                    FROM     dbo.Nacionalidades c where c.Descripcion like '%' + @descripcion + '%' Order by c.Descripcion;"
                    , new { descripcion });

                var nacionalidades = multiple.Read<NacionalidadDTO>().ToList();

                if (nacionalidades == null)
                    throw new KeyNotFoundException();

                return nacionalidades;
            }
        }

        public async Task<IEnumerable<NacionalidadDTO>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                    @"SELECT c.Id, c.Descripcion, c.CodigoSSS
                    FROM     dbo.Nacionalidades c Order by c.Descripcion;");

                var nacionalidades = multiple.Read<NacionalidadDTO>().ToList();

                return nacionalidades;
            }
        }


    }

}