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
    public class MedicamentoDAL : Connection
    {
        public async Task<string> InsertMedicamentoAsync(Medicamento Medicamento)//Insertar un alumno asíncrono | Task<string>: devuelve una cadena
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            string Sql;//cadena que contendrá la consulta SQL
            string NOM_Prod = Medicamento.NOM_Prod;//Parámetro recibido del objeto de clase Alumno
            string Concent = Medicamento.Concent;
            string NOM_Form_Farm = Medicamento.NOM_Form_Farm;//Parámetro recibido del objeto de clase Alumno
            string NOM_Form_Farm_Simplif = Medicamento.NOM_Form_Farm_Simplif;//Parámetro recibido del objeto de clase Alumno
            string Presentac = Medicamento.Presentac;
            int Fracciones = Medicamento.Fracciones;
            string Fec_Vcto_Reg_Sanitario = Medicamento.Fec_Vcto_Reg_Sanitario;
            string Num_RegSan = Medicamento.Num_RegSan;
            string Nom_Titular = Medicamento.Nom_Titular;
            string Situacion = Medicamento.Situacion;
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta

            try
            {
                if (connection != null)//Si la conexion esta establecida
                {
                    Sql = @"INSERT INTO tMedicamentos (NOM_Prod, Concent, NOM_Form_Farm, NOM_Form_Farm_Simplif, Presentac, Fracciones, Fec_Vcto_Reg_Sanitario, Num_RegSan, Nom_Titular, Situacion ) 
                            VALUES ('" + NOM_Prod + "','" + Concent + "','" + NOM_Form_Farm + "','" + NOM_Form_Farm_Simplif + "','" + Presentac + "','" + Fracciones + "','" + Fec_Vcto_Reg_Sanitario + "','" + Num_RegSan + "','" + Nom_Titular + "','" + Situacion + "')";//Consulta cargando los datos para el INSERT
                    FilasAfectadas = await connection.ExecuteAsync(Sql);//Ejecutamos la consulta
                }
                return "Se ha logrado insertar una Medicamento";//Mensaje de confirmación
            }
            catch (Exception ex)//Exception ex : nos permite ver el error por el cual no se ha ejecutado la sentencia
            {
                Console.WriteLine("Error Consultando: " + ex.Message);//El programa devuelve un mensaje con el error
                return "no se ha logrado insertar";//Mensaje de denegación
            }
        }

        public async Task<List<Medicamento>> GetMedicamentoAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                List<Medicamento> MedicamentoList = null;//Se crea una lista de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    MedicamentoList = (await connection.QueryAsync<Medicamento>//Ejecuta una consulta asincrona
                        (@"SELECT * FROM tMedicamento")).ToList();//Agrega el objeto obtenido de la consulta a la lista
                }
                return MedicamentoList;//Retorna la lista para ser mostrada
            }
            catch
            {
                return null;//Si falla retorna nulo
            }
        }

        public async Task<Medicamento> GetOneMedicamentoAsync(int COD_Medicamento)//Obtener un solo alumno
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                Medicamento Medicamento = null;//Se crea un objeto de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    Medicamento = await connection.QueryFirstAsync<Medicamento>//Consulta para obtener un solo alumno segun el IdAlumno
                        (@"SELECT * FROM tMedicamentos WHERE COD_Medicamento = @COD_Medicamento", new
                        {
                            //IdAlumno = IdAlumno
                            COD_Medicamento
                        });
                }
                return Medicamento;//Si se realiza la consulta, retornamos el objeto de clase Alumno
            }
            catch
            {
                return null;//Si falla retornamos null
            }
        }

        public async Task<string> UpdateMedicamentoAsync(Medicamento Medicamento)//Actualizar alumno asíncrono con Task<> | Recibe un objeto Alumno 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;//cadena que contendrá la consulta SQL
            int COD_Prod = Medicamento.COD_Prod;
            string NOM_Prod = Medicamento.NOM_Prod;//Parámetro recibido del objeto de clase Alumno
            string Concent = Medicamento.Concent;
            string NOM_Form_Farm = Medicamento.NOM_Form_Farm;//Parámetro recibido del objeto de clase Alumno
            string NOM_Form_Farm_Simplif = Medicamento.NOM_Form_Farm_Simplif;//Parámetro recibido del objeto de clase Alumno
            string Presentac = Medicamento.Presentac;
            int Fracciones = Medicamento.Fracciones;
            string Fec_Vcto_Reg_Sanitario = Medicamento.Fec_Vcto_Reg_Sanitario;
            string Num_RegSan = Medicamento.Num_RegSan;
            string Nom_Titular = Medicamento.Nom_Titular;
            string Situacion = Medicamento.Situacion;
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta
            try
            {
                if (connection != null)
                {
                    Sql = "UPDATE tmedicamento SET  NOM_Prod = '" + NOM_Prod + "', Concent = '" + Concent + "', NOM_Form_Farm = '" + NOM_Form_Farm + 
                        "', NOM_Form_Farm_Simplif = '" + NOM_Form_Farm_Simplif + "', Presentac = '" + Presentac + "', Fracciones = '" + Fracciones +
                        "' WHERE COD_Prod = '" + COD_Prod + "'";//Consulta con los datos cargados
                    FilasAfectadas = await connection.ExecuteAsync(Sql);// Se ejecuta la consulta
                }
                return "Se ha actualizado correctamente la tabla Medicamento";// Mensaje de confirmación
            }
            catch
            {
                return "No se ha podido actualizar el registro";//Mensaje de denegación
            }
        }

        public async Task<string> DeleteMedicamentoAsync(int COD_Medicamento)//Eliminar alumno asíncrono. Task<> 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;
            int FilasAfectadas;
            try
            {
                Sql = "DELETE FROM tmedicamento WHERE COD_Doctor = '" + COD_Medicamento + "'";//Consulta SQL para eliminar
                FilasAfectadas = await connection.ExecuteAsync(Sql);//Se ejecuta
                return "Se ha eliminado el registro de la tabla Medicamento";//Aceptado
            }
            catch
            {
                return "No se ha podido eliminar el registro";//Denegado
            }
        }

    }
}
