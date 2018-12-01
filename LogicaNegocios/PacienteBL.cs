using System;
using Entities;//Para clase Paciente
using System.Collections.Generic;//Para List<>
using System.Threading.Tasks;//Para Task
using DataAccess;//Para PacienteDAL

namespace BusinessLayer
{
    public class PacienteBL
    {
        PacienteDAL dal = new PacienteDAL();//variable dal de clase PacienteDAL para ejecutar todas las funciones de esta clase
        //TOdas las funciones estan en PacienteDAL, enviamos los parámetros necesarios para cada función
        public async Task<string> InsertPacienteAsync(Paciente Paciente)//Task: operacion asincrona q devuelve un valor <value>
        {
            string respuesta = await dal.InsertPacienteAsync(Paciente);//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return respuesta;//retorna una cadena
        }
        public async Task<List<Paciente>> GetPacientesAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            List<Paciente> Pacientes = await dal.GetPacienteAsync();//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return Pacientes;//retorna una lista
        }
        public async Task<Paciente> GetOnePacienteAsync(int IdPaciente)
        {
            Paciente Paciente = await dal.GetOnePacienteAsync(IdPaciente);
            return Paciente;//retorna un objeto de clase Paciente
        }
        public async Task<string> UpdatePacienteAsync(Paciente Paciente)
        {
            string respuesta = await dal.UpdatePacienteAsync(Paciente);
            return respuesta;//retorna una cadena
        }
        public async Task<string> DeletePacienteAsync(int IdPaciente)
        {
            string respuesta = await dal.DeletePacienteAsync(IdPaciente);
            return respuesta;//retorna una cadena
        }
    }
}
