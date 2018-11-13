using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesNegocio
{
    class Medico
    {
        public string Nombre { get; set; }
        public string CMP { get; set; }
        public Medico(string cmp,string nombre) {
            this.CMP = cmp;
            this.Nombre = nombre;
            
        }
    }
}
