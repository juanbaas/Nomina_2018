//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nomina2018.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string numEmpleado { get; set; }
        public string nombre { get; set; }
        public string curp { get; set; }
        public Nullable<int> idTipoRegimen { get; set; }
        public Nullable<int> idDepartamentos { get; set; }
        public Nullable<System.DateTime> fechaInicioRelLaboral { get; set; }
        public string puesto { get; set; }
        public Nullable<int> idTipoContrato { get; set; }
        public Nullable<int> idTipoJornada { get; set; }
        public Nullable<int> idPeriodicidad { get; set; }
        public Nullable<decimal> salarioDiarioIntegrado { get; set; }
        public string calle { get; set; }
        public string noExterior { get; set; }
        public string noInterior { get; set; }
        public string colonia { get; set; }
        public string localidad { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public string codigoPostal { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public Nullable<int> alta { get; set; }
        public Nullable<decimal> importeFijo { get; set; }
        public Nullable<decimal> aguinaldo { get; set; }
        public Nullable<decimal> vacaciones { get; set; }
        public Nullable<decimal> salarioBaseCotizacion { get; set; }
        public Nullable<System.DateTime> fechaBaja { get; set; }
        public Nullable<int> idSucursal { get; set; }
    
        public virtual Departamento Departamento { get; set; }
    }
}
