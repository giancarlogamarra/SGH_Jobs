using System;
using System.Collections.Generic;//Para list<>
using System.Text;
using System.Threading.Tasks;//Para Task
using Entities;//Para la clase Alumno
using MySql.Data.MySqlClient;//Para MySqlConnection
using Dapper;//Para .QueryAsync<> (Linea 22) 
using System.Linq;//Para .ToList (Linea 23) 
//Revisar ASYNC y AWAIT https://msdn.microsoft.com/es-es/library/hh191443(v=vs.120)

namespace DataAccess
{
    public class DoctorDAL : Connection
    {
        public async Task<string> InsertDoctorAsync(Doctor Doctor)//Insertar un alumno asíncrono | Task<string>: devuelve una cadena
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            string Sql;//cadena que contendrá la consulta SQL
            int Dni = Doctor.DNI_Doctor;//Parámetro recibido del objeto de clase Alumno
            string CMP = Doctor.CMP;
            string Nombre = Doctor.Nombres;//Parámetro recibido del objeto de clase Alumno
            string Apellido = Doctor.Apellidos;//Parámetro recibido del objeto de clase Alumno
            int COD_Especialidad = Doctor.COD_Especialidad;
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta

            try
            {
                if (connection != null)//Si la conexion esta establecida
                {
                    Sql = @"INSERT INTO tdoctor (DNI_Doctor, CMP, Nombres, Apellidos, COD_Especialidad ) VALUES ('" + Dni + "','" + CMP + "','" + Nombre + "','" + Apellido + "','" + COD_Especialidad +"')";//Consulta cargando los datos para el INSERT
                    FilasAfectadas = await connection.ExecuteAsync(Sql);//Ejecutamos la consulta
                }
                return "Se ha logrado insertar un doctor";//Mensaje de confirmación
            }
            catch (Exception ex)//Exception ex : nos permite ver el error por el cual no se ha ejecutado la sentencia
            {
                Console.WriteLine("Error Consultando: " + ex.Message);//El programa devuelve un mensaje con el error
                return "no se ha logrado insertar";//Mensaje de denegación
            }
        }

        public async Task<List<Doctor>> GetDoctorAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                List<Doctor> DoctorList = null;//Se crea una lista de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    DoctorList = (await connection.QueryAsync<Doctor>//Ejecuta una consulta asincrona
                        (@"SELECT * FROM tdoctor")).ToList();//Agrega el objeto obtenido de la consulta a la lista
                }
                return DoctorList;//Retorna la lista para ser mostrada
            }
            catch
            {
                return null;//Si falla retorna nulo
            }
        }

        public async Task<Doctor> GetOneDoctorAsync(int COD_Doctor)//Obtener un solo alumno
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                Doctor Doctor = null;//Se crea un objeto de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    Doctor = await connection.QueryFirstAsync<Doctor>//Consulta para obtener un solo alumno segun el IdAlumno
                        (@"SELECT * FROM tdoctor WHERE COD_Doctor = @COD_Doctor", new
                        {
                            //IdAlumno = IdAlumno
                            COD_Doctor
                        });
                }
                return Doctor;//Si se realiza la consulta, retornamos el objeto de clase Alumno
            }
            catch
            {
                return null;//Si falla retornamos null
            }
        }

        public async Task<string> UpdateDoctorAsync(Doctor Doctor)//Actualizar alumno asíncrono con Task<> | Recibe un objeto Alumno 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;
            int COD_Doctor = Doctor.COD_Doctor;
            int Dni = Doctor.DNI_Doctor;//Parámetro recibido del objeto de clase Alumno
            string CMP = Doctor.CMP;
            string Nombre = Doctor.Nombres;//Parámetro recibido del objeto de clase Alumno
            string Apellido = Doctor.Apellidos;//Parámetro recibido del objeto de clase Alumno
            int COD_Especialidad = Doctor.COD_Especialidad;
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta
            try
            {
                if (connection != null)
                {
                    Sql = "UPDATE tdoctor SET  DNI_Doctor = '" + Dni + "', CMP = '" + CMP + "', Nombres = '" + Nombre + "', Apellidos = '" + Apellido + "', COD_Especialidad = '" + COD_Especialidad + "' WHERE COD_Doctor = '" + COD_Doctor + "'";//Consulta con los datos cargados
                    FilasAfectadas = await connection.ExecuteAsync(Sql);// Se ejecuta la consulta
                }
                return "Se ha actualizado correctamente la tabla doctor";// Mensaje de confirmación
            }
            catch
            {
                return "No se ha podido actualizar el registro";//Mensaje de denegación
            }
        }

        public async Task<string> DeleteDoctorAsync(int COD_Doctor)//Eliminar alumno asíncrono. Task<> 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;
            int FilasAfectadas;
            try
            {
                Sql = "DELETE FROM tdoctor WHERE COD_Doctor = '" + COD_Doctor + "'";//Consulta SQL para eliminar
                FilasAfectadas = await connection.ExecuteAsync(Sql);//Se ejecuta
                return "Se ha eliminado el registro de la tabla Doctor";//Aceptado
            }
            catch
            {
                return "No se ha podido eliminar el registro";//Denegado
            }
        }

    }
}
