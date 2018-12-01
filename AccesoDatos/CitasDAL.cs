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
    public class CitaDAL : Connection
    {
        public async Task<string> InsertCitaAsync(Cita Cita)//Insertar un alumno asíncrono | Task<string>: devuelve una cadena
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            string Sql;//cadena que contendrá la consulta SQL
            string Tipo = Cita.Tipo;//Parámetro recibido del objeto de clase Alumno
            string Estado = Cita.Estado;
            int DNI_Paciente = Cita.DNI_Paciente;//Parámetro recibido del objeto de clase Alumno
            int COD_Especialidad = Cita.COD_Especialidad;//Parámetro recibido del objeto de clase Alumno
            int COD_Doctor = Cita.COD_Doctor;
            int COD_Diagnostico = Cita.COD_Diagnostico;
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta

            try
            {
                if (connection != null)//Si la conexion esta establecida
                {
                    Sql = @"INSERT INTO tcita (Tipo, Estado, DNI_Paciente, COD_Especialidad, COD_Doctor, COD_Diagnostico ) VALUES ('" + Tipo + "','" + Estado + "','" + DNI_Paciente + "','" + COD_Especialidad + "','" + COD_Doctor + "','" + COD_Diagnostico + "')";//Consulta cargando los datos para el INSERT
                    FilasAfectadas = await connection.ExecuteAsync(Sql);//Ejecutamos la consulta
                }
                return "Se ha logrado insertar una cita";//Mensaje de confirmación
            }
            catch (Exception ex)//Exception ex : nos permite ver el error por el cual no se ha ejecutado la sentencia
            {
                Console.WriteLine("Error Consultando: " + ex.Message);//El programa devuelve un mensaje con el error
                return "no se ha logrado insertar";//Mensaje de denegación
            }
        }

        public async Task<List<Cita>> GetCitaAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                List<Cita> CitaList = null;//Se crea una lista de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    CitaList = (await connection.QueryAsync<Cita>//Ejecuta una consulta asincrona
                        (@"SELECT * FROM tcita")).ToList();//Agrega el objeto obtenido de la consulta a la lista
                }
                return CitaList;//Retorna la lista para ser mostrada
            }
            catch
            {
                return null;//Si falla retorna nulo
            }
        }

        public async Task<Cita> GetOneCitaAsync(int COD_Cita)//Obtener un solo alumno
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                Cita Cita = null;//Se crea un objeto de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    Cita = await connection.QueryFirstAsync<Cita>//Consulta para obtener un solo alumno segun el IdAlumno
                        (@"SELECT * FROM tcita WHERE COD_Cita = @COD_Cita", new
                        {
                            //IdAlumno = IdAlumno
                            COD_Cita
                        });
                }
                return Cita;//Si se realiza la consulta, retornamos el objeto de clase Alumno
            }
            catch
            {
                return null;//Si falla retornamos null
            }
        }

        public async Task<string> UpdateCitaAsync(Cita Cita)//Actualizar alumno asíncrono con Task<> | Recibe un objeto Alumno 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;//cadena que contendrá la consulta SQL
            int COD_Cita = Cita.COD_Cita;
            string Tipo = Cita.Tipo;//Parámetro recibido del objeto de clase Alumno
            string Estado = Cita.Estado;
            int DNI_Paciente = Cita.DNI_Paciente;//Parámetro recibido del objeto de clase Alumno
            int COD_Especialidad = Cita.COD_Especialidad;//Parámetro recibido del objeto de clase Alumno
            int COD_Doctor = Cita.COD_Doctor;
            int COD_Diagnostico = Cita.COD_Diagnostico;
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta
            try
            {
                if (connection != null)
                {
                    Sql = "UPDATE tcita SET  Tipo = '" + Tipo + "', Estado = '" + Estado + "', DNI_Paciente = '" + DNI_Paciente + "', COD_Especialidad = '" + COD_Especialidad + "', COD_Doctor = '" + COD_Doctor + "', COD_Diagnostico = '" + COD_Diagnostico + "' WHERE COD_Cita = '" + COD_Cita + "'";//Consulta con los datos cargados
                    FilasAfectadas = await connection.ExecuteAsync(Sql);// Se ejecuta la consulta
                }
                return "Se ha actualizado correctamente la tabla cita";// Mensaje de confirmación
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Consultando: " + ex.Message);
                return "No se ha podido actualizar el registro";//Mensaje de denegación
            }
        }

        public async Task<string> DeleteCitaAsync(int COD_Cita)//Eliminar alumno asíncrono. Task<> 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;
            int FilasAfectadas;
            try
            {
                Sql = "DELETE FROM tcita WHERE COD_Cita = '" + COD_Cita + "'";//Consulta SQL para eliminar
                FilasAfectadas = await connection.ExecuteAsync(Sql);//Se ejecuta
                return "Se ha eliminado el registro de la tabla Cita";//Aceptado
            }
            catch
            {
                return "No se ha podido eliminar el registro";//Denegado
            }
        }

    }
}
