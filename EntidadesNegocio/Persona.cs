using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Persona
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public Persona(int Dni, string Nombre, string Apellido)
        {
            this.DNI = Dni;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
        }
    }
}
