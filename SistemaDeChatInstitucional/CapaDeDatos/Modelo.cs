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
        protected string command;
        protected string IpDb;
        protected string NombreDb;
        protected string UsuarioDb;
        protected string PasswordDb;
        protected MySqlConnection conexion;
        protected MySqlCommand comando;
        protected MySqlDataReader lector;

        //esto se tiene que sacar
       

        public Modelo(byte sessionType)
        {
            try
            {
                connection(sessionType);
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public void connection(byte sessionType)
        {
            this.InicializarConexion(sessionType);
            conexion = new MySqlConnection(
                 "server=" + this.IpDb + ";" +
                "userid=" + this.UsuarioDb + ";" +
                "password=" + this.PasswordDb + ";" +
                "database=" + this.NombreDb + ";"
                );

            conexion.Open();
            this.comando = new MySqlCommand();
            this.comando.Connection = this.conexion;
        }

        public void EjecutarQuery(MySqlCommand comando)=> comando.ExecuteNonQuery();

        protected void InicializarConexion(byte sessionType)
        {
                this.IpDb = "localhost";
                this.NombreDb = "ultimaDB";
            switch (sessionType) {
                case 0: usuarioEsAlumno();
                    break;
                case 1: usuarioEsDocente();
                    break;
                case 2: usuarioEsAdmin();
                    break;
                default: usuarioEsLogin();
                    break;
            }
        }
        private void usuarioEsAlumno()
        {
            this.UsuarioDb = "alumnoDB";
            this.PasswordDb = "alumnoclave";
        }
        private void usuarioEsDocente()
        {
            this.UsuarioDb = "docenteDB";
            this.PasswordDb = "docenteclave";
        }
        private void usuarioEsAdmin() {
            this.UsuarioDb = "root";
            this.PasswordDb = "9682031";
        }
        private void usuarioEsLogin()//usuario que solo puede hacer el select a las tablas de login(Alumno,docente,admin,persona)
        {
            this.UsuarioDb = "login";
            this.PasswordDb = "login";
        }
    }
}
