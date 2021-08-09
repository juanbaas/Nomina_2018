using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomina2018.Models
{
    public class EmpleadosModel
    {
        public int IdEmpleado { get; set; }
        public string numEmpleado { get; set; }
        public string nombre { get; set; }
        public string curp { get; set; }
        public int idTipoRegimen { get; set; }
        public int idDepartamentos { get; set; }
        public DateTime fechaInicioRelLaboral { get; set; }
        public string puesto { get; set; }
        public int idTipoContrato { get; set; }
        public int idTipoJornada { get; set; }
        public int idPeriodicidad { get; set; }
        public decimal salarioDiarioIntegrado { get; set; }
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
        public int alta { get; set; }
        public decimal importeFijo { get; set; }
        public decimal aguinaldo { get; set; }
        public decimal vacaciones { get; set; }
        public decimal salarioBaseCotizacion { get; set; }
        public DateTime fechaBaja { get; set; }
        public int idSucursal { get; set; }

    }
}