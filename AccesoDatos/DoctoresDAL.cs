using Entities;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AccesoDatos
{
    public class DoctoresDAL
    {
        public static string ConexionDoctores()
        {
            string pathBDDoctores = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return pathBDDoctores;
        }
    }
}
