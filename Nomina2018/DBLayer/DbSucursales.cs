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
    public class DbSucursales
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["conn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** Agregar nueva sucursal *********************
        public bool AgregarSucursal(SucursalesModel Sucmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("spInsertarSucursales", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", Sucmodel.nombre);
            cmd.Parameters.AddWithValue("@calle", Sucmodel.calle);
            cmd.Parameters.AddWithValue("@noExterior", Sucmodel.noExterior);
            cmd.Parameters.AddWithValue("@noInterior", Sucmodel.noInterior);
            cmd.Parameters.AddWithValue("@Colonia", Sucmodel.Colonia);
            cmd.Parameters.AddWithValue("@localidad", Sucmodel.localidad);
            cmd.Parameters.AddWithValue("@referencia", Sucmodel.referencia);
            cmd.Parameters.AddWithValue("@municipio", Sucmodel.municipio);
            cmd.Parameters.AddWithValue("@estado", Sucmodel.estado);
            cmd.Parameters.AddWithValue("@pais", Sucmodel.pais);
            cmd.Parameters.AddWithValue("@codigoPostal", Sucmodel.codigoPostal);
            cmd.Parameters.AddWithValue("@alta", Sucmodel.alta);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** Listar sucursale ********************
        public List<SucursalesModel> ListarSucursales()
        {
            connection();
            List<SucursalesModel> sucursalesList = new List<SucursalesModel>();

            SqlCommand cmd = new SqlCommand("spListarSucursal", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                sucursalesList.Add(
                    new SucursalesModel
                    {
                        idSucursal = Convert.ToInt32(dr["idSucursal"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        calle = Convert.ToString(dr["calle"]),
                        noExterior = Convert.ToString(dr["noExterior"]),
                        noInterior = Convert.ToString(dr["noInterior"]),
                        Colonia = Convert.ToString(dr["Colonia"]),
                        localidad = Convert.ToString(dr["localidad"]),
                        referencia = Convert.ToString(dr["referencia"]),
                        municipio = Convert.ToString(dr["municipio"]),
                        estado = Convert.ToString(dr["estado"]),
                        pais = Convert.ToString(dr["pais"]),
                        codigoPostal = Convert.ToString(dr["codigoPostal"]),
                        alta = Convert.ToInt32(dr["alta"])
                        
                    });
            }
            return sucursalesList;
        }

        // ***************** Actualizar Sucursal *********************
        public bool ActualizarSucursal(SucursalesModel sucModel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("spActualizarSucursal", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idSucursal", sucModel.idSucursal);
            cmd.Parameters.AddWithValue("@nombre", sucModel.nombre);
            cmd.Parameters.AddWithValue("@calle", sucModel.calle);
            cmd.Parameters.AddWithValue("@noExterior", sucModel.noExterior);
            cmd.Parameters.AddWithValue("@noInterior", sucModel.noInterior);
            cmd.Parameters.AddWithValue("@Colonia", sucModel.Colonia);
            cmd.Parameters.AddWithValue("@localidad", sucModel.localidad);
            cmd.Parameters.AddWithValue("@referencia", sucModel.referencia);
            cmd.Parameters.AddWithValue("@municipio", sucModel.municipio);
            cmd.Parameters.AddWithValue("@estado", sucModel.estado);
            cmd.Parameters.AddWithValue("@pais", sucModel.pais);
            cmd.Parameters.AddWithValue("@codigoPostal", sucModel.codigoPostal);
            cmd.Parameters.AddWithValue("@alta", sucModel.alta);



            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** Borrar Sucursal *******************
        public bool BorrarSucursal(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("spBorrarSucursales", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idSucursal", id);

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