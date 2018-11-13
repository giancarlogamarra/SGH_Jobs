using EntidadesNegocio;
using System.Reflection;

namespace AccesoDatos
{
    public class PacientesDAL
    {
        public static string ConexionPacientes() {
            string pathBDPacientes= System.IO.Path.GetDirectoryName(
                Assembly.GetEntryAssembly().Location);
            return pathBDPacientes;
        }
    }
}
