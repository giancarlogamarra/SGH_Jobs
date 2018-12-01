using System;
using Entities;
using BusinessLayer;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace SGH
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
            Console.ReadKey();
        }
        static async Task MainAsync()//Operación asíncrona (no sé porqué debemos poner las funciones aquí :V)
        {
            //PACIENTE
            //INSERTAR UN Paciente
            Paciente paciente = new Paciente()//Instanciamos un Paciente
            {
                DNI_Paciente = 76157208,
                Nombres = "Eliezer",
                Apellidos = "Quispe",
                FechaNacimiento = "11/01/1995",
                Tipo = "Asegurado",
            };

            Console.WriteLine(await InsertPacienteAsync(paciente));//llamamos a la funcion y al finalizar mostramos un mensaje

            //MOSTRAR TODOS LOS PacienteS
            List<Paciente> MiLista = await GetPacientesAsync();//Lista de clase Paciente y llamamos a la función
            foreach (var item in MiLista)//Recorremos la lista obtenida
            {
                Console.WriteLine(item);//Mostramos cada objeto de la lista
            }

            //MOSTRAR UN Paciente
            Console.WriteLine(await GetOnePacienteAsync(76157207));//Enviamos el IdPaciente

            //ACTUALIZAR DATOS DE PACIENTE
            Paciente paciente1 = new Paciente()//Instanciamos un Paciente
            {
                DNI_Paciente = 76157207,
                Nombres = "Josue",
                Apellidos = "Quispe",
                FechaNacimiento = "11/01/1995",
                Tipo = "Asegurado",
            };
            Console.WriteLine(await UpdatePacienteAsync(paciente1));//Actualizamos un alumno enviandole todo un objeto Alumno

            //MOSTRAR TODOS LOS PacienteS
            List<Paciente> MiLista1 = await GetPacientesAsync();//Lista de clase Paciente y llamamos a la función
            foreach (var item in MiLista1)//Recorremos la lista obtenida
            {
                Console.WriteLine(item);//Mostramos cada objeto de la lista
            };

            //ELIMINAR PACIENTE
            Console.WriteLine(await DeletePacienteAsync(76157207));//Eliminamos el alumno enviando solo el Id

            //DOCTORES
            //INSERTAR UN Doctor
            Doctor Doctor = new Doctor()//Instanciamos un Doctor
            {
                DNI_Doctor = 76157207,
                CMP = "DOC1MINSA",
                Nombres = "Carlos",
                Apellidos = "Tevez",
                COD_Especialidad = 1,
            };

            Console.WriteLine(await InsertDoctorAsync(Doctor));//llamamos a la funcion y al finalizar mostramos un mensaje

            //MOSTRAR TODOS LOS DoctorS
            List<Doctor> MiLista2 = await GetDoctorsAsync();//Lista de clase Doctor y llamamos a la función
            foreach (var item in MiLista2)//Recorremos la lista obtenida
            {
                Console.WriteLine(item);//Mostramos cada objeto de la lista
            }

            //MOSTRAR UN Doctor
            Console.WriteLine(await GetOneDoctorAsync(2));//Enviamos el IdDoctor

            //ACTUALIZAR DATOS DE DOCTOR
            Doctor Doctor1 = new Doctor()//Instanciamos un Doctor
            {
                COD_Doctor = 2,
                DNI_Doctor = 76157207,
                CMP = "DOC2MINSA",
                Nombres = "Charles",
                Apellidos = "Puyol",
                COD_Especialidad = 2,
            };
            Console.WriteLine(await UpdateDoctorAsync(Doctor1));//Actualizamos un alumno enviandole todo un objeto Alumno

            //MOSTRAR TODOS LOS DoctorS
            List<Doctor> MiLista3 = await GetDoctorsAsync();//Lista de clase Doctor y llamamos a la función
            foreach (var item in MiLista3)//Recorremos la lista obtenida
            {
                Console.WriteLine(item);//Mostramos cada objeto de la lista
            };

            //ELIMINAR DOCTOR
            Console.WriteLine(await DeleteDoctorAsync(3));//Eliminamos el alumno enviando solo el Id

            //CITAS
            //INSERTAR UN Cita
            Cita Cita = new Cita()//Instanciamos un Cita
            {
                Tipo = "NORMAL",
                Estado = "PENDIENTE",
                DNI_Paciente = 76157208,
                COD_Especialidad = 2,
                COD_Doctor = 2,
                COD_Diagnostico = 14
            };

            Console.WriteLine(await InsertCitaAsync(Cita));//llamamos a la funcion y al finalizar mostramos un mensaje

            //MOSTRAR TODOS LOS CitaS
            List<Cita> MiLista4 = await GetCitasAsync();//Lista de clase Cita y llamamos a la función
            foreach (var item in MiLista4)//Recorremos la lista obtenida
            {
                Console.WriteLine(item);//Mostramos cada objeto de la lista
            }

            //MOSTRAR UN Cita
            Console.WriteLine(await GetOneCitaAsync(1));//Enviamos el IdCita

            //ACTUALIZAR DATOS DE CITA
            Cita Cita1 = new Cita()//Instanciamos un Cita
            {
                COD_Cita = 2,
                Tipo = "INTERCONSULTA",
                Estado = "CANCELADA",
                DNI_Paciente = 76157208,
                COD_Especialidad = 2,
                COD_Doctor = 3,
                COD_Diagnostico = 13
            };
            Console.WriteLine(await UpdateCitaAsync(Cita1));//Actualizamos un alumno enviandole todo un objeto Alumno

            //MOSTRAR TODOS LOS CitaS
            List<Cita> MiLista5 = await GetCitasAsync();//Lista de clase Cita y llamamos a la función
            foreach (var item in MiLista5)//Recorremos la lista obtenida
            {
                Console.WriteLine(item);//Mostramos cada objeto de la lista
            };

            //ELIMINAR CITA
            Console.WriteLine(await DeleteCitaAsync(3));//Eliminamos el alumno enviando solo el Id

        }

        //PACIENTE
        static PacienteBL bl = new PacienteBL();//variable dal de clase PacienteBL para ejecutar todas las funciones de esta clase

        //Todas las funciones estan en PacienteBL, enviamos los parámetros necesarios para cada función
        public static async Task<string> InsertPacienteAsync(Paciente Paciente)
        {
            return await bl.InsertPacienteAsync(Paciente);
        }
        public static async Task<List<Paciente>> GetPacientesAsync()
        {
            return await bl.GetPacientesAsync();
        }
        public static async Task<Paciente> GetOnePacienteAsync(int IdPaciente)
        {
            return await bl.GetOnePacienteAsync(IdPaciente);
        }
        public static async Task<string> UpdatePacienteAsync(Paciente Paciente)
        {
            return await bl.UpdatePacienteAsync(Paciente);
        }
        public static async Task<string> DeletePacienteAsync(int IdPaciente)
        {
            return await bl.DeletePacienteAsync(IdPaciente);
        }

        //DOCTOR

        static DoctorBL bl1 = new DoctorBL();//variable dal de clase DoctorBL para ejecutar todas las funciones de esta clase

        //Todas las funciones estan en DoctorBL, enviamos los parámetros necesarios para cada función
        public static async Task<string> InsertDoctorAsync(Doctor Doctor)
        {
            return await bl1.InsertDoctorAsync(Doctor);
        }
        public static async Task<List<Doctor>> GetDoctorsAsync()
        {
            return await bl1.GetDoctorsAsync();
        }
        public static async Task<Doctor> GetOneDoctorAsync(int IdDoctor)
        {
            return await bl1.GetOneDoctorAsync(IdDoctor);
        }
        public static async Task<string> UpdateDoctorAsync(Doctor Doctor)
        {
            return await bl1.UpdateDoctorAsync(Doctor);
        }
        public static async Task<string> DeleteDoctorAsync(int IdDoctor)
        {
            return await bl1.DeleteDoctorAsync(IdDoctor);
        }
        //CITA
        static CitaBL bl2 = new CitaBL();//variable dal de clase CitaBL para ejecutar todas las funciones de esta clase

        //Todas las funciones estan en CitaBL, enviamos los parámetros necesarios para cada función
        public static async Task<string> InsertCitaAsync(Cita Cita)
        {
            return await bl2.InsertCitaAsync(Cita);
        }
        public static async Task<List<Cita>> GetCitasAsync()
        {
            return await bl2.GetCitasAsync();
        }
        public static async Task<Cita> GetOneCitaAsync(int IdCita)
        {
            return await bl2.GetOneCitaAsync(IdCita);
        }
        public static async Task<string> UpdateCitaAsync(Cita Cita)
        {
            return await bl2.UpdateCitaAsync(Cita);
        }
        public static async Task<string> DeleteCitaAsync(int IdCita)
        {
            return await bl2.DeleteCitaAsync(IdCita);
        }
    }
}
