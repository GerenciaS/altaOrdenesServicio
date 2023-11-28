﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Sistema.Datos
{
    public class ClsIni
    {
        public string ficheroINI { get; private set; }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal, int size, string filePath); 

        public ClsIni(string INIPath)
        {
            ficheroINI = INIPath;
        }
        public void EscribirINI(string Seccion, string Clave, string Valor)
        {
            WritePrivateProfileString(Seccion, Clave, Valor, this.ficheroINI);
        }

        public string LeerINI(string Seccion, string Clave)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Seccion, Clave, "", temp, 255, this.ficheroINI);
            return temp.ToString();
        }
    }
}
