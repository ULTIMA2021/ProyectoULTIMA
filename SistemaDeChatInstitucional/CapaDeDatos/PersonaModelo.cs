using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using MySql.Data.MySqlClient;


namespace CapaDeDatos
{
    public class PersonaModelo : Modelo
    {
        public int Cedula;
        public string Nombre;
        public string Apellido;
        public string Clave;

        MySqlCommand comando = new MySqlCommand();
        

        public void Guardar()
        {

            
            comando.CommandText = "INSERT INTO alumno (cedula,nombre,apellido,clave) VALUES(@cedula,@nombre,@apellido,@clave);";

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


        public void getPersona(string user, string pass)
        {
            comando.CommandText = "SELECT ci, clave FROM Persona WHERE ci=@user and clave=@pass;";

            comando.Parameters.AddWithValue("@user", user);
            comando.Parameters.AddWithValue("@pass", pass);
            MySqlDataReader reader = comando.ExecuteReader();
        }


        public void getAlumno(string user)
        {
            comando.CommandText = "SELECT ci FROM Alumno WHERE ci=@user;";

            comando.Parameters.AddWithValue("@user", user);
            MySqlDataReader reader = comando.ExecuteReader();
        }


        public void getDocente()
        {
            comando.CommandText = "SELECT ci, clave FROM Persona;";
        }

    }
}
