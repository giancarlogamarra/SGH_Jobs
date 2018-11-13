using System;

namespace EntidadesNegocio
{
    public class Paciente
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Paciente(string dni, string nombre, string apellido) {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }
    }
}
