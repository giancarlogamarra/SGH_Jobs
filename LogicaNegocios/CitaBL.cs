using System;
using AccesoDatos;
using Entities;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogicaNegocios
{
    public class CitaBL
    {
        public static List<Cita> Listcitas;
        public List<Cita> GetCitas()
        {
            string path = CitasDAL.ConexionCitas();
            string[] lines = System.IO.File.ReadAllLines($"{path}\\BD\\Citas.txt");
            Listcitas = new List<Cita>();
            foreach (var item in lines)
            {
                string COD = item.Split(',')[0];
                string DNI_Paciente = item.Split(',')[1];
                string COD_Especialidad = item.Split(',')[2];
                string COD_Doctor = item.Split(',')[3];
                string TipoCita = item.Split(',')[4];
                string Estado = item.Split(',')[5];
                Cita c = new Cita(COD, DNI_Paciente, COD_Especialidad, COD_Doctor, TipoCita, Estado);
                Listcitas.Add(c);
            }
            return Listcitas;
        }
        public void UpdateCita(string cod, Cita cita)
        {
            foreach (Cita item in Listcitas)
            {
                if (item.COD == cod)
                {
                    item.COD_Paciente = cita.COD_Paciente;
                    item.COD_Especialidad = cita.COD_Especialidad;
                    item.COD_Doctor = cita.COD_Doctor;
                    item.Tipo = cita.Tipo;
                    item.Estado = cita.Estado;
                }
            }
            UpdateDataBase();
        }
        public void InsertCita(Cita cita)
        {
            Listcitas.Add(cita);
            UpdateDataBase();
        }
        public int DeleteCita(string cod)
        {
            int elementsRemoved = Listcitas.RemoveAll(x => x.COD == cod);
            UpdateDataBase();
            return elementsRemoved;
        }

        private int UpdateDataBase()
        {
            string path = CitasDAL.ConexionCitas();
            int updateLines = 0;
            using (StreamWriter outputFile = new StreamWriter($"{path}\\BD\\Citas.txt"))
            {
                foreach (var item in Listcitas)
                {
                    string line = $"{item.COD},{item.COD_Paciente},{item.COD_Especialidad},{item.COD_Doctor},{item.Tipo},{item.Estado}";
                    outputFile.WriteLine(line);
                    updateLines++;
                }
            }
            return updateLines;
        }
    }

}
