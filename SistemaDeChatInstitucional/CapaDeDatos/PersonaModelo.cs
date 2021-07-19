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
        public string Apodo;
        // public int idConsulta;
        public string foto;
        public string avatar;
        public bool isDeleted;
        public bool enLinea;
       // Modelo modelo = new Modelo();

        //implementar en segunda entrega
        public void GuardarTemp(string tipoUsuario)
        {
            this.comando.CommandText = "INSERT INTO PersonaTemp (ci,nombre,apellido,clave,enLinea,foto,avatar) VALUES(" +
                                    "@cedula,@nombre,@apellido,@clave,@foto,@avatar,@tipoUsuario);";
            this.comando.Parameters.AddWithValue("@cedula", this.Cedula);
            this.comando.Parameters.AddWithValue("@nombre", this.Nombre);
            this.comando.Parameters.AddWithValue("@apellido", this.Apellido);
            this.comando.Parameters.AddWithValue("@clave", this.Clave);
            this.comando.Parameters.AddWithValue("@foto", this.foto);
            this.comando.Parameters.AddWithValue("@avatar", this.avatar);
            this.comando.Parameters.AddWithValue("@avatar", tipoUsuario);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }

        public void GuardarPersona()
        {
            this.comando.CommandText = "INSERT INTO Persona (ci,nombre,apellido,clave,isDeleted,enLinea,foto,avatar) VALUES(" +
                                    "@cedula,@nombre,@apellido,@clave,@isDeleted,@enlinea,@foto,@avatar);";
            this.comando.Parameters.AddWithValue("@cedula", this.Cedula);
            this.comando.Parameters.AddWithValue("@nombre", this.Nombre);
            this.comando.Parameters.AddWithValue("@apellido", this.Apellido);
            this.comando.Parameters.AddWithValue("@clave", this.Clave);
            this.comando.Parameters.AddWithValue("@foto", this.foto);
            this.comando.Parameters.AddWithValue("@avatar", this.avatar);
            this.comando.Parameters.AddWithValue("@isDeleted", false);
            this.comando.Parameters.AddWithValue("@enlinea",  false);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }

        public void guardarAlumno()
        {
            this.comando.CommandText = "INSERT INTO Alumno (ci,apodo) VALUES (@Cedula,@Apodo);";
            this.comando.Parameters.AddWithValue("Cedula", this.Cedula);
            this.comando.Parameters.AddWithValue("Apodo", this.Apodo);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }

        public void guardarDocente()
        {
            this.comando.CommandText = "INSERT INTO Docente (ci) VALUES (@cedula);";
            this.comando.Parameters.AddWithValue("@cedula", this.Cedula);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }

        public void guardarAdmin()
        {
            this.comando.CommandText = "INSERT INTO Administrador (ci) VALUES(@Cedula);";
            this.comando.Parameters.AddWithValue("@cedula", this.Cedula);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }

        public void actualizarPersona() {
            this.comando.CommandText = "UPDATE Persona SET enLinea=@enLinea WHERE ci=@Cedula;";
            this.comando.Parameters.AddWithValue("Cedula",this.Cedula);
            this.comando.Parameters.AddWithValue("enLinea",this.enLinea);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }
        public void actualizarPersona(string clave)
        {
            this.comando.CommandText = "UPDATE Persona SET clave=@clave WHERE ci=@Cedula;";
            this.comando.Parameters.AddWithValue("Cedula", Cedula);
            this.comando.Parameters.AddWithValue("clave", clave);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }
        public void actualizarPersona(bool isDeleted)
        {
            this.comando.CommandText = "UPDATE Persona SET isDeleted=@isDeleted WHERE ci=@Cedula;";
            this.comando.Parameters.AddWithValue("Cedula", Cedula);
            this.comando.Parameters.AddWithValue("isDeleted", isDeleted);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }
       
        //esto deberia ser private, no deberia poder llamarlo de la capa logica
        public List<PersonaModelo> obtenerUsuario(MySqlCommand commando)
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
                personas.Add(p);
            }
            lector.Close();
            return personas;
        }
        
        public List<PersonaModelo> validarAlumno(string user, string pass)
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Alumno a,Persona p " +
                "WHERE p.ci=a.ci AND a.ci=@user AND p.clave=@pass AND P.isDeleted=false;";
            this.comando.Parameters.AddWithValue("user", user);
            this.comando.Parameters.AddWithValue("pass", pass);
            return obtenerUsuario(this.comando);
        }

        public List<PersonaModelo> validarDocente(string user, string pass)
        {
            this.comando.CommandText = "SELECT d.ci, p.clave, p.nombre, p.apellido FROM Docente d,Persona p " +
                "WHERE p.ci=d.ci AND d.ci=@user AND p.clave=@pass AND P.isDeleted=false;";
            this.comando.Parameters.AddWithValue("user", user);
            this.comando.Parameters.AddWithValue("pass", pass);
            return obtenerUsuario(this.comando);
        }

        public List<PersonaModelo> validarAdmin(string user, string pass)
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM Administrador a, Persona p " +
                "WHERE p.ci = a.ci AND a.ci = @user AND p.clave = @pass AND P.isDeleted=false;";
            this.comando.Parameters.AddWithValue("user", user);
            this.comando.Parameters.AddWithValue("pass", pass);
            return obtenerUsuario(this.comando);
        }

        public List<PersonaModelo> obtenerPersona()
        {
            this.comando.CommandText = "SELECT ci, nombre, apellido FROM Persona;";
            List<PersonaModelo> personas = new List<PersonaModelo>();
            lector = this.comando.ExecuteReader();
            while (lector.Read())
            {
                PersonaModelo p = new PersonaModelo();
                p.Cedula = lector[0].ToString();
                p.Nombre = lector[1].ToString();
                p.Apellido = lector[2].ToString();
                personas.Add(p);
            }

            lector.Close();
            return personas;
        }

        public PersonaModelo obtenerPersona(string cedula)
        {
            this.comando.CommandText = "SELECT p.ci, p.nombre, p.apellido, p.foto, p.avatar, p.enLinea FROM Persona p " +
                "WHERE p.ci=@cedula";
            this.comando.Parameters.AddWithValue("cedula", cedula);
            PersonaModelo persona = new PersonaModelo();
            lector = this.comando.ExecuteReader();
            while (lector.Read())
            {
                persona.Cedula = lector[0].ToString();
                persona.Nombre = lector[1].ToString();
                persona.Apellido = lector[2].ToString();
                persona.foto = null;    //lector[3];
                persona.avatar = null;  //lector[4];
            }

            lector.Close();
            return persona;
        }

        /*  public List<PersonaModelo> obtenerMaterias()
          {
              this.comando.CommandText = "SELECT nombreMateria From Materia;";
              lector = this.comando.ExecuteReader();

              List<PersonaModelo> materias = new List<PersonaModelo>();

              while (lector.Read())
              {
                  PersonaModelo p = new PersonaModelo();

                  p.materia = lector[0].ToString();
                  materias.Add(p);
              }

              return materias;

          }   */
    }
}
