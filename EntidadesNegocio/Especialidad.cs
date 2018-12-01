using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Especialidad
    {
        public int COD { get; set; }
        public string NOM_Especialidad { get; set; }

        public Especialidad (int cod, string nom_especialidad)
        {
            COD = cod;
            NOM_Especialidad = nom_especialidad;
        }

        public override string ToString()
        {
            return string.Format("COD_Especialidad={0}, NOM_Especialidad={1}"
                , this.COD, this.NOM_Especialidad);
        }
    }
}
