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
                "userid=" + this.UsuarioDb + ";" +
                "password=" + this.PasswordDb + ";" +
                "database=" + this.NombreDb + ";"
                );

            conexion.Open();
            Console.WriteLine("Conexion abierta");

        }

        protected void InicializarConexion()
        {
            this.IpDb = "localhost";
            this.NombreDb = "ultimaDB";
            this.UsuarioDb = "root";
            this.PasswordDb = "andylu30";
        }
    }
}
