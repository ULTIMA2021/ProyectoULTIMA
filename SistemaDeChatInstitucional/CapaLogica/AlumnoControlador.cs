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

        public static bool lista (string user, string pass, Func<string, string, List<PersonaModelo>> metodoObtener)
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

        public static bool obtenerAlum(string ci)
        {
            UsuarioModelo u = new UsuarioModelo();
            u.obtenerAlumno(ci);
            return true;
        }

        public static DataTable obtenerDocentes()
        {
            UsuarioModelo u = new UsuarioModelo();
            PersonaModelo p = new PersonaModelo();
            List<PersonaModelo> docentes = u.obtenerDocente();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Cedula");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Apellido");
            foreach (PersonaModelo docente in docentes)
            {
                tabla.Rows.Add(docente.Cedula, docente.Nombre, docente.Apellido);
            }
            return tabla;
        }

        public static void prepararMensaje(int idConsultaPrivada,string docenteCi, string alumnoCi,
            string titulo, string cpStatus, DateTime cpFechaHora)
        {
            ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo();
            cp.prepararMensaje(idConsultaPrivada,docenteCi, alumnoCi, titulo, cpStatus, cpFechaHora);
        }

        public static void enviarMensaje(int idConsultaPrivada, int ciDocente, int ciAlumno, string contenido, string attachment,
                                   DateTime cp_mensajeFechaHora, string cp_mensajeStatus)
        {
            ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo();
            cp.enviarMensaje(idConsultaPrivada, ciDocente, ciAlumno, contenido, attachment, cp_mensajeFechaHora, cp_mensajeStatus);
        }

        public static int idConsultaPrivada(int ciDocente, int ciAlumno)
        {
            ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo();
            int idConsultaPrivada= cp.getIdConsultas(ciDocente, ciAlumno);
            Console.WriteLine($"EL ID DE LA CONSULTA PREVIA ES: {idConsultaPrivada}");
            idConsultaPrivada++;
            Console.WriteLine($"EL ID DE LA CONSULTA NUEVA ES: {idConsultaPrivada}");
            return idConsultaPrivada;
        } 
    }
}
