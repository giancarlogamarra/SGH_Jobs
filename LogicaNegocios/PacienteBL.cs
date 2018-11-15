using AccesoDatos;//DataAccess
using Entities;//Entities
using System.Collections.Generic;
using System.IO;

namespace LogicaNegocios
{
    public class PacienteBL
    {
        public static List<Paciente> Listpacientes;

        public List<Paciente> GetPacientes()
        {
            string path = PacientesDAL.ConexionPacientes();
            string[] lines = System.IO.File.ReadAllLines($"{path}\\BD\\Pacientes.txt");
            Listpacientes = new List<Paciente>();
            foreach (var item in lines)
            {
                string Dni = item.Split(',')[0];
                string Nombre = item.Split(',')[1];
                string Apellido = item.Split(',')[2];
                Paciente p = new Paciente(Dni, Nombre, Apellido);
                Listpacientes.Add(p);
            }
            return Listpacientes;
        }










        public void UpdatePaciente(string dni, Paciente paciente) {
            foreach (Paciente item in Listpacientes)
            {
                if (item.Dni == dni)
                {
                    item.Nombre = paciente.Nombre;
                    item.Apellido = paciente.Apellido;
                }
            }
            UpdateDataBase();
        }
        public void InsertPaciente(Paciente paciente) {
            Listpacientes.Add(paciente);
            UpdateDataBase();
        }

        public int DeletePaciente(string Dni)
        {
           int elementsRemoved= Listpacientes.RemoveAll(x => x.Dni == Dni);
           UpdateDataBase();
           return elementsRemoved;
        }
        private int UpdateDataBase() {
            string path = PacientesDAL.ConexionPacientes();
            int updatedLines = 0;
            using (StreamWriter outputFile = new StreamWriter($"{path}\\BD\\Pacientes.txt"))
            {
                foreach (var item in Listpacientes)
                {
                    string line = $"{item.Dni},{item.Nombre},{item.Apellido}"; 
                    outputFile.WriteLine(line);
                    updatedLines++;
                }
            }
            return updatedLines;
        }
    }
}
