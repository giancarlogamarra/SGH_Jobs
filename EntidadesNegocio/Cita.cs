using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Cita
    {
        public string COD { get; set; }
        public Paciente Paciente { get; set; }
        public Doctor Doctor { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }

        public Cita(string cod, Paciente paciente, Doctor doctor, string tipo, string estado)
        {
            COD = cod;
            Paciente = paciente;
            Doctor = doctor;
            Tipo = tipo;
            Estado = estado;
        }
    }
}
