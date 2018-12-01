using System;
using Entities;//Para clase Doctor
using System.Collections.Generic;//Para List<>
using System.Threading.Tasks;//Para Task
using DataAccess;//Para DoctorDAL

namespace BusinessLayer
{
    public class DoctorBL
    {
        DoctorDAL dal = new DoctorDAL();//variable dal de clase DoctorDAL para ejecutar todas las funciones de esta clase
        //TOdas las funciones estan en DoctorDAL, enviamos los parámetros necesarios para cada función
        public async Task<string> InsertDoctorAsync(Doctor Doctor)//Task: operacion asincrona q devuelve un valor <value>
        {
            string respuesta = await dal.InsertDoctorAsync(Doctor);//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return respuesta;//retorna una cadena
        }
        public async Task<List<Doctor>> GetDoctorsAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            List<Doctor> Doctors = await dal.GetDoctorAsync();//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return Doctors;//retorna una lista
        }
        public async Task<Doctor> GetOneDoctorAsync(int IdDoctor)
        {
            Doctor Doctor = await dal.GetOneDoctorAsync(IdDoctor);
            return Doctor;//retorna un objeto de clase Doctor
        }
        public async Task<string> UpdateDoctorAsync(Doctor Doctor)
        {
            string respuesta = await dal.UpdateDoctorAsync(Doctor);
            return respuesta;//retorna una cadena
        }
        public async Task<string> DeleteDoctorAsync(int IdDoctor)
        {
            string respuesta = await dal.DeleteDoctorAsync(IdDoctor);
            return respuesta;//retorna una cadena
        }
    }
}
