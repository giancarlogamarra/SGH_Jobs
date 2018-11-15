using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Cita
    {
        public string COD { get; set; }
        public string COD_Paciente { get; set; }
        public string COD_Especialidad { get; set; }
        public string COD_Doctor { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }

        public Cita(string cod, string cod_paciente, string cod_especialidad, string cod_doctor, string tipo, string estado)
        {
            COD = cod;
            COD_Paciente = cod_paciente;
            COD_Especialidad = cod_especialidad;
            COD_Doctor = cod_doctor;
            Tipo = tipo;
            Estado = estado;
        }
    }
}
