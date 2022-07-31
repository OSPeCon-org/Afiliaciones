namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class ProvinciasQueries
        : IProvinciasQueries
    {
        private string _connectionString = string.Empty;

        public ProvinciasQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<ProvinciasDTO> GetProvinciasAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion
                    FROM     dbo.Provincias c where c.Id = @id;"
                    , new { id });

                var provincia = multiple.Read<ProvinciasDTO>().First();

                if (provincia == null)
                    throw new KeyNotFoundException();

                return provincia;
            }
        }

        public async Task<IEnumerable<ProvinciasDTO>> GetProvinciasByNameAsync(string descripcion)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion, c.CodigoSSS
                    FROM     dbo.Provincias c where c.Descripcion like '%' + @descripcion + '%' Order by c.Descripcion;"
                    , new { descripcion });

                var provincia = multiple.Read<ProvinciasDTO>().ToList();

                if (provincia == null)
                    throw new KeyNotFoundException();

                return provincia;
            }
        }

        public async Task<IEnumerable<ProvinciasDTO>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                    @"SELECT c.Id, c.Descripcion, c.CodigoSSS
                    FROM     dbo.Provincias c Order by c.Descripcion desc;");

                var provincias = multiple.Read<ProvinciasDTO>().ToList();

                return provincias;
            }
        }


    }

}