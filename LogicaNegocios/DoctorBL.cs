using System;
using AccesoDatos;
using Entities;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogicaNegocios
{
    public class DoctorBL
    {
        public static List<Doctor> Listdoctores;
        public List<Doctor> GetDoctores()
        {
            string path = DoctoresDAL.ConexionDoctores();
            string[] lines = System.IO.File.ReadAllLines($"{path}\\BD\\Doctores.txt");
            Listdoctores = new List<Doctor>();
            foreach (var item in lines)
            {
                string Dni = item.Split(',')[0];
                string Nombre = item.Split(',')[1];
                string Apellido = item.Split(',')[2];
                string CMP = item.Split(',')[3];
                string Especialidad = item.Split(',')[4];
                Doctor d = new Doctor(Dni, Nombre, Apellido, CMP, Especialidad);
                Listdoctores.Add(d);
            }
            return Listdoctores;
        }
        public void UpdateDoctor(string dni, Doctor doctor)
        {
            foreach (Doctor item in Listdoctores)
            {
                if (item.DNI == dni)
                {
                    item.Nombre = doctor.Nombre;
                    item.Apellido = doctor.Apellido;
                    item.CMP = doctor.CMP;
                    item.Especialidad = doctor.Especialidad;
                }
            }
            UpdateDataBase();
        }

        public void InsertDoctor(Doctor doctor)
        {
            Listdoctores.Add(doctor);
            UpdateDataBase();
        }

        public int DeleteDoctor(string Dni)
        {
            int elementsRemoved = Listdoctores.RemoveAll(x => x.DNI == Dni);
            UpdateDataBase();
            return elementsRemoved;
        }

        private int UpdateDataBase()
        {
            string path = DoctoresDAL.ConexionDoctores();
            int updateLines = 0;
            using (StreamWriter outputFile = new StreamWriter($"{path}\\BD\\Doctores.txt"))
            {
                foreach (var item in Listdoctores)
                {
                    string line = $"{item.DNI},{item.Nombre},{item.Apellido},{item.CMP},{item.Especialidad}";
                    outputFile.WriteLine(line);
                    updateLines++;
                }
            }
            return updateLines;
        }
    }
}
