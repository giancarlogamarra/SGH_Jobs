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
    public class EspecialidadDAL : Connection
    {
        public async Task<string> InsertEspecialidadAsync(Especialidad Especialidad)//Insertar un alumno asíncrono | Task<string>: devuelve una cadena
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            string Sql;//cadena que contendrá la consulta SQL
            string Nombre = Especialidad.NOM_Especialidad;//Parámetro recibido del objeto de clase Alumno
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta

            try
            {
                if (connection != null)//Si la conexion esta establecida
                {
                    Sql = @"INSERT INTO tespecialidad (Nombre) VALUES ('"+ Nombre +"')";//Consulta cargando los datos para el INSERT
                    FilasAfectadas = await connection.ExecuteAsync(Sql);//Ejecutamos la consulta
                }
                return "Se ha logrado insertar un Especialidad";//Mensaje de confirmación
            }
            catch (Exception ex)//Exception ex : nos permite ver el error por el cual no se ha ejecutado la sentencia
            {
                Console.WriteLine("Error Consultando: " + ex.Message);//El programa devuelve un mensaje con el error
                return "no se ha logrado insertar";//Mensaje de denegación
            }
        }

        public async Task<List<Especialidad>> GetEspecialidadAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                List<Especialidad> EspecialidadList = null;//Se crea una lista de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    EspecialidadList = (await connection.QueryAsync<Especialidad>//Ejecuta una consulta asincrona
                        (@"SELECT * FROM tespecialidad")).ToList();//Agrega el objeto obtenido de la consulta a la lista
                }
                return EspecialidadList;//Retorna la lista para ser mostrada
            }
            catch
            {
                return null;//Si falla retorna nulo
            }
        }

        public async Task<Especialidad> GetOneEspecialidadAsync(int COD_Especialidad)//Obtener un solo alumno
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                Especialidad Especialidad = null;//Se crea un objeto de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    Especialidad = await connection.QueryFirstAsync<Especialidad>//Consulta para obtener un solo alumno segun el IdAlumno
                        (@"SELECT COD_Especialidad, Nombre FROM tespecialidad WHERE COD_Especialidad = @COD_Especialidad", new
                        {
                            //IdAlumno = IdAlumno
                            COD_Especialidad
                        });
                }
                return Especialidad;//Si se realiza la consulta, retornamos el objeto de clase Alumno
            }
            catch
            {
                return null;//Si falla retornamos null
            }
        }

        public async Task<string> UpdateEspecialidadAsync(Especialidad Especialidad)//Actualizar alumno asíncrono con Task<> | Recibe un objeto Alumno 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;
            int COD_Especialidad = Especialidad.COD;
            string Nombre = Especialidad.NOM_Especialidad;//Parámetro recibido del objeto de clase Alumno
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta
            try
            {
                if (connection != null)
                {
                    Sql = "UPDATE tespecialidad SET  Nombre = '" + Nombre + "' WHERE COD_Especialidad = '" + COD_Especialidad + "'";//Consulta con los datos cargados
                    FilasAfectadas = await connection.ExecuteAsync(Sql);// Se ejecuta la consulta
                }
                return "Se ha actualizado correctamente la tabla especialidad";// Mensaje de confirmación
            }
            catch
            {
                return "No se ha podido actualizar el registro";//Mensaje de denegación
            }
        }

        public async Task<string> DeleteEspecialidadAsync(int COD_Especialidad)//Eliminar alumno asíncrono. Task<> 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;
            int FilasAfectadas;
            try
            {
                Sql = "DELETE FROM tespecialidad WHERE COD_Especialidad = '" + COD_Especialidad + "'";//Consulta SQL para eliminar
                FilasAfectadas = await connection.ExecuteAsync(Sql);//Se ejecuta
                return "Se ha eliminado el registro de la tabla Especialidad";//Aceptado
            }
            catch
            {
                return "No se ha podido eliminar el registro";//Denegado
            }
        }

    }
}
