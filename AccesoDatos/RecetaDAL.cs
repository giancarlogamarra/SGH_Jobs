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
    public class RecetaDAL : Connection
    {
        public async Task<string> InsertRecetaAsync(Receta Receta)//Insertar un alumno asíncrono | Task<string>: devuelve una cadena
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            string Sql;//cadena que contendrá la consulta SQL
            int COD_Medicamento = Receta.COD_Medicamento;//Parámetro recibido del objeto de clase Alumno
            string Aplicacion = Receta.Aplicacion;
            int COD_Diagnostico = Receta.COD_Diagnostico;//Parámetro recibido del objeto de clase Alumno

            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta

            try
            {
                if (connection != null)//Si la conexion esta establecida
                {
                    Sql = @"INSERT INTO treceta (COD_Medicamento, Aplicacion, COD_Diagnostico ) VALUES ('" + COD_Medicamento + "','" + Aplicacion + "','" + COD_Diagnostico + ")";//Consulta cargando los datos para el INSERT
                    FilasAfectadas = await connection.ExecuteAsync(Sql);//Ejecutamos la consulta
                }
                return "Se ha logrado insertar una Receta";//Mensaje de confirmación
            }
            catch (Exception ex)//Exception ex : nos permite ver el error por el cual no se ha ejecutado la sentencia
            {
                Console.WriteLine("Error Consultando: " + ex.Message);//El programa devuelve un mensaje con el error
                return "no se ha logrado insertar";//Mensaje de denegación
            }
        }

        public async Task<List<Receta>> GetRecetaAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                List<Receta> RecetaList = null;//Se crea una lista de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    RecetaList = (await connection.QueryAsync<Receta>//Ejecuta una consulta asincrona
                        (@"SELECT * FROM treceta")).ToList();//Agrega el objeto obtenido de la consulta a la lista
                }
                return RecetaList;//Retorna la lista para ser mostrada
            }
            catch
            {
                return null;//Si falla retorna nulo
            }
        }

        public async Task<Receta> GetOneRecetaAsync(int COD_Receta)//Obtener un solo alumno
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                Receta Receta = null;//Se crea un objeto de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    Receta = await connection.QueryFirstAsync<Receta>//Consulta para obtener un solo alumno segun el IdAlumno
                        (@"SELECT * FROM treceta WHERE COD_Receta = @COD_Receta", new
                        {
                            //IdAlumno = IdAlumno
                            COD_Receta
                        });
                }
                return Receta;//Si se realiza la consulta, retornamos el objeto de clase Alumno
            }
            catch
            {
                return null;//Si falla retornamos null
            }
        }

        public async Task<string> UpdateRecetaAsync(Receta Receta)//Actualizar alumno asíncrono con Task<> | Recibe un objeto Alumno 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;
            int COD_Receta = Receta.COD_Receta;
            int COD_Medicamento = Receta.COD_Medicamento;//Parámetro recibido del objeto de clase Alumno
            string Aplicacion = Receta.Aplicacion;
            int COD_Diagnostico = Receta.COD_Diagnostico;
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta
            try
            {
                if (connection != null)
                {
                    Sql = "UPDATE treceta SET  COD_Medicamento = '" + COD_Medicamento + "', Aplicacion = '" + Aplicacion + "', COD_Diagnostico = '" + COD_Diagnostico + "' WHERE COD_Receta = '" + COD_Receta + "'";//Consulta con los datos cargados
                    FilasAfectadas = await connection.ExecuteAsync(Sql);// Se ejecuta la consulta
                }
                return "Se ha actualizado correctamente la tabla Receta";// Mensaje de confirmación
            }
            catch
            {
                return "No se ha podido actualizar el registro";//Mensaje de denegación
            }
        }

        public async Task<string> DeleteRecetaAsync(int COD_Receta)//Eliminar alumno asíncrono. Task<> 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;
            int FilasAfectadas;
            try
            {
                Sql = "DELETE FROM tReceta WHERE COD_Receta = '" + COD_Receta + "'";//Consulta SQL para eliminar
                FilasAfectadas = await connection.ExecuteAsync(Sql);//Se ejecuta
                return "Se ha eliminado el registro de la tabla Receta";//Aceptado
            }
            catch
            {
                return "No se ha podido eliminar el registro";//Denegado
            }
        }

    }
}
