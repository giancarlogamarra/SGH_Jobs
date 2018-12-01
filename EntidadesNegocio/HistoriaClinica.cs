using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class HistoriaClinica
    {
        public int COD_Especialidad { get; set; }
        public DateTime FechaApertura { get; set; }
        public float Peso { get; set; }
        public float Talla { get; set; }
        public int DNI_Paciente { get; set; }

        public HistoriaClinica (int cod_especialidad, DateTime fechaapertura, float peso, float talla, int dni_paciente)
        {
            COD_Especialidad = cod_especialidad;
            FechaApertura = fechaapertura;
            Peso = peso;
            Talla = talla;
            DNI_Paciente = dni_paciente;
        }

        public override string ToString()
        {
            return string.Format("COD_Especialidad={0}, FechaApertura={1}, Peso={2}, Talla={3}, DNI_Paciente={4}"
                , this.COD_Especialidad, this.FechaApertura, this.Peso, this.Talla, this.DNI_Paciente);
        }
    }
}
