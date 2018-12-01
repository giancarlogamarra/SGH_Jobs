using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Receta
    {
        public int COD_Receta { get; set; }
        public int COD_Medicamento { get; set; }
        public string Aplicacion { get; set; }
        public int COD_Diagnostico { get; set; }

        public Receta(int cod_receta, int cod_medicamento, string aplicacion, int cod_diagnostico)
        {
            COD_Receta = cod_receta;
            COD_Medicamento = cod_medicamento;
            Aplicacion = aplicacion;
            COD_Diagnostico = cod_diagnostico;
        }

        public override string ToString()
        {
            return string.Format("COD_Receta={0}, COD_Medicamento={1}, Aplicacion={2}, COD_Diagnostico={3}"
                , this.COD_Receta, this.COD_Medicamento, this.Aplicacion, this.COD_Diagnostico);
        }
    }
}
