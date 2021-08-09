using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomina2018.Models
{
    public class SucursalesModel
    {
        public int idSucursal { get; set; }
        public string nombre { get; set; }
        public string calle { get; set; }
        public string noExterior { get; set; }
        public string noInterior { get; set; }
        public string Colonia { get; set; }
        public string localidad { get; set; }
        public string referencia { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public string codigoPostal { get; set; }
        public int alta { get; set; }
    }
}