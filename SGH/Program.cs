using EntidadesNegocio;
using LogicaNegocios;
using System;

namespace SGH
{
    class Program
    {
        static void Main(string[] args)
        {
            PacienteBL pacienteBL = new PacienteBL();
            var Pacientes= pacienteBL.GetPacientes();
            foreach (var item in Pacientes)
            {
                var i = "";
                Console.WriteLine($"{item.Dni},{item.Nombre},{item.Apellido}");
            }


            //ACTUALIZAR PACIENTE
            Paciente updatedPaciente = new Paciente("44216617","Jose", "Herrera");
            pacienteBL.UpdatePaciente("44216617", updatedPaciente);
            Console.WriteLine("Actualizacion de Paciente...");
            foreach (var item in PacienteBL.Listpacientes)
            {
                Console.WriteLine($"{item.Dni},{item.Nombre},{item.Apellido}");
            }
            //AGREGAR PACIENTE
            Paciente newPaciente = new Paciente("44216619", "Martin", "Centeno");
            pacienteBL.InsertPaciente(newPaciente);
            Console.WriteLine("Insertar Paciente...");
            foreach (var item in PacienteBL.Listpacientes)
            {
                Console.WriteLine($"{item.Dni},{item.Nombre},{item.Apellido}");
            }
            //ELIMINAR PACIENTE
            pacienteBL.DeletePaciente("44216619");
            Console.WriteLine("Eliminar Paciente...");
            foreach (var item in PacienteBL.Listpacientes)
            {
                Console.WriteLine($"{item.Dni},{item.Nombre},{item.Apellido}");
            }
            Console.WriteLine("new change wilson, GIanccalrl");
            Console.WriteLine("Unico cambio mas cambioa");
        }
    }
}
