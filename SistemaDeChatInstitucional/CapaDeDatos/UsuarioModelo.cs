using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class UsuarioModelo : Modelo
    {
        public string Cedula;
        public string Nombre;
        public string Apellido;
        public string Clave;

        PersonaModelo p = new PersonaModelo();

        //retorna tabla entera de alumno con algunos campos de persona
        public List<PersonaModelo> obtenerAlumno()
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Alumno a INNER JOIN Persona p ON " +
                                         "(a.ci=p.ci);";
            return p.obtenerUsuario(this.comando);
        }

        // prueba
        public List<PersonaModelo> lista(string ci, Func<List<PersonaModelo>> metodo)
        {
           List<PersonaModelo> personas = new List<PersonaModelo>();
            foreach (PersonaModelo usuario in metodo())
            {
                if (ci == usuario.Cedula)
                {
                    lector = this.comando.ExecuteReader();
                    PersonaModelo u = new PersonaModelo();
                    PersonaModelo p = new PersonaModelo();
                    u.Cedula = p.Cedula;
                    u.Nombre = p.Nombre;
                    u.Apellido = p.Apellido;
                    personas.Add(u);
                }
            }
            lector.Close();
            return personas;
        }

        public List<PersonaModelo> obtenerAlumno(string ci)
        {
            return lista(ci, obtenerAlumno);
        }
        
        /*   public List<PersonaModelo> obtenerAlumno(string ci)
           {
               List<PersonaModelo> personas = new List<PersonaModelo>();

               foreach (PersonaModelo usuario in obtenerAlumno())
               {
                   if(ci == usuario.Cedula)
                   {
                       lector = this.comando.ExecuteReader();

                       PersonaModelo p = new PersonaModelo();
                       p.Cedula = lector[0].ToString();
                       p.Nombre = lector[2].ToString();
                       p.Apellido = lector[3].ToString();

                       personas.Add(p);
                   }

               }
               return personas;
           }  */


        public List<PersonaModelo> obtenerDocente()
        {
            this.comando.CommandText = "SELECT d.ci, p.clave, p.nombre, p.apellido FROM Docente d INNER JOIN Persona p ON " +
                                         "(d.ci=p.ci);";
            return p.obtenerUsuario(this.comando);
        }

        public List<PersonaModelo> obtenerDatosDocente()
        {
            this.comando.CommandText = "SELECT p.nombre, p.apellido FROM Docente d INNER JOIN Persona p ON " +
                                         "(d.ci=p.ci);";
            return p.obtenerUsuario(this.comando);
        }

        public List<PersonaModelo> obtenerAdmin()
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Administrador a INNER JOIN Persona p ON " +
                                         "(a.ci=p.ci);";
            return p.obtenerUsuario(this.comando);
        }
    }
}
