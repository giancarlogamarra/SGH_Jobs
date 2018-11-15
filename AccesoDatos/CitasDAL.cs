using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AccesoDatos
{
    public class CitasDAL
    {
        public static string ConexionCitas()
        {
            string pathBDCitas = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return pathBDCitas;
        }
    }
}
