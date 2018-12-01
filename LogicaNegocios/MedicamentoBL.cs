using System;
using Entities;//Para clase Medicamento
using System.Collections.Generic;//Para List<>
using System.Threading.Tasks;//Para Task
using DataAccess;//Para MedicamentoDAL

namespace BusinessLayer
{
    public class MedicamentoBL
    {
        MedicamentoDAL dal = new MedicamentoDAL();//variable dal de clase MedicamentoDAL para ejecutar todas las funciones de esta clase
        //TOdas las funciones estan en MedicamentoDAL, enviamos los parámetros necesarios para cada función
        public async Task<string> InsertMedicamentoAsync(Medicamento Medicamento)//Task: operacion asincrona q devuelve un valor <value>
        {
            string respuesta = await dal.InsertMedicamentoAsync(Medicamento);//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return respuesta;//retorna una cadena
        }
        public async Task<List<Medicamento>> GetMedicamentosAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            List<Medicamento> Medicamentos = await dal.GetMedicamentoAsync();//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return Medicamentos;//retorna una lista
        }
        public async Task<Medicamento> GetOneMedicamentoAsync(int IdMedicamento)
        {
            Medicamento Medicamento = await dal.GetOneMedicamentoAsync(IdMedicamento);
            return Medicamento;//retorna un objeto de clase Medicamento
        }
        public async Task<string> UpdateMedicamentoAsync(Medicamento Medicamento)
        {
            string respuesta = await dal.UpdateMedicamentoAsync(Medicamento);
            return respuesta;//retorna una cadena
        }
        public async Task<string> DeleteMedicamentoAsync(int IdMedicamento)
        {
            string respuesta = await dal.DeleteMedicamentoAsync(IdMedicamento);
            return respuesta;//retorna una cadena
        }
    }
}
