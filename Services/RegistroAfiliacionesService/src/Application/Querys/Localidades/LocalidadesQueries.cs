namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class LocalidadesQueries
        : ILocalidadesQueries
    {
        private string _connectionString = string.Empty;

        public LocalidadesQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<LocalidadesDTO> GetLocalidadesAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion, c.ProvinciasId, p.Descripcion as ProvinciaNombre, c.CodigoPostal, c.CodigoSSS
                    FROM     dbo.Localidades c inner join dbo.Provincias p on c.ProvinciasId=p.Id where c.Id = @id;"
                    , new { id });

                var localidad = multiple.Read<LocalidadesDTO>().First();

                if (localidad == null)
                    throw new KeyNotFoundException();

                return localidad;
            }
        }

        public async Task<IEnumerable<LocalidadesDTO>> GetLocalidadesByNameAsync(string descripcion)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion, c.ProvinciasId, p.Descripcion as ProvinciaNombre, c.CodigoPostal, c.CodigoSSS
                    FROM     dbo.Localidades c inner join dbo.Provincias p on c.ProvinciasId=p.Id where c.Descripcion like '%' + @descripcion + '%' Order by c.Descripcion;"
                    , new { descripcion });

                var localidad = multiple.Read<LocalidadesDTO>().ToList();

                if (localidad == null)
                    throw new KeyNotFoundException();

                return localidad;
            }
        }

        public async Task<IEnumerable<LocalidadesDTO>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                    @"SELECT c.Id, c.Descripcion, c.ProvinciasId, p.Descripcion as ProvinciaNombre, c.CodigoPostal, c.CodigoSSS
                    FROM     dbo.Localidades c inner join dbo.Provincias p on c.ProvinciasId=p.Id Order by c.Descripcion desc;");

                var localidades = multiple.Read<LocalidadesDTO>().ToList();

                return localidades;
            }
        }

          public async Task<List<LocalidadesDTO>> GetLocalidadesByProvincia(Guid provinciaId)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT c.Id, c.Descripcion, c.ProvinciasId, p.Descripcion as ProvinciaNombre, c.CodigoPostal, c.CodigoSSS
                    FROM     dbo.Localidades c inner join dbo.Provincias p on c.ProvinciasId=p.Id where c.Id = @id;"
                    , new { provinciaId });

                var localidades = multiple.Read<LocalidadesDTO>().ToList();

                if (localidades == null)
                    throw new KeyNotFoundException();

                return localidades;
            }
        }


    }

      

}