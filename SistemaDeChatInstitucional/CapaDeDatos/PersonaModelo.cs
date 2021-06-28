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


        public void Guardar()
        {

            MySqlCommand comando = new MySqlCommand();
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
    }
}
