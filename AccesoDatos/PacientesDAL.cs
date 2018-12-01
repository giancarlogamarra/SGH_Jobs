using System;
using System.Collections.Generic;//Para list<>
using System.Text;
using System.Threading.Tasks;//Para Task
using Entities;//Para la clase Paciente
using MySql.Data.MySqlClient;//Para MySqlConnection
using Dapper;//Para .QueryAsync<> (Linea 22) 
using System.Linq;//Para .ToList (Linea 23) 
//Revisar ASYNC y AWAIT https://msdn.microsoft.com/es-es/library/hh191443(v=vs.120)

namespace DataAccess
{
    public class PacienteDAL : Connection
    {
        public async Task<string> InsertPacienteAsync(Paciente Paciente)//Insertar un Paciente asíncrono | Task<string>: devuelve una cadena
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            string Sql;//cadena que contendrá la consulta SQL
            int Dni = Paciente.DNI_Paciente;//Parámetro recibido del objeto de clase Paciente
            string Nombres = Paciente.Nombres;//Parámetro recibido del objeto de clase Paciente
            string Apellidos = Paciente.Apellidos;//Parámetro recibido del objeto de clase Paciente
            string FechaNacimiento = Paciente.FechaNacimiento;//Parámetro recibido del objeto de clase Paciente
            string Tipo = Paciente.Tipo;
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta

            try
            {
                if (connection != null)//Si la conexion esta establecida
                {
                    Sql = @"INSERT INTO tpaciente VALUES ('" + Dni + "','" + Nombres + "','" + Apellidos + "','" + FechaNacimiento + "','"+Tipo+"')";//Consulta cargando los datos para el INSERT
                    FilasAfectadas = await connection.ExecuteAsync(Sql);//Ejecutamos la consulta
                }
                return "Se ha logrado insertar un paciente";//Mensaje de confirmación
            }
            catch (Exception ex)//Exception ex : nos permite ver el error por el cual no se ha ejecutado la sentencia
            {
                Console.WriteLine("Error Consultando: " + ex.Message);//El programa devuelve un mensaje con el error
                return "no se ha logrado insertar";//Mensaje de denegación
            }
        }

        public async Task<List<Paciente>> GetPacienteAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                List<Paciente> PacientesList = null;//Se crea una lista de tipo Paciente
                if (connection != null)//Si la conexion esta establecida
                {
                    PacientesList = (await connection.QueryAsync<Paciente>//Ejecuta una consulta asincrona
                        (@"SELECT DNI_Paciente, Nombres, Apellidos, FechaNacimiento, Tipo FROM tpaciente")).ToList();//Agrega el objeto obtenido de la consulta a la lista
                }
                return PacientesList;//Retorna la lista para ser mostrada
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Consultando: " + ex.Message);
                return null;//Si falla retorna nulo
            }
        }

        public async Task<Paciente> GetOnePacienteAsync(int DNI_Paciente)//Obtener un solo Paciente
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                Paciente Paciente = null;//Se crea un objeto de tipo Paciente
                if (connection != null)//Si la conexion esta establecida
                {
                    Paciente = await connection.QueryFirstAsync<Paciente>//Consulta para obtener un solo Paciente segun el IdPaciente
                        (@"SELECT DNI_Paciente, Nombres, Apellidos, FechaNacimiento, Tipo FROM tpaciente WHERE DNI_Paciente = @DNI_Paciente", new
                        {
                            //IdPaciente = IdPaciente
                            DNI_Paciente
                        });
                }
                return Paciente;//Si se realiza la consulta, retornamos el objeto de clase Paciente
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Consultando: " + ex.Message);
                return null;//Si falla retornamos null
            }
        }

        public async Task<string> UpdatePacienteAsync(Paciente Paciente)//Actualizar Paciente asíncrono con Task<> | Recibe un objeto Paciente 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;//cadena que contendrá la sentencia SQL
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta
            int DNI_Paciente = Paciente.DNI_Paciente;
            string Nombres = Paciente.Nombres;//Parámetro recibido del objeto de clase Paciente
            string Apellidos = Paciente.Apellidos;//Parámetro recibido del objeto de clase Paciente
            string FechaNacimiento = Paciente.FechaNacimiento;//Parámetro recibido del objeto de clase Paciente
            string Tipo = Paciente.Tipo;
            try
            {
                if (connection != null)
                {
                    Sql = "UPDATE tpaciente SET  Nombres = '" + Nombres + "', Apellidos = '" + Apellidos + "', FechaNacimiento = '" + FechaNacimiento + "', Tipo = '" + Tipo + "' WHERE DNI_Paciente = '" + DNI_Paciente + "'";//Consulta con los datos cargados
                    FilasAfectadas = await connection.ExecuteAsync(Sql);// Se ejecuta la consulta
                }
                return "Se ha actualizado correctamente la tabla paciente";// Mensaje de confirmación
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Consultando: " + ex.Message);
                return "No se ha podido actualizar el registro";//Mensaje de denegación
            }
        }

        public async Task<string> DeletePacienteAsync(int DNI_Paciente)//Eliminar Paciente asíncrono. Task<> 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;
            int FilasAfectadas;
            try
            {
                Sql = "DELETE FROM tpaciente WHERE DNI_Paciente = '" + DNI_Paciente + "'";//Consulta SQL para eliminar
                FilasAfectadas = await connection.ExecuteAsync(Sql);//Se ejecuta
                return "Se ha eliminado el registro de la tabla Paciente";//Aceptado
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Consultando: " + ex.Message);
                return "No se ha podido eliminar el registro";//Denegado
            }
        }

    }
}
