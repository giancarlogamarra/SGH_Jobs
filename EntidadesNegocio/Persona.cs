using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Persona
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public Persona(string Dni, string Nombre, string Apellido)
        {
            this.DNI = Dni;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
        }
    }
}
