using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace AccesoDatos
{
    public class EspecialidadDAL
    {
        public static string ConexionCitas()
        {
            string pathBDCitas = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return pathBDCitas;
        }
    }
}
