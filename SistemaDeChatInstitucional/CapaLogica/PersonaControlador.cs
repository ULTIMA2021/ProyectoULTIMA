using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaLogica
{
    public static partial class Controlador
    {
        public static void AltaPersona(string cedula, string nombre, string apellido, string clave, byte[] foto)
        {
            PersonaModelo Persona = new PersonaModelo(Session.type);
            Persona.Cedula = cedula;
            Persona.Nombre = nombre;
            Persona.Apellido = apellido;
            Persona.Clave = clave;
            Persona.foto = foto;
            Persona.GuardarPersona();
        }
        public static void AltaAlumno(string cedula, string apodo, List<int> GruposDeAlumno)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            GrupoModelo g = new GrupoModelo(Session.type);
            p.Cedula = cedula;
            p.Apodo = apodo;
            p.guardarAlumno();
            foreach (int grupo in GruposDeAlumno)
            {
                g.nuevoIngresoAlumnoTieneGrupo(cedula, grupo);
            }
        }
        public static void AltaAlumno(string cedula, string nombre, string apellido, string clave, string apodo, byte[] foto, List<int> GruposDeAlumno)
        {
            string gruposString = "";
            PersonaModelo p = new PersonaModelo(Session.type);
            p.Cedula = cedula;
            p.Apodo = apodo;
            p.Apellido = apellido;
            p.Nombre = nombre;
            p.Clave = clave;
            p.foto = foto;
            if (GruposDeAlumno.Count > 0)
                for (int x = 0; x < GruposDeAlumno.Count; x++)
                    if (x == GruposDeAlumno.Count - 1)
                        gruposString += $"{GruposDeAlumno[x].ToString()}";
                    else
                        gruposString += $"{GruposDeAlumno[x].ToString()}-";
            else
                gruposString = null;
            p.guardarAlumno(gruposString);
        }
        public static void AltaDocente(string cedula, List<int> GruposMateriasDeDocente)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            GrupoModelo g = new GrupoModelo(Session.type);
            p.Cedula = cedula;
            p.guardarDocente();
            List<GrupoModelo> gm = g.getDocenteDictaGM();
            int idMateria;
            int idGrupo;
            foreach (int grupoMateria in GruposMateriasDeDocente)
            {
                idMateria = gm[grupoMateria].idMateria;
                idGrupo = gm[grupoMateria].idGrupo;
                g.actualizarDocenteTieneGM(cedula, idGrupo.ToString(), idMateria.ToString());
            }
        }
        public static void AltaAdmin(string cedula)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            p.Cedula = cedula;
            p.guardarAdmin();
        }

        public static void deactivatePerson(string ci, bool isDeleted) => new PersonaModelo(Session.type).actualizarPersona(ci, isDeleted);
        public static void bajaPersona(string ci) => new PersonaModelo(Session.type).bajaPersona(ci);
        public static void bajaAlumnoTemp(string ci) => new PersonaModelo(Session.type).bajaAlumnoTemp(ci);

        public static void actualizarEstadoPersona(bool state)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            p.Cedula = Session.cedula;
            p.enLinea = state;
            p.actualizarPersona();
        }
        public static bool actualizarClavePersona(string claveVieja, string claveNueva, string ci)
        {
            if(CryptographyUtils.comparePasswords(claveVieja,Session.clave))
            {
                string encrypted = CryptographyUtils.doEncryption(claveNueva, null, null);
                new PersonaModelo(Session.type).actualizarPersona(ci,encrypted);
                Session.clave = encrypted;
                return true;
            }
            return false;
        }
        public static void actualizarClavePersona(string ci, string claveNueva) => new PersonaModelo(Session.type).actualizarPersona(ci,claveNueva);
        public static void actualizarPersona(string ci, string nombre, string apellido, string clave, byte [] foto) => 
            new PersonaModelo(Session.type).actualizarPersona(ci, nombre, apellido, clave, foto);

        public static bool existePersona(string ci)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            if (p.obtenerPersona(ci).Cedula == ci)
            {
                Console.WriteLine($"PERSON {ci} EXISTS IN SYSTEM");
                throw new Exception($"Persona-1062");
            }
            Console.WriteLine($"PERSON {ci} DOES NOT EXIST IN SYSTEM");
            return true;
        }

        public static bool isAlumno(string user, string pass)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            return lista(user, pass, Session.type, p.validarAlumno);
        }
        public static bool isDocente(string user, string pass)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            return lista(user, pass, Session.type, p.validarDocente);
        }
        public static bool isAdmin(string user, string pass)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            return lista(user, pass, Session.type, p.validarAdmin);
        }
        private static bool lista(string user, string pass, byte sessionType, Func<string, List<PersonaModelo>> metodoObtener)
        {
            List<PersonaModelo> personas = metodoObtener(user);
            if (personas.Count == 1)
            {
                bool okPassword = CryptographyUtils.comparePasswords(pass, personas[0].Clave);
                if (okPassword)
                    setSession(personas[0]);
                return okPassword;
            }
            return false;
        }

        private static void setSession(PersonaModelo per)
        {
            switch (Session.type)
            {
                case 3:
                    Session.type = 0;
                    GrupoModelo g = new GrupoModelo(Session.type);
                    Session.saveToCache(per, g.getAlumnoGrupoyYmaterias(per.Cedula));
                    return;
                case 4:
                    Session.type = 1;
                    GrupoModelo gm = new GrupoModelo(Session.type);
                    Session.saveToCache(per, gm.getDocenteDictaGM(per.Cedula));
                    return;
                case 5:
                    Session.type = 2;
                    Session.saveToCache(per, null);
                    return;
            }
        }

        //public static List<string> obtenerPersona()
        //{
        //    foreach (PersonaModelo persona in new PersonaModelo(Session.type).obtenerPersona(Session.type)
        //    {
        //        pers
        //    }
        //}

        public static bool obtenerAlumno(string ci)
        {
            PersonaModelo u = new PersonaModelo(Session.type);
            if (u.obtenerAlumno(ci).Count == 0)
                return true;
            return false;
        }
        public static List<List<string>> obtenerAlumnoTemp()
        {
            List<List<string>> alumnos = new List<List<string>>();
            foreach (var item in new PersonaModelo(Session.type).obtenerAlumnoTemp())
            {
                List<string> a = new List<string>();
                a.Add(item.Cedula);
                a.Add(item.Nombre);
                a.Add(item.Apellido);
                a.Add(item.Apodo);
                a.Add(item.Grupos);
                a.Add(item.Clave);
                alumnos.Add(a);
            }
            return alumnos;
        }
        public static byte[] obtenerFotoAlumnoTemp(string ciAlumnoTemp)=> new PersonaModelo(Session.type).obtenerAlumnoTemp(ciAlumnoTemp);
        

        //cambiar esto para que cargue todo en una lista, para mostrar fotos tambien
        public static string traemeEstaPersona(string ci)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            p = p.obtenerPersona(ci);
            List<string> personaString = new List<string>();
            personaString.Add(p.Nombre);
            personaString.Add(" ");
            personaString.Add(p.Apellido);
            return string.Join("", personaString);
        }
        public static List<List<string>> obtenerPersona()
        {
            List<List<string>> personas = new List<List<string>>();
            List<PersonaModelo> admins = new PersonaModelo(Session.type).obtenerAdmin();
            List<PersonaModelo> docentes = new PersonaModelo(Session.type).obtenerDocente();
            List<PersonaModelo> alumnos = new PersonaModelo(Session.type).obtenerAlumno();

            for (int i = 0; i < admins.Count; i++)
            {
                List<string> p = new List<string>();
                p.Add(admins[i].Cedula);
                p.Add(admins[i].Nombre);
                p.Add(admins[i].Apellido);
                p.Add(admins[i].Clave);
                p.Add("3");
                personas.Add(p);
            }
            for (int i = 0; i < docentes.Count; i++)
            {
                List<string> p = new List<string>();
                p.Add(docentes[i].Cedula);
                p.Add(docentes[i].Nombre);
                p.Add(docentes[i].Apellido);
                p.Add(docentes[i].Clave);
                p.Add("2");
                personas.Add(p);
            }
            for (int i = 0; i < alumnos.Count; i++)
            {
                List<string> p = new List<string>();
                p.Add(alumnos[i].Cedula);
                p.Add(alumnos[i].Nombre);
                p.Add(alumnos[i].Apellido);
                p.Add(alumnos[i].Clave);
                p.Add("1");
                p.Add(alumnos[i].Apodo);
                personas.Add(p);
            }
            return personas;
        }
        public static byte[] obtenerFotoPersona(string ci) => new PersonaModelo(Session.type).obtenerPersona(ci,1);

        public static DataTable obtenerDocentes()
        {
            DataTable tabla = new DataTable(); 
            tabla.Columns.Add("Cedula");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Apellido");
            foreach (PersonaModelo docente in new PersonaModelo(Session.type).obtenerDocente())
            {
                tabla.Rows.Add(docente.Cedula, docente.Nombre, docente.Apellido);
            }
            return tabla;
        }
    }
}
