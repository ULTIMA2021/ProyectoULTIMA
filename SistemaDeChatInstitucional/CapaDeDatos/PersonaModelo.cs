using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using MySql.Data.MySqlClient;
using System.Data;

namespace CapaDeDatos
{
    public class PersonaModelo : Modelo
    {
        public string Cedula;
        public string Nombre;
        public string Apellido;
        public string Clave;
        //foto
        //avatar
        public bool isDeleted;
        public bool enLinea;
        Modelo modelo = new Modelo();

        public void Guardar()
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "INSERT INTO Persona (ci,nombre,apellido,clave) VALUES(" +
                                    "@cedula,@nombre,@apellido,@clave);";

            comando.Parameters.AddWithValue("@cedula", this.Cedula);
            comando.Parameters.AddWithValue("@nombre", this.Nombre);
            comando.Parameters.AddWithValue("@apellido", this.Apellido);
            comando.Parameters.AddWithValue("@clave", this.Clave);
            comando.Prepare();
            EjecutarQuery(comando);
        }
        private void EjecutarQuery(MySqlCommand comando)
        {
            comando.ExecuteNonQuery();
        }

        //metodo usado para cargar datos del resultado SQL a una lista
        private List<PersonaModelo> obtenerUsuario(MySqlCommand commando)
        {
            lector = commando.ExecuteReader();
            List<PersonaModelo> personas = new List<PersonaModelo>();
            while (lector.Read())
            {
                PersonaModelo p = new PersonaModelo();
                Console.WriteLine("ci: " + lector[0].ToString() + "    " + lector[1].ToString() + "    " + lector[2].ToString() + "    " + lector[3].ToString());
                p.Cedula = lector[0].ToString();
                p.Clave = lector[1].ToString();
                p.Nombre = lector[2].ToString();
                p.Apellido = lector[3].ToString();
                /*
                p.isDeleted = Boolean.Parse(lector[4].ToString());
                p.enLinea = Boolean.Parse(lector[5].ToString());
                */
                personas.Add(p);
            }
            return personas;
        }

        //retorna tabla entera de alumno con algunos campos de persona
        public List<PersonaModelo> obtenerAlumno()
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Alumno a INNER JOIN Persona p ON " +
                                         "(a.ci=p.ci);";
            return obtenerUsuario(this.comando);
        }
        //retorna una persona-alumno si la encuentra
        public List<PersonaModelo> obtenerAlumno(string user, string pass)
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Alumno a,Persona p WHERE  " +
                                         "a.ci=@user AND p.clave=@pass;";
            this.comando.Parameters.AddWithValue("user", user);
            this.comando.Parameters.AddWithValue("pass", pass);
            return obtenerUsuario(this.comando);
        }

        public List<PersonaModelo> obtenerDocente()
        {
            this.comando.CommandText = "SELECT d.ci, p.clave, p.nombre, p.apellido FROM Docente d INNER JOIN Persona p ON " +
                                         "(d.ci=p.ci);";
            return obtenerUsuario(this.comando);
        }
        public List<PersonaModelo> obtenerDocente(string user, string pass)
        {
            this.comando.CommandText = "SELECT d.ci, p.clave, p.nombre, p.apellido FROM Docente d,Persona p WHERE  " +
                                         "d.ci=@user AND p.clave=@pass;";
            this.comando.Parameters.AddWithValue("user", user);
            this.comando.Parameters.AddWithValue("pass", pass);
            return obtenerUsuario(this.comando);
        }

        public List<PersonaModelo> obtenerAdmin()
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Administrador a INNER JOIN Persona p ON " +
                                         "(a.ci=p.ci);";
            return obtenerUsuario(this.comando);
        }
        public List<PersonaModelo> obtenerAdmin(string user, string pass)
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Administrador a,Persona p WHERE  " +
                                         "a.ci=@user AND p.clave=@pass;";
            this.comando.Parameters.AddWithValue("user", user);
            this.comando.Parameters.AddWithValue("pass", pass);
            return obtenerUsuario(this.comando);
        }
    }
}
