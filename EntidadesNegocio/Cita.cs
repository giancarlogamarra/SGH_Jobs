using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Cita
    {
        public int COD_Cita { get; set; }
        public int DNI_Paciente { get; set; }
        public int COD_Especialidad { get; set; }
        public int COD_Doctor { get; set; }
        public int COD_Diagnostico { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }

        public override string ToString()
        {
            return string.Format("COD_Cita={0} , DNI_Paciente={1}, COD_Especialidad={2}, COD_Doctor={3}, COD_Diagnostico={4}, Tipo={5}, Estado={6}"
                , this.COD_Cita, this.DNI_Paciente, this.COD_Especialidad, this.COD_Doctor, this.COD_Diagnostico, this.Tipo, this.Estado);
        }
    }
}
