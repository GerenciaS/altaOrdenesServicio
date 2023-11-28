using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Sistema.Datos
{
    public class DBMS
    {
        public int ValidaAccesoOpcionBMS(string Usuario,string Opcion,string ClaveSecreta)
        {
            int Resultado;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SELECT dbo.Fun_Opciones_Permisos (@Prmusuario,@Prmopcion,@Prmclave_secreta)", SqlCon)
                {
                    CommandType = CommandType.Text
                };
                Comando.Parameters.AddWithValue("@Prmusuario", Usuario);
                Comando.Parameters.AddWithValue("@Prmopcion", Opcion);
                Comando.Parameters.AddWithValue("@Prmclave_secreta", ClaveSecreta);
                SqlCon.Open();
                Resultado = Convert.ToInt16(Comando.ExecuteScalar());
                return Resultado;
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
        public string ObtenDescripcionOpcionBMS(string OpcionBMS)
        {
            string Resultado;
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SELECT TOP 1 nombre FROM opciones_BMS WHERE opcion=@Opcion", SqlCon)
                {
                    CommandType = CommandType.Text
                };
                Comando.Parameters.AddWithValue("@Opcion", OpcionBMS);
                SqlCon.Open();
                Resultado = Convert.ToString(Comando.ExecuteScalar()).Trim();
                return Resultado;
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
