namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class AfiliadosContactosQueries
        : IAfiliadosContactosQueries
    {
        private string _connectionString = string.Empty;

        public AfiliadosContactosQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<AfiliadosContactosDTO> GetAfiliadosContactosAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT  ac.Id, ac.AfiliadosId, ac.Celular, ac.Particular, ac.Laboral, ac.Mail, ac.Mail2, 
                   a.Nombre, a.Apellido
                    FROM     dbo.AfiliadosContactos ac inner join Afiliados a on ac.AfiliadosId=a.Id                     
                    where ac.Id = @id;"
                    , new { id });

                var afiliado = multiple.Read<AfiliadosContactosDTO>().First();

                if (afiliado == null)
                    throw new KeyNotFoundException();

                return afiliado;
            }
        }

        public async Task<IEnumerable<AfiliadosContactosDTO>> GetAfiliadosContactosByAfiliadoIdAsync(Guid afiliadoId)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                @"SELECT  ac.Id, ac.AfiliadosId, ac.Celular, ac.Particular, ac.Laboral, ac.Mail, ac.Mail2, 
                   a.Nombre, a.Apellido
                    FROM     dbo.AfiliadosContactos ac inner join Afiliados a on ac.AfiliadosId=a.Id                                         
                    where ac.AfiliadosId = @afiliadoId"
                    , new { afiliadoId });

                var afiliado = multiple.Read<AfiliadosContactosDTO>().ToList();

                if (afiliado == null)
                    throw new KeyNotFoundException();

                return afiliado;
            }
        }

       


    }

}