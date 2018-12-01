using System;
using Entities;//Para clase Diagnostico
using System.Collections.Generic;//Para List<>
using System.Threading.Tasks;//Para Task
using DataAccess;//Para DiagnosticoDAL

namespace BusinessLayer
{
    public class DiagnosticoBL
    {
        DiagnosticoDAL dal = new DiagnosticoDAL();//variable dal de clase DiagnosticoDAL para ejecutar todas las funciones de esta clase
        //TOdas las funciones estan en DiagnosticoDAL, enviamos los parámetros necesarios para cada función
        public async Task<string> InsertDiagnosticoAsync(Diagnostico Diagnostico)//Task: operacion asincrona q devuelve un valor <value>
        {
            string respuesta = await dal.InsertDiagnosticoAsync(Diagnostico);//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return respuesta;//retorna una cadena
        }
        public async Task<List<Diagnostico>> GetDiagnosticosAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            List<Diagnostico> Diagnosticos = await dal.GetDiagnosticoAsync();//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return Diagnosticos;//retorna una lista
        }
        public async Task<Diagnostico> GetOneDiagnosticoAsync(int IdDiagnostico)
        {
            Diagnostico Diagnostico = await dal.GetOneDiagnosticoAsync(IdDiagnostico);
            return Diagnostico;//retorna un objeto de clase Diagnostico
        }
        public async Task<string> UpdateDiagnosticoAsync(Diagnostico Diagnostico)
        {
            string respuesta = await dal.UpdateDiagnosticoAsync(Diagnostico);
            return respuesta;//retorna una cadena
        }
        public async Task<string> DeleteDiagnosticoAsync(int IdDiagnostico)
        {
            string respuesta = await dal.DeleteDiagnosticoAsync(IdDiagnostico);
            return respuesta;//retorna una cadena
        }
    }
}
