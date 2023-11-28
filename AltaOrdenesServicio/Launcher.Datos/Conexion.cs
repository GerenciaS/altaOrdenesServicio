using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
//using System.Windows;
using System.Xml.Linq;
using Sistema.Datos;
using System.Configuration;

namespace Sistema.Datos
{
    public class Conexion
    {

        public const string vsRutaConfiguracion = @"C:\Sistema\Configuracion.ini";
        public const string vsRutaXMLUsuario = @"C:\Sistema\Usuario.XML";

        private readonly string vsBaseDeDatos;
        private readonly string vsServidor;
        private readonly string Usuario;
        private readonly string Clave;
        //private bool Seguridad;
        private static Conexion Con = null;



        public Conexion()
        {
            if (File.Exists(vsRutaConfiguracion))
            {
                ClsIni fINI = new ClsIni(vsRutaConfiguracion);
                this.vsServidor = fINI.LeerINI("CONFIGURACION", "SERVIDOR");
                this.vsBaseDeDatos = fINI.LeerINI("CONFIGURACION", "BASE_DE_DATOS");
            }
            if (File.Exists(vsRutaXMLUsuario))
            {
                Desencryptar d = new Desencryptar();
                XDocument nodoRaiz = XDocument.Load(vsRutaXMLUsuario, LoadOptions.None);
                IEnumerable<XElement> nodo = nodoRaiz.Descendants("Credenciales");

                foreach (XElement ele in nodo)
                {
                    this.Usuario = ele.Attribute("Usuario").Value;
                    this.Clave = d.Descifrar(ele.Attribute("Clave").Value);
                    break;
                }
            }
            //this.Seguridad = false;
        }
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                var connectionString = new SqlConnectionStringBuilder
                {
                    DataSource = this.vsServidor,
                    InitialCatalog = this.vsBaseDeDatos,
                    IntegratedSecurity = false,
                    UserID = this.Usuario,
                    Password = this.Clave,
                    ConnectTimeout = 30
                    //ConnectRetryCount = 3,
                    //ConnectRetryInterval = 10
                };
                Cadena.ConnectionString = connectionString.ConnectionString;
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion GetInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
