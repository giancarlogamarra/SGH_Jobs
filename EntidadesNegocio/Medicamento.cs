using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Medicamento
    {
        public int COD_Prod { get; set; }
        public string NOM_Prod { get; set; }
        public string Concent { get; set; }
        public string NOM_Form_Farm { get; set; }
        public string NOM_Form_Farm_Simplif { get; set; }
        public string Presentac { get; set; }
        public int Fracciones { get; set; }
        public string Fec_Vcto_Reg_Sanitario { get; set; }
        public string Num_RegSan { get; set; }
        public string Nom_Titular { get; set; }
        public string Situacion { get; set; }

        public Medicamento (string nom_prod, string concent, string nom_form_farm, string nom_form_farm_simplif, string presentac, 
            int fracciones, string fec_vcto_reg_sanitario, string num_regsan, string nom_titular, string situacion)
        {
            NOM_Prod = nom_prod;
            Concent = concent;
            NOM_Form_Farm = nom_form_farm;
            NOM_Form_Farm_Simplif = nom_form_farm_simplif;
            Presentac = presentac;
            Fracciones = fracciones;
            Fec_Vcto_Reg_Sanitario = fec_vcto_reg_sanitario;
            Num_RegSan = num_regsan;
            Nom_Titular = nom_titular;
            Situacion = situacion;
        }

        public override string ToString()
        {
            return string.Format("NOM_Prod={0}, Concent={1}, NOM_Form_Farm={2}, NOM_Form_Farm_Simplif={3}, Presentac={4}, Fracciones={5}" +
                "Fec_Vcto_Reg_Sanitario={6}, Num_RegSan={7}, Nom_Titular={8}, Situacion={9}"
                , this.NOM_Prod, this.Concent, this.NOM_Form_Farm, this.NOM_Form_Farm_Simplif, this.Presentac, this.Fracciones
                , this.Fec_Vcto_Reg_Sanitario, this.Num_RegSan, this.Nom_Titular, this.Situacion);
        }
    }
}
