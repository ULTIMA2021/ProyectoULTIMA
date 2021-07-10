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
        
        static Session session = new Session();

        public static Session getSession() {
           Console.WriteLine(session.toString());
            return session;
        }


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
            
            private static void saveToCache( PersonaModelo per) {
                session.cedula = per.Cedula;
                session.nombre = per.Nombre;
            session.apellido = per.Apellido;
            session.clave = per.Clave;
            }
           

            public static bool verificarAlumno(string user, string pass)
        {
            bool resultado = false;
            PersonaModelo p = new PersonaModelo();
            List<PersonaModelo> personas = p.obtenerAlumno();
            foreach (PersonaModelo per in personas)
            {
                if(per.Cedula == user && per.Clave == pass)
                {
                    resultado = true;
                    saveToCache(per);
                    break;
                } 
            }

            return resultado;
        }

        public static bool verificarDocente(string user, string pass)
        {
            bool resultado = false;
            PersonaModelo p = new PersonaModelo();
            List<PersonaModelo> personas = p.obtenerDocente();
            foreach (PersonaModelo per in personas)
            {
                if (per.Cedula == user && per.Clave == pass)
                {
                    resultado = true;
                    saveToCache(per);
                    break;
                }

            }

            return resultado;
        }


        public static bool verificarAdmin(string user, string pass)
        {
            bool resultado = false;
            PersonaModelo p = new PersonaModelo();
            List<PersonaModelo> personas = p.obtenerAdmin();
            foreach (PersonaModelo per in personas)
            {
                if (per.Cedula == user && per.Clave == pass)
                {
                    resultado = true;
                    saveToCache(per);
                    break;
                }

            }

            return resultado;
        }


    }
}
