using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace CapaDeDatos
{
    public class Modelo
    {
        protected string IpDb;
        protected string NombreDb;
        protected string UsuarioDb;
        protected string PasswordDb;
        protected MySqlDataReader lector;

        public Modelo()
        {
            this.InicializarConexion();
            MySqlConnection conexion = new MySqlConnection(
                 "server=" + this.IpDb + ";" +
                "userid=" + this.NombreDb + ";" +
                "password=" + this.UsuarioDb + ";" +
                "database=" + this.PasswordDb + ";"
                );

            conexion.Open();

        }

        protected void InicializarConexion()
        {
            this.IpDb = "192.168.80.1";
            this.NombreDb = "base";
            this.UsuarioDb = "root";
            this.PasswordDb = "1234";
        }
    }
}
