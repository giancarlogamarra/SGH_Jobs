using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Doctor : Persona
    {
        public string CMP;
        public string Especialidad;

        public Doctor(string dni, string nombre, string apellido, string cmp, string especialidad)
        : base(dni, nombre, apellido)
        {
            this.CMP = cmp;
            this.Especialidad = especialidad;
        }
    }
}
