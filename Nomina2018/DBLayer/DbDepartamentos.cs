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
    public class DbDepartamentos
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["conn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** Agregar nuevo departamento *********************
        public bool AgregarDepartamento(DepartamentosModel Depmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("spInsertarDepartamentos", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", Depmodel.nombre);
            cmd.Parameters.AddWithValue("@comentarios", Depmodel.comentarios);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** Listar departamentos ********************
        public List<DepartamentosModel> ListarDepartamentos()
        {
            connection();
            List<DepartamentosModel> departamentosList = new List<DepartamentosModel>();

            SqlCommand cmd = new SqlCommand("spListarDepartamentos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                departamentosList.Add(
                    new DepartamentosModel
                    {
                        idDepartamentos = Convert.ToInt32(dr["idDepartamentos"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        comentarios = Convert.ToString(dr["comentarios"])
                        
                    });
            }
            return departamentosList;
        }

        // ***************** Actualizar departamentos *********************
        public bool ActualizarDepartamentos(DepartamentosModel Depmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("spActualizarDepartamentos", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idDepartamentos", Depmodel.idDepartamentos);
            cmd.Parameters.AddWithValue("@nombre", Depmodel.nombre);
            cmd.Parameters.AddWithValue("@comentarios", Depmodel.comentarios);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** Eliminar departamentos *******************
        public bool BorrarDepartamentos(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("spBorrarDepartamentos", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idDepartamento", id);

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