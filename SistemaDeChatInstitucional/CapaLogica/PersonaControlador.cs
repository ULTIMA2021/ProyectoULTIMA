﻿using System;
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
            List<GrupoModelo> gm = g.getDocenteDictaGM(Session.type);
            int idMateria;
            int idGrupo;
            foreach (int grupoMateria in GruposMateriasDeDocente)
            {
                idMateria = gm[grupoMateria].idMateria;
                idGrupo = gm[grupoMateria].idGrupo;
                g.actualizarDocenteTieneGM(cedula, idGrupo, idMateria);
            }
        }
        public static void AltaAdmin(string cedula)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            p.Cedula = cedula;
            p.guardarAdmin();
        }

        public static void bajaPersona()
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            p.Cedula = Session.cedula;
            p.actualizarPersona(true);
        }
        public static void bajaPersona(string ci) => new PersonaModelo(Session.type).bajaPersona(ci);
        public static void bajaAlumnoTemp(string ci) => new PersonaModelo(Session.type).bajaAlumnoTemp(ci);

        public static void actualizarEstadoPersona(bool state)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            p.Cedula = Session.cedula;
            p.enLinea = state;
            p.actualizarPersona();
        }
        public static bool actualizarClavePersona(string claveVieja, string claveNueva)
        {
            if (Session.clave == claveVieja)
            {
                PersonaModelo p = new PersonaModelo(Session.type);
                p.Cedula = Session.cedula;
                p.actualizarPersona(claveNueva);
                return true;
            }
            return false;
        }

        public static bool existePersona(string ci)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            if (p.obtenerPersona(ci, Session.type).Cedula == ci)
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
        private static bool lista(string user, string pass, byte sessionType, Func<string, byte, List<PersonaModelo>> metodoObtener)
        {
            List<PersonaModelo> personas = metodoObtener(user, Session.type);
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
                    Session.saveToCache(per, g.getAlumnoGrupoyYmaterias(per.Cedula, Session.type));
                    return;
                case 4:
                    Session.type = 1;
                    GrupoModelo gm = new GrupoModelo(Session.type);
                    Session.saveToCache(per, gm.getDocenteDictaGM(per.Cedula, Session.type));
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
            if (u.obtenerAlumno(ci, Session.type).Count == 0)
                return true;
            return false;
        }
        public static List<List<string>> obtenerAlumnoTemp()
        {
            List<List<string>> alumnos = new List<List<string>>();
            foreach (var item in new PersonaModelo(Session.type).obtenerAlumnoTemp(Session.type))
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
            p = p.obtenerPersona(ci, Session.type);
            List<string> personaString = new List<string>();
            personaString.Add(p.Nombre);
            personaString.Add(" ");
            personaString.Add(p.Apellido);
            return string.Join("", personaString);
        }
        public static List<List<string>> obtenerPersona()
        {
            List<List<string>> personas = new List<List<string>>();
            List<PersonaModelo> admins = new PersonaModelo(Session.type).obtenerAdmin(Session.type);
            List<PersonaModelo> docentes = new PersonaModelo(Session.type).obtenerDocente(Session.type);
            List<PersonaModelo> alumnos = new PersonaModelo(Session.type).obtenerAlumno(Session.type);

            for (int i = 0; i < admins.Count; i++)
            {
                List<string> p = new List<string>();
                p.Add(admins[i].Cedula);
                p.Add(admins[i].Nombre);
                p.Add(admins[i].Apellido);
                p.Add(admins[i].Clave);
                p.Add("A");
                personas.Add(p);
            }
            for (int i = 0; i < docentes.Count; i++)
            {
                List<string> p = new List<string>();
                p.Add(docentes[i].Cedula);
                p.Add(docentes[i].Nombre);
                p.Add(docentes[i].Apellido);
                p.Add(docentes[i].Clave);
                p.Add("D");
                personas.Add(p);
            }
            for (int i = 0; i < alumnos.Count; i++)
            {
                List<string> p = new List<string>();
                p.Add(alumnos[i].Cedula);
                p.Add(alumnos[i].Nombre);
                p.Add(alumnos[i].Apellido);
                p.Add(alumnos[i].Clave);
                p.Add("S");
                p.Add(alumnos[i].Apodo);
                personas.Add(p);
            }
            return personas;
        }
        public static byte[] obtenerFotoPersona(string ci) => new PersonaModelo(Session.type).obtenerPersona(ci);

        public static DataTable obtenerDocentes()
        {
            DataTable tabla = new DataTable(); 
            tabla.Columns.Add("Cedula");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Apellido");
            foreach (PersonaModelo docente in new PersonaModelo(Session.type).obtenerDocente(Session.type))
            {
                tabla.Rows.Add(docente.Cedula, docente.Nombre, docente.Apellido);
            }
            return tabla;
        }
    }
}
