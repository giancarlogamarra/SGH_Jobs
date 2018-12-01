using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Diagnostico
    {
        public int COD_Diagnostico { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public Diagnostico (int cod_diagnostico, string codigo, string descripcion)
        {
            COD_Diagnostico = cod_diagnostico;
            Codigo = codigo;
            Descripcion = descripcion;
        }
        public override string ToString()
        {
            return string.Format("COD_Diagnostico={0}, Codigo={1}, Descripcion={2}"
                , this.COD_Diagnostico, this.Codigo, this.Descripcion);
        }
    }
}
