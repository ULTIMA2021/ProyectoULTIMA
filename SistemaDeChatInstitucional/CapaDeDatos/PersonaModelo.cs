using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

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
        public byte[] foto;
        public bool isDeleted;
        public bool enLinea;
        public string Grupos;

        public PersonaModelo(byte sessionType) : base(sessionType)
        {
        }
        public PersonaModelo() { }

        public void GuardarPersona()
        {
            this.comando.CommandText = "INSERT INTO persona (ci,nombre,apellido,clave,isDeleted,enLinea,foto) VALUES(" +
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
            this.comando.CommandText = "INSERT INTO alumno (ci,apodo) VALUES (@Cedula,@Apodo);";
            this.comando.Parameters.AddWithValue("Cedula", this.Cedula);
            this.comando.Parameters.AddWithValue("Apodo", this.Apodo);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void guardarAlumno(string grupos)
        {
            this.comando.CommandText = "INSERT INTO alumnotemp (ci, nombre, apellido, clave, foto, apodo, grupos) " +
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
            try
            {
                this.comando.Parameters.Clear();
            }
            catch 
            {
            }
            this.comando.CommandText = "INSERT INTO docente (ci) VALUES (@cedula);";
            this.comando.Parameters.AddWithValue("@cedula", this.Cedula);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void guardarAdmin()
        {
            this.comando.CommandText = "INSERT INTO administrador (ci) VALUES(@Cedula);";
            this.comando.Parameters.AddWithValue("@cedula", this.Cedula);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }

        public void actualizarPersona()
        {
            this.comando.CommandText = "UPDATE persona SET enLinea=@enLinea WHERE ci=@Cedula;";
            this.comando.Parameters.AddWithValue("Cedula", this.Cedula);
            this.comando.Parameters.AddWithValue("enLinea", this.enLinea);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void actualizarPersona(string clave)
        {
            this.comando.CommandText = "UPDATE persona SET clave=@clave WHERE ci=@Cedula;";
            this.comando.Parameters.AddWithValue("Cedula", Cedula);
            this.comando.Parameters.AddWithValue("clave", clave);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void actualizarPersona(string ci, string clave)
        {
            this.comando.CommandText = "UPDATE persona SET clave=@clave WHERE ci=@ci;";
            this.comando.Parameters.AddWithValue("@ci", ci);
            this.comando.Parameters.AddWithValue("@clave", clave);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void actualizarPersona(string ci, bool isDeleted)
        {
            this.comando.CommandText = "UPDATE persona SET isDeleted=@isDeleted WHERE ci=@ci;";
            this.comando.Parameters.AddWithValue("@ci", ci);
            this.comando.Parameters.AddWithValue("@isDeleted", isDeleted);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void actualizarPersona(string ci, string nombre, string apellido, string clave, byte []foto)
        {
            this.comando.CommandText = "UPDATE persona SET nombre=@nombre, apellido=@apellido, clave=@clave, foto=@foto " +
                "WHERE ci=@ci;";
            this.comando.Parameters.AddWithValue("@ci",ci);
            this.comando.Parameters.AddWithValue("@nombre",nombre);
            this.comando.Parameters.AddWithValue("@apellido",apellido);
            this.comando.Parameters.AddWithValue("@clave",clave);
            this.comando.Parameters.AddWithValue("@foto",foto);
            this.comando.Prepare();
            EjecutarQuery(comando, errorType);
        }

        public void bajaAlumnoTemp(string ci)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "DELETE FROM alumnotemp WHERE ci=@ci";
            this.comando.Parameters.AddWithValue("@ci", ci);
            this.comando.Prepare();
            EjecutarQuery(comando, errorType);
        }
        public void bajaPersona(string ci)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "DELETE FROM persona WHERE ci=@ci";
            this.comando.Parameters.AddWithValue("@ci", ci);
            this.comando.Prepare();
            EjecutarQuery(comando, errorType);
        }

        public void insertIntoUserLogs(string ci)
        {
            comando.CommandText = "INSERT INTO userlogs(ci, login, logout) VALUES(@ci, NOW(), NULL);";
            comando.Parameters.AddWithValue("@ci",ci);
            comando.Prepare();
            EjecutarQuery(comando,errorType);
        }
        public void updateLastUserlog(string ci)
        {
            comando.CommandText = "UPDATE userlogs SET logout=NOW() WHERE ci=@ci AND logout IS NULL;";
            comando.Parameters.AddWithValue("@ci", ci);
            comando.Prepare();
            EjecutarQuery(comando, errorType);
        }
        public List<List<string>> getUserLogs(string ci)
        {
            comando.CommandText = "SELECT login, logOut FROM userlogs WHERE ci=@ci ORDER BY login ASC;";
            comando.Parameters.AddWithValue("@ci", ci);
            comando.Prepare();
            EjecutarQuery(comando, errorType);
            lector = comando.ExecuteReader();
            List<List<string>> logs = new List<List<string>>();
            while (lector.Read())
            {
                List<string> l = new List<string>();
                l.Add(lector[0].ToString());
                l.Add(lector[1].ToString());
                logs.Add(l);
            }
            lector.Close();
            return logs;
        }

        private List<PersonaModelo> obtenerUsuario(MySqlCommand commando)
        {
            lector = commando.ExecuteReader();
            List<PersonaModelo> personas = new List<PersonaModelo>();
            while (lector.Read())
            {
                PersonaModelo p = new PersonaModelo();
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

        public List<PersonaModelo> validarAlumno(string user)
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido, p.foto FROM alumno a,persona p " +
                "WHERE p.ci=a.ci AND a.ci=@user AND p.isDeleted=false;";
            this.comando.Parameters.AddWithValue("user", user);
            lector = comando.ExecuteReader();
            List<PersonaModelo> personas = new List<PersonaModelo>();
            while (lector.Read())
            {
                PersonaModelo p = new PersonaModelo();
                // Console.WriteLine("ci: " + lector[0].ToString() + "    " + lector[1].ToString() + "    " + lector[2].ToString() + "    " + lector[3].ToString());
                p.Cedula = lector[0].ToString();
                byte[] claveArray = Encoding.Default.GetBytes(lector[1].ToString());
                p.Clave = Encoding.Default.GetString(claveArray);
                p.Nombre = lector[2].ToString();
                p.Apellido = lector[3].ToString();
                try
                {
                    p.foto = (byte[])lector[4];
                }
                catch (Exception wx)
                {}
                personas.Add(p);
            }
            lector.Close();
            return personas;
           // return obtenerUsuario(this.comando, sessionType);
        }

        public List<PersonaModelo> validarDocente(string user )
        {
            this.comando.CommandText = "SELECT d.ci, p.clave, p.nombre, p.apellido, p.foto FROM docente d,persona p " +
                "WHERE p.ci=d.ci AND d.ci=@user AND p.isDeleted=false;";
            this.comando.Parameters.AddWithValue("user", user);
            lector = comando.ExecuteReader();
            List<PersonaModelo> personas = new List<PersonaModelo>();
            while (lector.Read())
            {
                PersonaModelo p = new PersonaModelo();
                // Console.WriteLine("ci: " + lector[0].ToString() + "    " + lector[1].ToString() + "    " + lector[2].ToString() + "    " + lector[3].ToString());
                p.Cedula = lector[0].ToString();
                byte[] claveArray = Encoding.Default.GetBytes(lector[1].ToString());
                p.Clave = Encoding.Default.GetString(claveArray);
                p.Nombre = lector[2].ToString();
                p.Apellido = lector[3].ToString();
                try
                {
                    p.foto = (byte[])lector[4];
                }
                catch (Exception wx)
                { }
                personas.Add(p);
            }
            lector.Close();
            return personas;
        }

        public List<PersonaModelo> validarAdmin(string user )
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido, p.foto FROM administrador a, persona p " +
                "WHERE p.ci = a.ci AND a.ci = @user AND p.isDeleted=false;";
            this.comando.Parameters.AddWithValue("user", user);
            lector = comando.ExecuteReader();
            List<PersonaModelo> personas = new List<PersonaModelo>();
            while (lector.Read())
            {
                PersonaModelo p = new PersonaModelo();
                // Console.WriteLine("ci: " + lector[0].ToString() + "    " + lector[1].ToString() + "    " + lector[2].ToString() + "    " + lector[3].ToString());
                p.Cedula = lector[0].ToString();
                byte[] claveArray = Encoding.Default.GetBytes(lector[1].ToString());
                p.Clave = Encoding.Default.GetString(claveArray);
                p.Nombre = lector[2].ToString();
                p.Apellido = lector[3].ToString();
                try
                {
                    p.foto = (byte[])lector[4];
                }
                catch (Exception wx)
                { }
                personas.Add(p);
            }
            lector.Close();
            return personas;
        }

        public byte[] obtenerPersona(string ci, byte dummy)
        {
            byte[] foto = null;
            comando.Parameters.Clear();
            comando.CommandText = "SELECT foto FROM persona WHERE ci=@ci;";
            comando.Parameters.AddWithValue("@ci", ci);
            lector = comando.ExecuteReader();
            while (lector.Read())
                try
                {
                    foto = (byte[])lector[0];
                }
                catch (Exception)
                {
                }
            lector.Close();
            return foto;
        }

        public PersonaModelo obtenerPersona(string cedula)
        {
            this.comando.CommandText = "SELECT p.ci, p.nombre, p.apellido, p.foto, p.enLinea FROM persona p " +
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
                persona.enLinea = bool.Parse(lector[4].ToString());
            }

            lector.Close();
            return persona;
        }

        public List<PersonaModelo> obtenerAlumnoTemp()
        {
            comando.CommandText = "SELECT ci, nombre, apellido, apodo, grupos, foto, clave FROM alumnotemp;";
            lector = comando.ExecuteReader();
            List<PersonaModelo> personas = new List<PersonaModelo>();
            while (lector.Read())
            {
                PersonaModelo p = new PersonaModelo();
                p.Cedula = lector[0].ToString();
                p.Nombre = lector[1].ToString();
                p.Apellido = lector[2].ToString();
                p.Apodo = lector[3].ToString();
                p.Grupos = lector[4].ToString();
                try
                {
                    p.foto = (byte[])lector[5];
                }
                catch (Exception wx)
                { }
                byte[] claveArray = Encoding.Default.GetBytes(lector[6].ToString());
                p.Clave = Encoding.Default.GetString(claveArray);
                personas.Add(p);
            }
            lector.Close();
            return personas;
        }
        public byte [] obtenerAlumnoTemp(string ci)
        {
            byte[] foto = null;
            comando.Parameters.Clear();
            comando.CommandText = "SELECT foto FROM alumnotemp WHERE ci=@ci;";
            comando.Parameters.AddWithValue("@ci",ci);
            lector = comando.ExecuteReader();
            while (lector.Read())
                foto = (byte[])lector[0];
            lector.Close();
            return foto;
        }

        //retorna tabla entera de alumno con algunos campos de persona
        public List<PersonaModelo> obtenerAlumno()
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido, a.apodo FROM alumno a INNER JOIN persona p ON " +
                                         "(a.ci=p.ci);";
            return obtenerUsuario(this.comando);
        }

        public List<PersonaModelo> obtenerAlumno(string ci)
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM alumno a, persona p WHERE " +
                                                     "a.ci=p.ci AND a.ci=@ci;";
            this.comando.Parameters.AddWithValue("ci", ci);
            return obtenerUsuario(this.comando);
        }

        public List<PersonaModelo> obtenerDocente()
        {
            this.comando.CommandText = "SELECT d.ci, p.clave, p.nombre, p.apellido FROM docente d INNER JOIN persona p ON " +
                                         "d.ci=p.ci AND isDeleted = FALSE;";
            return obtenerUsuario(this.comando);
        }

        public List<PersonaModelo> obtenerDatosDocente()
        {
            this.comando.CommandText = "SELECT p.nombre, p.apellido FROM docente d INNER JOIN persona p ON " +
                                         "d.ci=p.ci AND isDeleted=FALSE;";
            return obtenerUsuario(this.comando);
        }

        public List<PersonaModelo> obtenerAdmin()
        {
            this.comando.CommandText = "SELECT a.ci, p.clave, p.nombre, p.apellido FROM administrador a INNER JOIN persona p ON " +
                                         "a.ci=p.ci AND isDeleted=FALSE;";
            return obtenerUsuario(this.comando);
        }

    }
}