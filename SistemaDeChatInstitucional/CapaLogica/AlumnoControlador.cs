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
                }

            }

            return resultado;
        }


    }
}
