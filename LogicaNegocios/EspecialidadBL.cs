using System;
using Entities;//Para clase Especialidad
using System.Collections.Generic;//Para List<>
using System.Threading.Tasks;//Para Task
using DataAccess;//Para EspecialidadDAL

namespace BusinessLayer
{
    public class EspecialidadBL
    {
        EspecialidadDAL dal = new EspecialidadDAL();//variable dal de clase EspecialidadDAL para ejecutar todas las funciones de esta clase
        //TOdas las funciones estan en EspecialidadDAL, enviamos los parámetros necesarios para cada función
        public async Task<string> InsertEspecialidadAsync(Especialidad Especialidad)//Task: operacion asincrona q devuelve un valor <value>
        {
            string respuesta = await dal.InsertEspecialidadAsync(Especialidad);//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return respuesta;//retorna una cadena
        }
        public async Task<List<Especialidad>> GetEspecialidadsAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            List<Especialidad> Especialidads = await dal.GetEspecialidadAsync();//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return Especialidads;//retorna una lista
        }
        public async Task<Especialidad> GetOneEspecialidadAsync(int IdEspecialidad)
        {
            Especialidad Especialidad = await dal.GetOneEspecialidadAsync(IdEspecialidad);
            return Especialidad;//retorna un objeto de clase Especialidad
        }
        public async Task<string> UpdateEspecialidadAsync(Especialidad Especialidad)
        {
            string respuesta = await dal.UpdateEspecialidadAsync(Especialidad);
            return respuesta;//retorna una cadena
        }
        public async Task<string> DeleteEspecialidadAsync(int IdEspecialidad)
        {
            string respuesta = await dal.DeleteEspecialidadAsync(IdEspecialidad);
            return respuesta;//retorna una cadena
        }
    }
}
