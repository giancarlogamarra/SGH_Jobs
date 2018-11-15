using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Especialidad
    {
        public string COD { get; set; }
        public string NOM_Especialidad { get; set; }

        public Especialidad (string cod, string nom_especialidad)
        {
            COD = cod;
            NOM_Especialidad = nom_especialidad;
        }
    }
}
