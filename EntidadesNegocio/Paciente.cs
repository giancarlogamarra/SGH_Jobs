using System;

namespace Entities
{
    public class Paciente
    {
        public int DNI_Paciente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }
        public string Tipo { get; set; }

        public override string ToString()
        {
            return string.Format("DNI={0}, Nombres={1}, Apellidos={2}, FechaNacimiento={3}, Tipo={4}"
                , this.DNI_Paciente, this.Nombres, this.Apellidos, this.FechaNacimiento, this.Tipo);
        }
    }
}
