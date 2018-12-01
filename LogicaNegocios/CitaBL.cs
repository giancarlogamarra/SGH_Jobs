using System;
using Entities;//Para clase Cita
using System.Collections.Generic;//Para List<>
using System.Threading.Tasks;//Para Task
using DataAccess;//Para CitaDAL

namespace BusinessLayer
{
    public class CitaBL
    {
        CitaDAL dal = new CitaDAL();//variable dal de clase CitaDAL para ejecutar todas las funciones de esta clase
        //TOdas las funciones estan en CitaDAL, enviamos los parámetros necesarios para cada función
        public async Task<string> InsertCitaAsync(Cita Cita)//Task: operacion asincrona q devuelve un valor <value>
        {
            string respuesta = await dal.InsertCitaAsync(Cita);//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return respuesta;//retorna una cadena
        }
        public async Task<List<Cita>> GetCitasAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            List<Cita> Citas = await dal.GetCitaAsync();//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return Citas;//retorna una lista
        }
        public async Task<Cita> GetOneCitaAsync(int IdCita)
        {
            Cita Cita = await dal.GetOneCitaAsync(IdCita);
            return Cita;//retorna un objeto de clase Cita
        }
        public async Task<string> UpdateCitaAsync(Cita Cita)
        {
            string respuesta = await dal.UpdateCitaAsync(Cita);
            return respuesta;//retorna una cadena
        }
        public async Task<string> DeleteCitaAsync(int IdCita)
        {
            string respuesta = await dal.DeleteCitaAsync(IdCita);
            return respuesta;//retorna una cadena
        }
    }
}
