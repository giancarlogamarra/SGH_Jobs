using System;

namespace EntidadesNegocio
{
    public class Paciente
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public Paciente(string dni, string nombre, string apellido, DateTime fechadenacimiento) {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaDeNacimiento = fechadenacimiento;
        }
    }
}
