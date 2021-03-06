using System;
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
        public MySqlConnection conexion;
        protected MySqlCommand comando;
        protected MySqlDataReader lector;
      
        public Modelo(byte sessionType)
        {
            try
            {
                connection(sessionType);
            }catch(MySqlException e)
            {
                Console.WriteLine($"MODELO.CS SQL ERROR CODE CONNECTION: {e.Number}\n {e.Message}");
                throw new Exception($"Conection-{e.Number.ToString()}");
            }
        }
        public Modelo() { }
        
        public void connection(byte sessionType)
        {
            this.InicializarConexion(sessionType);
            conexion = new MySqlConnection(
                 "server=" + this.IpDb + ";" +
                "userid=" + this.UsuarioDb + ";" +
                "password=" + this.PasswordDb + ";" +
                "database=" + this.NombreDb + ";" +
                "pooling=false;"
                );
            conexion.Open();
            this.comando = new MySqlCommand();
            this.comando.Connection = this.conexion;
        }

        public void EjecutarQuery(MySqlCommand comando,string errorType)
        {
            try
            {
            comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"MODELO.CS SQL ERROR CODE EjecutarQuery:  {e.Number}\n{e.Message}");
                throw new Exception($"{errorType}-{e.Number}");
            }
        }
        public void EjecutarSpecialQuery(MySqlCommand comando)
        {
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"MODELO.CS SQL ERROR CODE EjecutarQuery:  {e.Number}\n {e.Message}");
                throw new Exception($"{e.Message}-{e.Number}");
            }
        }


        protected void InicializarConexion(byte sessionType)
        {
                this.IpDb = "192.168.5.50"; //UTU 192.168.5.50  house 192.168.1.151
            this.NombreDb = "ultima";
            this.UsuarioDb = "federico.costa";
            this.PasswordDb = "49800853";
            //switch (sessionType) {

            //    case 0: usuarioEsAlumno();
            //        break;
            //    case 1: usuarioEsDocente();
            //        break;
            //    case 2: usuarioEsAdmin();
            //        break;
            //    case 3:
            //        usuarioEsAlumnoLogin();
            //        break;
            //    case 4:
            //        usuarioEsDocenteLogin();
            //        break;
            //    case 5:
            //        usuarioEsAdminLogin();
            //        break;
            //    default: throw new Exception("el tipo de session no se pudo cargar correctamente");
            //}
        }
        //private void usuarioEsAlumno()
        //{
        //    this.UsuarioDb = "alumnoDB";
        //    this.PasswordDb = "alumnoclave";
        //}
        //private void usuarioEsDocente()
        //{
        //    this.UsuarioDb = "docenteDB";
        //    this.PasswordDb = "docenteclave";
        //}
        //private void usuarioEsAdmin() {
        //    this.UsuarioDb = "adminDB";
        //    this.PasswordDb = "adminclave";
        //}
        //private void usuarioEsAlumnoLogin()
        //{
        //    this.UsuarioDb = "alumnoLogin";
        //    this.PasswordDb = "alumnoLogin";
        //}
        //private void usuarioEsDocenteLogin()
        //{
        //    this.UsuarioDb = "docenteLogin";
        //    this.PasswordDb = "docenteLogin";
        //}
        //private void usuarioEsAdminLogin()
        //{
        //    this.UsuarioDb = "adminLogin";
        //    this.PasswordDb = "adminLogin";
        //}
    }
}
