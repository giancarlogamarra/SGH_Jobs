using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Doctor
    {
        public int COD_Doctor { get; set; }
        public int DNI_Doctor { get; set; }
        public string CMP { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int COD_Especialidad { get; set; }

        public override string ToString()
        {
            return string.Format("COD_Doctor={0}, DNI={1}, CMP={2}, Nombres={3}, Apellido={4}, COD_Especialidad={5}"
                , this.COD_Doctor, this.DNI_Doctor, this.CMP, this.Nombres, this.Apellidos, this.COD_Especialidad);
        }
    }
}
