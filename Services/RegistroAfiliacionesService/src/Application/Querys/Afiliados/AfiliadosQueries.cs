namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class AfiliadosQueries
        : IAfiliadosQueries
    {
        private string _connectionString = string.Empty;

        public AfiliadosQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<AfiliadosDTO> GetAfiliadosAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT top 200 a.Id, a.Apellido, a.Nombre, a.TipoDocumentoId, d.Descripcion as TipoDocumentoNombre, 
                   a.Documento, a.ParentescoId, p.Descripcion as ParentescoNombre, a.CUIL, a.FechaNacimiento, a.Fecha,
                   a.PlanId, pl.Descripcion as PlanNombre, a.Sexo, a.EstadoCivilId, e.Descripcion as EstadoCivilNombre,
                   a.Discapacitado, a.NacionalidadId, n.Descripcion as NacionalidadNombre, a.EstadosAfiliacionId, 
                   ea.Descripcion as EstadosAfiliacionNombre
                    FROM     dbo.Afiliados a inner join TipoDocumento d on a.TipoDocumentoId=d.Id 
                    inner join Parentescos p on a.ParentescoId=p.Id
                    inner join Planes pl on a.PlanId=pl.Id
                    inner join EstadosCiviles e on a.EstadoCivilId=e.Id
                    inner join Nacionalidades n on a.NacionalidadId=n.Id 
                    inner join EstadosAfiliacion ea on a.EstadosAfiliacionId=ea.Id
                    where a.Id = @id;"
                    , new { id });

                var afiliado = multiple.Read<AfiliadosDTO>().First();

                if (afiliado == null)
                    throw new KeyNotFoundException();

                return afiliado;
            }
        }

        public async Task<IEnumerable<AfiliadosDTO>> GetAfiliadosByNameAsync(string nombre)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                @"SELECT top 200 a.Id, a.Apellido, a.Nombre, a.TipoDocumentoId, d.Descripcion as TipoDocumentoNombre, 
                   a.Documento, a.ParentescoId, p.Descripcion as ParentescoNombre, a.CUIL, a.FechaNacimiento, a.Fecha,
                   a.PlanId, pl.Descripcion as PlanNombre, a.Sexo, a.EstadoCivilId, e.Descripcion as EstadoCivilNombre,
                   a.Discapacitado, a.NacionalidadId, n.Descripcion as NacionalidadNombre, a.EstadosAfiliacionId, 
                   ea.Descripcion as EstadosAfiliacionNombre
                    FROM     dbo.Afiliados a inner join TipoDocumento d on a.TipoDocumentoId=d.Id 
                    inner join Parentescos p on a.ParentescoId=p.Id
                    inner join Planes pl on a.PlanId=pl.Id
                    inner join EstadosCiviles e on a.EstadoCivilId=e.Id
                    inner join Nacionalidades n on a.NacionalidadId=n.Id 
                    inner join EstadosAfiliacion ea on a.EstadosAfiliacionId=ea.Id
                    where ltrim(rtrim(a.Apellido)) + ' ' + ltrim(rtrim(a.Nombre)) like '%' + @nombre + '%' Order by a.Apellido, a.Nombre ;"
                    , new { nombre });

                var afiliado = multiple.Read<AfiliadosDTO>().ToList();

                if (afiliado == null)
                    throw new KeyNotFoundException();

                return afiliado;
            }
        }

        public async Task<IEnumerable<AfiliadosDTO>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                    @"SELECT top 200 a.Id, a.Apellido, a.Nombre, a.TipoDocumentoId, d.Descripcion as TipoDocumentoNombre, 
                   a.Documento, a.ParentescoId, p.Descripcion as ParentescoNombre, a.CUIL, a.FechaNacimiento, a.Fecha,
                   a.PlanId, pl.Descripcion as PlanNombre, a.Sexo, a.EstadoCivilId, e.Descripcion as EstadoCivilNombre,
                   a.Discapacitado, a.NacionalidadId, n.Descripcion as NacionalidadNombre, a.EstadosAfiliacionId, 
                   ea.Descripcion as EstadosAfiliacionNombre
                    FROM     dbo.Afiliados a inner join TipoDocumento d on a.TipoDocumentoId=d.Id 
                    inner join Parentescos p on a.ParentescoId=p.Id
                    inner join Planes pl on a.PlanId=pl.Id
                    inner join EstadosCiviles e on a.EstadoCivilId=e.Id
                    inner join Nacionalidades n on a.NacionalidadId=n.Id 
                    inner join EstadosAfiliacion ea on a.EstadosAfiliacionId=ea.Id
                    Order by a.Apellido, a.Nombre;");

                var afiliados = multiple.Read<AfiliadosDTO>().ToList();

                return afiliados;
            }
        }


        public async Task<IEnumerable<AfiliadosDTO>> GetGrupoFamiliar(Guid titularId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                    @"SELECT top 200 a.Id, a.Apellido, a.Nombre, a.TipoDocumentoId, d.Descripcion as TipoDocumentoNombre, 
                   a.Documento, a.ParentescoId, p.Descripcion as ParentescoNombre, a.CUIL, a.FechaNacimiento, a.Fecha,
                   a.PlanId, pl.Descripcion as PlanNombre, a.Sexo, a.EstadoCivilId, e.Descripcion as EstadoCivilNombre,
                   a.Discapacitado, a.NacionalidadId, n.Descripcion as NacionalidadNombre, a.EstadosAfiliacionId, 
                   ea.Descripcion as EstadosAfiliacionNombre
                    FROM     dbo.Afiliados a inner join TipoDocumento d on a.TipoDocumentoId=d.Id 
                    inner join Parentescos p on a.ParentescoId=p.Id
                    inner join Planes pl on a.PlanId=pl.Id
                    inner join EstadosCiviles e on a.EstadoCivilId=e.Id
                    inner join Nacionalidades n on a.NacionalidadId=n.Id 
                    inner join EstadosAfiliacion ea on a.EstadosAfiliacionId=ea.Id
                     where a.titularId = @titularId;"
                    , new { titularId }
                    );

                var afiliados = multiple.Read<AfiliadosDTO>().ToList();

                return afiliados;
            }
        }


    }

}