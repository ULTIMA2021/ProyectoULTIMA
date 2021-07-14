using System;
using System.Collections.Generic;
using System.Data;
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

        public static bool lista(string user, string pass, Func<string, string, List<PersonaModelo>> metodoObtener)
        {
            PersonaModelo p = new PersonaModelo();
            List<PersonaModelo> personas = metodoObtener(user, pass);
            if (personas.Count == 1)
            {
                Session.saveToCache(personas[0]);
                return true;
            }
            return false;
        }

        public static bool isAlumno(string user, string pass)
        {
            PersonaModelo p = new PersonaModelo();
            return lista(user, pass, p.validarAlumno);
        }


        public static bool isDocente(string user, string pass)
        {
            PersonaModelo p = new PersonaModelo();
            return lista(user, pass, p.validarDocente);
        }


        public static bool isAdmin(string user, string pass)
        {
            PersonaModelo p = new PersonaModelo();
            return lista(user, pass, p.validarAdmin);
        }



        /*    public static bool isAlumno(string user, string pass)    ------------->>>> desde aca parte original de validar usuarios
            {
                Console.WriteLine("method isAlumno is running");
                PersonaModelo p = new PersonaModelo();
                List<PersonaModelo> personas = p.validarAlumno(user,pass);
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
             List<PersonaModelo> personas = p.validarDocente(user, pass);
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
             List<PersonaModelo> personas = p.validarAdmin(user, pass);
             if (personas.Count == 1)
             {
                 Session.saveToCache(personas[0]);
                 return true;
             }
             return false;
         } */            //    ----------------------->>>    hasta aca es la parte original de validar usuarios

        /*   public static DataTable listarMaterias()
           {
               PersonaModelo p = new PersonaModelo();
               List<PersonaModelo> materias = p.obtenerMaterias();
               DataTable tabla = new DataTable();

               tabla.Columns.Add("Materias");

               foreach (PersonaModelo materia in materias)
               {
                   tabla.Rows.Add(materia.materia);
               }


               return tabla;
           }

           */

        /*   private static bool listaUsuarios(bool metodo)
           {
               PersonaModelo p = new PersonaModelo();
               List<PersonaModelo> personas = p.metodo;
               if (personas.Count == 1)
               {
                   Session.saveToCache(personas[0]);
                   return true;
               }
               return false;


           } */

        public static bool obtenerAlumno(string ci)
        {
            UsuarioModelo u = new UsuarioModelo();
            u.obtenerAlumno(ci);
            return true;
        }

        
    }
}
