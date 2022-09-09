namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Application.Queries
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Linq;

    public class DetalleDocumentacionQueries
        : IDetalleDocumentacionQueries
    {
        private string _connectionString = string.Empty;

        public DetalleDocumentacionQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<DetalleDocumentacionDTO> GetDetalleDocumentacionAsync(Guid id)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT dd.*, p.Descripcion as PlanNombre, d.Descripcion as DocumentacionNombre, d.Discapacidad, dd.Obligatorio
                    FROM  dbo.DetalleDocumentacion dd inner join 
                    Planes p on dd.PlanId=d.Id 
                    inner join Documentacion d on dd.DocumentacionId=dd.Id
                    where dd.Id = @id;"
                    , new { id });

                var detalleDocumentacion = multiple.Read<DetalleDocumentacionDTO>().First();

                if (detalleDocumentacion == null)
                    throw new KeyNotFoundException();

                return detalleDocumentacion;
            }
        }

        public async Task<IEnumerable<DetalleDocumentacionDTO>> GetDetalleDocumentacionByPlanParentescoAsync(Guid planId, Guid parentescoId, bool discapacidad)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var where="";
                if (discapacidad){
                    where =  "";
                }else{
                    where = " and discapacidad = 0";
                }

                var multiple = await connection.QueryMultipleAsync(
                   @"SELECT dd.*, p.Descripcion as PlanNombre, d.Descripcion as DocumentacionNombre, d.Discapacidad, dd.Obligatorio
                    FROM  dbo.DetalleDocumentacion dd inner join 
                    Planes p on dd.PlanId=p.Id 
                    inner join Documentacion d on dd.DocumentacionId=d.Id
                    inner join Parentescos pa on pa.Id=dd.ParentescoId
                    where dd.PlanId=@planId and  dd.ParentescoId=@parentescoId" + where
                    , new { planId, parentescoId });

                var detalleDocumentacion = multiple.Read<DetalleDocumentacionDTO>().ToList();

                if (detalleDocumentacion == null)
                    throw new KeyNotFoundException();

                return detalleDocumentacion;
            }
        }

        public async Task<IEnumerable<DetalleDocumentacionDTO>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var multiple = await connection.QueryMultipleAsync(
                    @"SELECT dd.*, p.Descripcion as PlanNombre, d.Descripcion as DocumentacionNombre, d.Discapacidad, dd.Obligatorio
                    FROM  dbo.DetalleDocumentacion dd inner join 
                    Planes p on dd.PlanId=p.Id 
                    inner join Parentescos pa on pa.Id=dd.ParentescoId
                    inner join Documentacion d on dd.DocumentacionId=d.Id;");

                var detalleDocumentacion = multiple.Read<DetalleDocumentacionDTO>().ToList();

                return detalleDocumentacion;
            }
        }


    }

}