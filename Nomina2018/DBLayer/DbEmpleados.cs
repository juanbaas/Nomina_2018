using Nomina2018.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Nomina2018.DBLayer
{
    public class DbEmpleados
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["conn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** Agregar Empleado *********************
        public bool AgregarEmpleado(EmpleadosModel Empmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("spInsertarEmpleados", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@numEmpleado", Empmodel.numEmpleado);
            cmd.Parameters.AddWithValue("@nombre", Empmodel.nombre);
            cmd.Parameters.AddWithValue("@curp", Empmodel.curp);
            cmd.Parameters.AddWithValue("@idTipoRegimen", Empmodel.idTipoRegimen);
            cmd.Parameters.AddWithValue("@idDepartamento", Empmodel.idDepartamentos);
            //cmd.Parameters.AddWithValue("@fechaInicioRelLaboral", Empmodel.fechaInicioRelLaboral);
            cmd.Parameters.AddWithValue("@puesto", Empmodel.puesto);
            cmd.Parameters.AddWithValue("@idTipoContrato", Empmodel.idTipoContrato);
            cmd.Parameters.AddWithValue("@idTipoJornada", Empmodel.idTipoJornada);
            cmd.Parameters.AddWithValue("@idPeriodicidad", Empmodel.idPeriodicidad);
            cmd.Parameters.AddWithValue("@salarioDiarioIntegrado", Empmodel.salarioDiarioIntegrado);
            cmd.Parameters.AddWithValue("@calle", Empmodel.calle);
            cmd.Parameters.AddWithValue("@noExterior", Empmodel.noExterior);
            cmd.Parameters.AddWithValue("@noInterior", Empmodel.noInterior);
            cmd.Parameters.AddWithValue("@colonia", Empmodel.colonia);
            cmd.Parameters.AddWithValue("@localidad", Empmodel.localidad);
            cmd.Parameters.AddWithValue("@municipio", Empmodel.municipio);
            cmd.Parameters.AddWithValue("@estado", Empmodel.estado);
            cmd.Parameters.AddWithValue("@pais", Empmodel.pais);
            cmd.Parameters.AddWithValue("@codigoPostal", Empmodel.codigoPostal);
            cmd.Parameters.AddWithValue("@telefono", Empmodel.telefono);
            cmd.Parameters.AddWithValue("@correo", Empmodel.correo);
            cmd.Parameters.AddWithValue("@alta", Empmodel.alta);
            cmd.Parameters.AddWithValue("@importeFijo", Empmodel.importeFijo);
            cmd.Parameters.AddWithValue("@aguinaldo", Empmodel.aguinaldo);
            cmd.Parameters.AddWithValue("@vacaciones", Empmodel.vacaciones);
            cmd.Parameters.AddWithValue("@salarioBaseCotizacion", Empmodel.salarioBaseCotizacion);
            cmd.Parameters.AddWithValue("@fechaBaja", Empmodel.fechaBaja);
            cmd.Parameters.AddWithValue("@idSucursal", Empmodel.idSucursal);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** Listar Empleados ********************
        public List<EmpleadosModel> ListarEmpleados()
        {
            connection();
            List<EmpleadosModel> empleadoslist = new List<EmpleadosModel>();

            SqlCommand cmd = new SqlCommand("spListarEmpleados", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                empleadoslist.Add(
                    new EmpleadosModel
                    {
                        IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                        numEmpleado = Convert.ToString(dr["numEmpleado"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        curp = Convert.ToString(dr["curp"]),
                        idTipoRegimen = Convert.ToInt32(dr["idTipoRegimen"]),
                        idDepartamentos = Convert.ToInt32(dr["idDepartamentos"]),
                        fechaInicioRelLaboral = Convert.ToDateTime(dr["fechaInicioRelLaboral"]),
                        puesto = Convert.ToString(dr["puesto"]),
                        idTipoContrato = Convert.ToInt32(dr["idTipoContrato"]),
                        idTipoJornada = Convert.ToInt32(dr["idTipoJornada"]),
                        idPeriodicidad = Convert.ToInt32(dr["idPeriodicidad"]),
                        salarioDiarioIntegrado = Convert.ToDecimal(dr["salarioDiarioIntegrado"]),
                        calle = Convert.ToString(dr["calle"]),
                        noExterior = Convert.ToString(dr["noExterior"]),
                        noInterior = Convert.ToString(dr["noInterior"]),
                        colonia = Convert.ToString(dr["Colonia"]),
                        localidad = Convert.ToString(dr["localidad"]),
                        municipio = Convert.ToString(dr["municipio"]),
                        estado = Convert.ToString(dr["estado"]),
                        pais = Convert.ToString(dr["pais"]),
                        codigoPostal = Convert.ToString(dr["codigoPostal"]),
                        telefono = Convert.ToString(dr["telefono"]),
                        correo = Convert.ToString(dr["correo"]),
                        alta = Convert.ToInt32(dr["alta"]),
                        importeFijo = Convert.ToDecimal(dr["importeFijo"]),
                        aguinaldo = Convert.ToDecimal(dr["aguinaldo"]),
                        vacaciones = Convert.ToDecimal(dr["vacaciones"]),
                        salarioBaseCotizacion = Convert.ToDecimal(dr["salarioBaseCotizacion"]),
                        fechaBaja = Convert.ToDateTime(dr["fechaBaja"]),
                        idSucursal = Convert.ToInt32(dr["idSucursal"]),
                    });
            }
            return empleadoslist;
        }

        // ***************** Actualizar Empleado *********************
        public bool ActualizarEmpleado(EmpleadosModel Empmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("spActualizarEmpleados", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdEmpleado", Empmodel.IdEmpleado);
            cmd.Parameters.AddWithValue("@numEmpleado", Empmodel.numEmpleado);
            cmd.Parameters.AddWithValue("@nombre", Empmodel.nombre);
            cmd.Parameters.AddWithValue("@curp", Empmodel.curp);
            cmd.Parameters.AddWithValue("@idTipoRegimen", Empmodel.idTipoRegimen);
            cmd.Parameters.AddWithValue("@idDepartamentos", Empmodel.idDepartamentos);
            cmd.Parameters.AddWithValue("@fechaInicioRelLaboral", Empmodel.fechaInicioRelLaboral);
            cmd.Parameters.AddWithValue("@puesto", Empmodel.puesto);
            cmd.Parameters.AddWithValue("@idTipoContrato", Empmodel.idTipoContrato);
            cmd.Parameters.AddWithValue("@idTipoJornada", Empmodel.idTipoJornada);
            cmd.Parameters.AddWithValue("@idPeriodicidad", Empmodel.idPeriodicidad);
            cmd.Parameters.AddWithValue("@salarioDiarioIntegrado", Empmodel.salarioDiarioIntegrado);
            cmd.Parameters.AddWithValue("@calle", Empmodel.calle);
            cmd.Parameters.AddWithValue("@noExterior", Empmodel.noExterior);
            cmd.Parameters.AddWithValue("@noInterior", Empmodel.noInterior);
            cmd.Parameters.AddWithValue("@colonia", Empmodel.colonia);
            cmd.Parameters.AddWithValue("@localidad", Empmodel.localidad);
            cmd.Parameters.AddWithValue("@municipio", Empmodel.municipio);
            cmd.Parameters.AddWithValue("@estado", Empmodel.estado);
            cmd.Parameters.AddWithValue("@pais", Empmodel.pais);
            cmd.Parameters.AddWithValue("@codigoPostal", Empmodel.codigoPostal);
            cmd.Parameters.AddWithValue("@telefono", Empmodel.telefono);
            cmd.Parameters.AddWithValue("@correo", Empmodel.correo);
            cmd.Parameters.AddWithValue("@alta", Empmodel.alta);
            cmd.Parameters.AddWithValue("@importeFijo", Empmodel.importeFijo);
            cmd.Parameters.AddWithValue("@aguinaldo", Empmodel.aguinaldo);
            cmd.Parameters.AddWithValue("@vacaciones", Empmodel.vacaciones);
            cmd.Parameters.AddWithValue("@salarioBaseCotizacion", Empmodel.salarioBaseCotizacion);
            cmd.Parameters.AddWithValue("@fechaBaja", Empmodel.fechaBaja);
            cmd.Parameters.AddWithValue("@idSucursal", Empmodel.idSucursal);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** Borrar Empleado *******************
        public bool BorrarEmpleado(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("spBorrarEmpleado", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdEmpleado", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    
    }
}