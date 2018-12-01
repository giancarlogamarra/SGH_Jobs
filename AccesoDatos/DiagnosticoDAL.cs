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
    public class DiagnosticoDAL : Connection
    {
        public async Task<string> InsertDiagnosticoAsync(Diagnostico Diagnostico)//Insertar un alumno asíncrono | Task<string>: devuelve una cadena
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            string Sql;//cadena que contendrá la consulta SQL
            string Codigo = Diagnostico.Codigo;
            string Descripcion = Diagnostico.Descripcion;//Parámetro recibido del objeto de clase Alumno
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta

            try
            {
                if (connection != null)//Si la conexion esta establecida
                {
                    Sql = @"INSERT INTO tdiagnostico (Codigo, Descripcion) VALUES ('" + Codigo + "','"+ Descripcion +"')";//Consulta cargando los datos para el INSERT
                    FilasAfectadas = await connection.ExecuteAsync(Sql);//Ejecutamos la consulta
                }
                return "Se ha logrado insertar un Diagnostico";//Mensaje de confirmación
            }
            catch (Exception ex)//Exception ex : nos permite ver el error por el cual no se ha ejecutado la sentencia
            {
                Console.WriteLine("Error Consultando: " + ex.Message);//El programa devuelve un mensaje con el error
                return "no se ha logrado insertar";//Mensaje de denegación
            }
        }

        public async Task<List<Diagnostico>> GetDiagnosticoAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                List<Diagnostico> DiagnosticoList = null;//Se crea una lista de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    DiagnosticoList = (await connection.QueryAsync<Diagnostico>//Ejecuta una consulta asincrona
                        (@"SELECT * FROM tdiagnostico")).ToList();//Agrega el objeto obtenido de la consulta a la lista
                }
                return DiagnosticoList;//Retorna la lista para ser mostrada
            }
            catch
            {
                return null;//Si falla retorna nulo
            }
        }

        public async Task<Diagnostico> GetOneDiagnosticoAsync(int COD_Diagnostico)//Obtener un solo alumno
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                Diagnostico Diagnostico = null;//Se crea un objeto de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    Diagnostico = await connection.QueryFirstAsync<Diagnostico>//Consulta para obtener un solo alumno segun el IdAlumno
                        (@"SELECT * FROM tdiagnostico WHERE COD_Diagnostico = @COD_Diagnostico", new
                        {
                            //IdAlumno = IdAlumno
                            COD_Diagnostico
                        });
                }
                return Diagnostico;//Si se realiza la consulta, retornamos el objeto de clase Alumno
            }
            catch
            {
                return null;//Si falla retornamos null
            }
        }

        public async Task<string> UpdateDiagnosticoAsync(Diagnostico Diagnostico)//Actualizar alumno asíncrono con Task<> | Recibe un objeto Alumno 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;
            int COD_Diagnostico = Diagnostico.COD_Diagnostico;
            string Codigo = Diagnostico.Codigo;
            string Descripcion = Diagnostico.Descripcion;//Parámetro recibido del objeto de clase Alumno
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta
            try
            {
                if (connection != null)
                {
                    Sql = "UPDATE tdiagnostico SET  Codigo = '" + Codigo + "', Descripcion = '" + Descripcion + "' WHERE COD_Diagnostico = '" + COD_Diagnostico + "'";//Consulta con los datos cargados
                    FilasAfectadas = await connection.ExecuteAsync(Sql);// Se ejecuta la consulta
                }
                return "Se ha actualizado correctamente la tabla Diagnostico";// Mensaje de confirmación
            }
            catch
            {
                return "No se ha podido actualizar el registro";//Mensaje de denegación
            }
        }

        public async Task<string> DeleteDiagnosticoAsync(int COD_Diagnostico)//Eliminar alumno asíncrono. Task<> 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;
            int FilasAfectadas;
            try
            {
                Sql = "DELETE FROM tDiagnostico WHERE COD_Diagnostico = '" + COD_Diagnostico + "'";//Consulta SQL para eliminar
                FilasAfectadas = await connection.ExecuteAsync(Sql);//Se ejecuta
                return "Se ha eliminado el registro de la tabla Diagnostico";//Aceptado
            }
            catch
            {
                return "No se ha podido eliminar el registro";//Denegado
            }
        }

    }
}
