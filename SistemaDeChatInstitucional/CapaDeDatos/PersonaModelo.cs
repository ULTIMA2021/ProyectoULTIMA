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

        Modelo modelo = new Modelo();
        

        
        

        public void Guardar()
        {

            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "INSERT INTO alumno (cedula,nombre,apellido,clave) VALUES(" +
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


        public void getAlumno(string user, string pass)
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.ci FROM Alumno a INNER JOIN Persona p WHERE " +
                                         "(a.ci=p.ci) and (a.ci=@user) and (p.clave=@pass);";
            this.comando.Parameters.AddWithValue("user", user);
            this.comando.Parameters.AddWithValue("pass", pass);
           
            this.comando.Prepare();
            lector = this.comando.ExecuteReader();
            lector.Read();
            // if (lector.Read())
          //  {
               
               this.Cedula = lector[0].ToString();
               this.Clave = lector[1].ToString();
             
          //  }

        }

        public List<PersonaModelo> obtenerAlumno()
        {
            this.comando.CommandText = "SELECT a.ci, p.clave FROM Alumno a INNER JOIN Persona p ON " +
                                         "(a.ci=p.ci);";
            lector = this.comando.ExecuteReader();

            List<PersonaModelo> personas = new List<PersonaModelo>();

            while (lector.Read())
            {
                PersonaModelo p = new PersonaModelo();

                p.Cedula = lector[0].ToString();
                p.Clave = lector[1].ToString();

                personas.Add(p);
            }

            return personas;
        }

        public List<PersonaModelo> obtenerDocente()
        {
            this.comando.CommandText = "SELECT d.ci, p.clave FROM Docente d INNER JOIN Persona p ON " +
                                         "(d.ci=p.ci);";
            lector = this.comando.ExecuteReader();

            List<PersonaModelo> personas = new List<PersonaModelo>();

            while (lector.Read())
            {
                PersonaModelo p = new PersonaModelo();

                p.Cedula = lector[0].ToString();
                p.Clave = lector[1].ToString();

                personas.Add(p);
            }

            return personas;
        }


        public List<PersonaModelo> obtenerAdmin()
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.ci FROM Administrador a INNER JOIN Persona p ON " +
                                         "(a.ci=p.ci);";
            lector = this.comando.ExecuteReader();

            List<PersonaModelo> personas = new List<PersonaModelo>();

            while (lector.Read())
            {
                PersonaModelo p = new PersonaModelo();

                p.Cedula = lector[0].ToString();
                p.Clave = lector[1].ToString();

                personas.Add(p);
            }

            return personas;
        }


       

    }
}
