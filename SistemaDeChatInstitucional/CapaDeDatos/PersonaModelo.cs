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
        private string errorType = "Persona";
        public string Cedula;
        public string Nombre;
        public string Apellido;
        public string Clave;
        public string Apodo;
        public string foto;
        public bool isDeleted;
        public bool enLinea;

        public PersonaModelo(byte sessionType) : base(sessionType)
        {
        }

        public void GuardarPersona()
        {
            this.comando.CommandText = "INSERT INTO Persona (ci,nombre,apellido,clave,isDeleted,enLinea,foto) VALUES(" +
                                    "@cedula,@nombre,@apellido,@clave,@isDeleted,@enlinea,@foto);";
            this.comando.Parameters.AddWithValue("@cedula", this.Cedula);
            this.comando.Parameters.AddWithValue("@nombre", this.Nombre);
            this.comando.Parameters.AddWithValue("@apellido", this.Apellido);
            this.comando.Parameters.AddWithValue("@clave", this.Clave);
            this.comando.Parameters.AddWithValue("@foto", this.foto);
            this.comando.Parameters.AddWithValue("@isDeleted", false);
            this.comando.Parameters.AddWithValue("@enlinea", false);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);

        }
        public void guardarAlumno()
        {
            this.comando.CommandText = "INSERT INTO Alumno (ci,apodo) VALUES (@Cedula,@Apodo);";
            this.comando.Parameters.AddWithValue("Cedula", this.Cedula);
            this.comando.Parameters.AddWithValue("Apodo", this.Apodo);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void guardarAlumno(string grupos)
        {
            this.comando.CommandText = "INSERT INTO AlumnoTemp (ci, nombre, apellido, clave, foto, apodo, grupos) " +
                "VALUES (@Cedula,@nombre,@apellido,@clave,@foto,@Apodo,@grupos);";
            this.comando.Parameters.AddWithValue("@Cedula", this.Cedula);
            this.comando.Parameters.AddWithValue("@nombre", this.Nombre);
            this.comando.Parameters.AddWithValue("@apellido", this.Apellido);
            this.comando.Parameters.AddWithValue("@clave", this.Clave);
            this.comando.Parameters.AddWithValue("@foto", this.foto);
            this.comando.Parameters.AddWithValue("@Apodo", this.Apodo);
            this.comando.Parameters.AddWithValue("@grupos", grupos);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void guardarDocente()
        {
            this.comando.CommandText = "INSERT INTO Docente (ci) VALUES (@cedula);";
            this.comando.Parameters.AddWithValue("@cedula", this.Cedula);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void guardarAdmin()
        {
            this.comando.CommandText = "INSERT INTO Administrador (ci) VALUES(@Cedula);";
            this.comando.Parameters.AddWithValue("@cedula", this.Cedula);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }

        public void actualizarPersona()
        {
            this.comando.CommandText = "UPDATE Persona SET enLinea=@enLinea WHERE ci=@Cedula;";
            this.comando.Parameters.AddWithValue("Cedula", this.Cedula);
            this.comando.Parameters.AddWithValue("enLinea", this.enLinea);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void actualizarPersona(string clave)
        {
            this.comando.CommandText = "UPDATE Persona SET clave=@clave WHERE ci=@Cedula;";
            this.comando.Parameters.AddWithValue("Cedula", Cedula);
            this.comando.Parameters.AddWithValue("clave", clave);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void actualizarPersona(bool isDeleted)
        {
            this.comando.CommandText = "UPDATE Persona SET isDeleted=@isDeleted WHERE ci=@Cedula;";
            this.comando.Parameters.AddWithValue("Cedula", Cedula);
            this.comando.Parameters.AddWithValue("isDeleted", isDeleted);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }

        private List<PersonaModelo> obtenerUsuario(MySqlCommand commando, byte sessionType)
        {
            lector = commando.ExecuteReader();
            List<PersonaModelo> personas = new List<PersonaModelo>();
            while (lector.Read())
            {
                PersonaModelo p = new PersonaModelo(sessionType);
                // Console.WriteLine("ci: " + lector[0].ToString() + "    " + lector[1].ToString() + "    " + lector[2].ToString() + "    " + lector[3].ToString());
                p.Cedula = lector[0].ToString();
                byte[] claveArray = Encoding.Default.GetBytes(lector[1].ToString());
                p.Clave = Encoding.Default.GetString(claveArray);
                p.Nombre = lector[2].ToString();
                p.Apellido = lector[3].ToString();
                personas.Add(p);
            }
            lector.Close();
            return personas;
        }
        //old
        //public List<PersonaModelo> validarAlumno(string user, string pass, byte sessionType)
        //{
        //    this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Alumno a,Persona p " +
        //        "WHERE p.ci=a.ci AND a.ci=@user AND p.clave=@pass AND p.isDeleted=false;";
        //    this.comando.Parameters.AddWithValue("user", user);
        //    this.comando.Parameters.AddWithValue("pass", pass);
        //    return obtenerUsuario(this.comando, sessionType);
        //}

        //new
        public List<PersonaModelo> validarAlumno(string user, byte sessionType)
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido, p.foto FROM Alumno a,Persona p " +
                "WHERE p.ci=a.ci AND a.ci=@user AND p.isDeleted=false;";
            this.comando.Parameters.AddWithValue("user", user);
            return obtenerUsuario(this.comando, sessionType);
        }

        public List<PersonaModelo> validarDocente(string user, byte sessionType)
        {
            this.comando.CommandText = "SELECT d.ci, p.clave, p.nombre, p.apellido FROM Docente d,Persona p " +
                "WHERE p.ci=d.ci AND d.ci=@user AND p.isDeleted=false;";
            this.comando.Parameters.AddWithValue("user", user);
            return obtenerUsuario(this.comando, sessionType);
        }

        public List<PersonaModelo> validarAdmin(string user ,byte sessionType)
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Administrador a, Persona p " +
                "WHERE p.ci = a.ci AND a.ci = @user AND p.isDeleted=false;";
            this.comando.Parameters.AddWithValue("user", user);
            return obtenerUsuario(this.comando, sessionType);
        }

        public List<PersonaModelo> obtenerPersona(byte sessionType)
        {
            this.comando.CommandText = "SELECT ci, nombre, apellido FROM Persona;";
            List<PersonaModelo> personas = new List<PersonaModelo>();
            lector = this.comando.ExecuteReader();
            while (lector.Read())
            {
                PersonaModelo p = new PersonaModelo(sessionType);
                p.Cedula = lector[0].ToString();
                p.Nombre = lector[1].ToString();
                p.Apellido = lector[2].ToString();
                personas.Add(p);
            }

            lector.Close();
            return personas;
        }

        public PersonaModelo obtenerPersona(string cedula, byte sessionType)
        {
            this.comando.CommandText = "SELECT p.ci, p.nombre, p.apellido, p.foto, p.enLinea FROM Persona p " +
                "WHERE p.ci=@cedula";
            this.comando.Parameters.AddWithValue("cedula", cedula);
            PersonaModelo persona = new PersonaModelo(sessionType);
            lector = this.comando.ExecuteReader();
            while (lector.Read())
            {
                persona.Cedula = lector[0].ToString();
                persona.Nombre = lector[1].ToString();
                persona.Apellido = lector[2].ToString();
                persona.foto = null;    //lector[3];
                persona.enLinea = bool.Parse(lector[4].ToString());
            }

            lector.Close();
            return persona;
        }

        //retorna tabla entera de alumno con algunos campos de persona
        public List<PersonaModelo> obtenerAlumno(byte sessionType)
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Alumno a INNER JOIN Persona p ON " +
                                         "(a.ci=p.ci);";
            return obtenerUsuario(this.comando, sessionType);
        }

        /*
        public List<PersonaModelo> lista(string ci, Func<List<PersonaModelo>, byte sessionType)
        {
            List<PersonaModelo> personas = new List<PersonaModelo>();
            foreach (PersonaModelo usuario in metodo(sessionType))
            {
                if (ci == usuario.Cedula)
                {
                    lector = this.comando.ExecuteReader();
                    PersonaModelo u = new PersonaModelo( sessionType);
                    PersonaModelo p = new PersonaModelo( sessionType);
                    u.Cedula = p.Cedula;
                    u.Nombre = p.Nombre;
                    u.Apellido = p.Apellido;
                    personas.Add(u);
                }
            }
            return personas;
            }
            */

        public List<PersonaModelo> obtenerAlumno(string ci, byte sessionType)
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Alumno a, Persona p WHERE " +
                                                     "a.ci=p.ci AND a.ci=@ci;";
            this.comando.Parameters.AddWithValue("ci", ci);
            return obtenerUsuario(this.comando, sessionType);
        }

        public List<PersonaModelo> obtenerDocente(byte sessionType)
        {
            this.comando.CommandText = "SELECT d.ci, p.clave, p.nombre, p.apellido FROM Docente d INNER JOIN Persona p ON " +
                                         "(d.ci=p.ci);";
            return obtenerUsuario(this.comando, sessionType);
        }

        public List<PersonaModelo> obtenerDatosDocente(byte sessionType)
        {
            this.comando.CommandText = "SELECT p.nombre, p.apellido FROM Docente d INNER JOIN Persona p ON " +
                                         "(d.ci=p.ci);";
            return obtenerUsuario(this.comando, sessionType);
        }

        public List<PersonaModelo> obtenerAdmin(byte sessionType)
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Administrador a INNER JOIN Persona p ON " +
                                         "(a.ci=p.ci);";
            return obtenerUsuario(this.comando, sessionType);
        }

    }
}