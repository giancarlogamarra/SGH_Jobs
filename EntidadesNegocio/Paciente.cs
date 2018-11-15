using System;

namespace Entities
{
    public class Paciente : Persona
    {
        public string FechaNacimiento { get; set; }
        public string Tipo { get; set; }

        public Paciente(string dni, string nombre, string apellido, string fechaNacimiento, string tipo)
        : base(dni, nombre, apellido)
        {

            this.FechaNacimiento = fechaNacimiento;
            this.Tipo = tipo;
        }
    }
}
