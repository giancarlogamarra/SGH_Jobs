using System;
using Entities;//Para clase Receta
using System.Collections.Generic;//Para List<>
using System.Threading.Tasks;//Para Task
using DataAccess;//Para RecetaDAL

namespace BusinessLayer
{
    public class RecetaBL
    {
        RecetaDAL dal = new RecetaDAL();//variable dal de clase RecetaDAL para ejecutar todas las funciones de esta clase
        //TOdas las funciones estan en RecetaDAL, enviamos los parámetros necesarios para cada función
        public async Task<string> InsertRecetaAsync(Receta Receta)//Task: operacion asincrona q devuelve un valor <value>
        {
            string respuesta = await dal.InsertRecetaAsync(Receta);//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return respuesta;//retorna una cadena
        }
        public async Task<List<Receta>> GetRecetasAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            List<Receta> Recetas = await dal.GetRecetaAsync();//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return Recetas;//retorna una lista
        }
        public async Task<Receta> GetOneRecetaAsync(int IdReceta)
        {
            Receta Receta = await dal.GetOneRecetaAsync(IdReceta);
            return Receta;//retorna un objeto de clase Receta
        }
        public async Task<string> UpdateRecetaAsync(Receta Receta)
        {
            string respuesta = await dal.UpdateRecetaAsync(Receta);
            return respuesta;//retorna una cadena
        }
        public async Task<string> DeleteRecetaAsync(int IdReceta)
        {
            string respuesta = await dal.DeleteRecetaAsync(IdReceta);
            return respuesta;//retorna una cadena
        }
    }
}
