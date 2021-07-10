using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaLogica
{
    public static class AlumnoControlador
    {
        public static bool AltaDeAlumno(string cedula, string nombre, string apellido, string clave)
        {
            PersonaModelo Alumno = new PersonaModelo();
            Alumno.Cedula = cedula;
            Alumno.Nombre = nombre;
            Alumno.Apellido = apellido;
            Alumno.Clave = clave;
            Alumno.Guardar();
            return true;
        }

        public static bool isAlumno(string user, string pass)
        {
            Console.WriteLine("method isAlumno is running");
            PersonaModelo p = new PersonaModelo();
            List<PersonaModelo> personas = p.obtenerAlumno(user,pass);
            if (personas.Count == 1)
            {
                Session.saveToCache(personas[0]);
                return true;
            }
            return false;
        }
        public static bool isDocente(string user, string pass)
        {
            Console.WriteLine("method isDocente is running");
            PersonaModelo p = new PersonaModelo();
            List<PersonaModelo> personas = p.obtenerDocente(user, pass);
            if (personas.Count == 1)
            {
                Session.saveToCache(personas[0]);
                return true;
            }
            return false;
        }
        public static bool isAdmin(string user, string pass)
        {
            Console.WriteLine("method isAdmin is running");
            PersonaModelo p = new PersonaModelo();
            List<PersonaModelo> personas = p.obtenerAdmin(user, pass);
            if (personas.Count == 1)
            {
                Session.saveToCache(personas[0]);
                return true;
            }
            return false;
        }
    }
}
