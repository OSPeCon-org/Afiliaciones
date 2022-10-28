using System;
using System.Collections.Generic;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.Entities;
using OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.SeedWork;

namespace OSPeConTI.Afiliaciones.RegistroAfiliaciones.Domain.ValueObjects;

public class Direccion : ValueObject
{
    public string Calle { get; private set; }
    public string Altura { get; private set; }
    public string Piso { get; private set; }
    public string Departamento { get; private set; }
    public Guid LocalidadesId { get; private set; }
    public string CodigoPostal { get; set; }
    public Localidades Localidad { get; set; }
    public Direccion() { }

    public Direccion(string calle, string altura, string piso, string departamento, Guid localidadesId, string codigoPostal)
    {
        Calle = calle;
        Altura = altura;
        Piso = piso;
        Departamento = departamento;
        LocalidadesId = localidadesId;
        CodigoPostal = codigoPostal;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return Calle;
        yield return Altura;
        yield return Piso;
        yield return Departamento;
        yield return LocalidadesId;
        yield return CodigoPostal;
    }
}
