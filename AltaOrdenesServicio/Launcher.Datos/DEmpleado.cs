using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;



namespace Sistema.Datos
{
    public class DEmpleado
    {
        private enum TipoMovimiento
        {
            Consultar = 0,
            Insertar = 1,
            Actualizar = 2
        }
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_Empleado_Listar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
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
        public DataTable BuscarEmpleado(string ID_Empleado, string Nombre_Empleado, bool Catalogo = false)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_Empleado_Buscar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandTimeout = 99999999;
                Comando.Parameters.Add("@empleado", SqlDbType.VarChar).Value = ID_Empleado;
                Comando.Parameters.Add("@Nombre_Empleado", SqlDbType.VarChar).Value = Nombre_Empleado;
                Comando.Parameters.Add("@prmCatalogo", SqlDbType.Bit).Value = Catalogo;
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

