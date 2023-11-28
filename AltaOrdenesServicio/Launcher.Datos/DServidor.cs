using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Sistema.Datos
{
   public class DServidor
    {
        public DataTable ObtenFechaServidor()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SELECT DATENAME(dw,GETDATE())+' '+DATENAME(day, GETDATE())+' De '+DATENAME(month, GETDATE())+' De '+DATENAME(year, GETDATE()) ", SqlCon);
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception)
            {
                DataRow dr = Tabla.NewRow();
                DataColumn dc = new DataColumn("Conexion", typeof(Boolean));
                Tabla.Columns.Add(dc);
                dr["Conexion"] = false;
                Tabla.Rows.Add(dr);

                return Tabla;
                //throw ;

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        
        public DataTable ObtenFechaServidor_AM_PM()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SELECT right(convert(varchar(32), GETDATE(), 100), 7)", SqlCon);
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
        public DateTime ObtenFechaServidorGenerico()
        {
            DateTime vdFechaServidor;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SELECT GETDATE()", SqlCon);
                SqlCon.Open();
                vdFechaServidor = Convert.ToDateTime(Comando.ExecuteScalar());
                return vdFechaServidor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
        public DataTable obtenerregistro(string query)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand(query, SqlCon);
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
