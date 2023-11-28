using Sistema.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltaOrdenesServicio
{
    public class Sucursales
    {
        Conexion cn = new Conexion();

        public DataTable CargarCombo()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_CARGARSUCURSALES", cn.CrearConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
