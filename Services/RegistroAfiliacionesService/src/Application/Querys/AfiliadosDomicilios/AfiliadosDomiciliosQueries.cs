namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class AfiliadosDomiciliosQueries
        : IAfiliadosDomiciliosQueries
    {
        private string _connectionString = string.Empty;

        public AfiliadosDomiciliosQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<AfiliadosDomiciliosDTO> GetAfiliadosDomiciliosAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT  ad.Id, ad.AfiliadosId, a.Apellido, a.Nombre, ad.Calle, ad.Altura, ad.Piso, ad.Departamento, ad.LocalidadesId, ad.CodigoPostal, 
                   l.Descripcion as Localidad, p.Descripcion as Provincia
                    FROM     dbo.AfiliadosDomicilios ad inner join Afiliados a on ad.AfiliadosId=a.Id 
                    inner join dbo.Localidades l on ad.LocalidadesId = l.Id
                    inner join dbo.Provincias p on l.ProvinciasId=p.Id
                    where ad.Id = @id;"
                    , new { id });

                var afiliado = multiple.Read<AfiliadosDomiciliosDTO>().First();

                if (afiliado == null)
                    throw new KeyNotFoundException();

                return afiliado;
            }
        }

        public async Task<IEnumerable<AfiliadosDomiciliosDTO>> GetAfiliadosDomiciliosByAfiliadoIdAsync(Guid afiliadoId)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                @"SELECT  ad.Id, ad.AfiliadosId, a.Apellido, a.Nombre, ad.Calle, ad.Altura, ad.Piso, ad.Departamento, ad.LocalidadesId, ad.CodigoPostal, 
                   l.Descripcion as Localidad, p.Descripcion as Provincia
                    FROM     dbo.AfiliadosDomicilios ad inner join Afiliados a on ad.AfiliadosId=a.Id 
                    inner join dbo.Localidades l on ad.LocalidadesId = l.Id
                    inner join dbo.Provincias p on l.ProvinciasId=p.Id
                    where ad.AfiliadosId = @afiliadoId"
                    , new { afiliadoId });

                var afiliado = multiple.Read<AfiliadosDomiciliosDTO>().ToList();

                if (afiliado == null)
                    throw new KeyNotFoundException();

                return afiliado;
            }
        }

       


    }

}