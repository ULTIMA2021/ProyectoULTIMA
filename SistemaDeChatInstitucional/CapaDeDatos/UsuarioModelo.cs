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
          //  lector.Close();
            return personas;
        }

        public List<PersonaModelo> obtenerAlumno(string ci)
        {
            return lista(ci, obtenerAlumno);
        }


        public List<UsuarioModelo> destinatario()
        {
            this.comando.CommandText = "SELECT ci, nombre, apellido FROM Persona;";
            List<UsuarioModelo> usuarios = new List<UsuarioModelo>();
            lector = this.comando.ExecuteReader();

            while (lector.Read())
            {
                UsuarioModelo u = new UsuarioModelo();
                u.Cedula = lector[0].ToString();
                u.Nombre = lector[1].ToString();
                u.Apellido = lector[2].ToString();
                usuarios.Add(u);
            }
            lector.Close();
            return usuarios;
        }

        /*   public List<UsuarioModelo> destinatario(string ci)
           {
               PersonaModelo p = new PersonaModelo();
               UsuarioModelo u = new UsuarioModelo();
             //  this.comando.CommandText = "SELECT ci, nombre, apellido FROM Persona;";
               List<UsuarioModelo> usuarios = new List<UsuarioModelo>();
              // lector = this.comando.ExecuteReader();

               foreach(PersonaModelo usuario in p.obtenerUsuario(this.comando))
               {
                   if (ci == usuario.Cedula)
                   {
                     //  lector = this.comando.ExecuteReader();

                     //  PersonaModelo p = new PersonaModelo();
                       //  p.Cedula = lector[0].ToString();
                       //  p.Nombre = lector[2].ToString();
                       //  p.Apellido = lector[3].ToString();
                       p.Cedula = u.Cedula;
                       p.Nombre = u.Nombre;
                       p.Apellido = u.Apellido;

                       usuarios.Add(u);
                   }
               }

               lector.Close();
               return usuarios;
           }  */

        public List<PersonaModelo> destinatario(string ci)
        {
            PersonaModelo p = new PersonaModelo();
            return lista(ci, obtenerPersona);
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

        public List<PersonaModelo> obtenerPersona()
        {
            this.comando.CommandText = "SELECT d.ci, a.ci, p.clave, p.nombre, p.apellido FROM Docente d INNER JOIN Alumno a INNER JOIN Persona p ON " +
                                         "(d.ci=p.ci) and (a.ci=p.ci);";

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
