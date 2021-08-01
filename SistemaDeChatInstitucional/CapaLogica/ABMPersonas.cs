﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaLogica
{
    public static partial class AlumnoControlador
    {
        public static void AltaPersona(string cedula, string nombre, string apellido, string clave /*, string foto, byte avatar*/)
        {
            PersonaModelo Persona = new PersonaModelo(Session.type);
            Persona.Cedula = cedula;
            Persona.Nombre = nombre;
            Persona.Apellido = apellido;
            Persona.Clave = clave;
            Persona.foto = null;
            Persona.avatar = null;
            Persona.GuardarPersona();
        }

        //usado en formulario registro para ingresar alumno nuevo a tabla alumno y alumno_tiene_grupo
        public static void AltaAlumno(string cedula, string apodo, List<int> GruposDeAlumno)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            GrupoModelo g = new GrupoModelo();
            p.Cedula = cedula;
            p.Apodo = apodo;
            p.guardarAlumno();
            foreach (int grupo in GruposDeAlumno)
            {
                g.nuevoIngresoAlumnoTieneGrupo(cedula, grupo);
            }
        }

        public static void AltaDocente(string cedula, List<int> GruposMateriasDeDocente)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            GrupoModelo g = new GrupoModelo();
            p.Cedula = cedula;
            p.guardarDocente();
            List<GrupoModelo> gm = g.getDocenteDictaGM();
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
            //
            if (p.obtenerPersona(ci, Session.type).Cedula == ci)
            {
                Console.WriteLine($"PERSON {ci} EXISTS IN SYSTEM");
                return false;
            }
            Console.WriteLine($"PERSON {ci} DOES NOT EXIST IN SYSTEM");
            return true;
        }

        public static bool isAlumno(string user, string pass)
        {
            Session.type = 3;
            PersonaModelo p = new PersonaModelo(Session.type);
            return lista(user, pass, Session.type, p.validarAlumno);
        }

        public static bool isDocente(string user, string pass)
        {
            Session.type = 3;
            PersonaModelo p = new PersonaModelo(Session.type);
            return lista(user, pass, Session.type, p.validarDocente);
        }

        public static bool isAdmin(string user, string pass)
        {
            Session.type = 3;
            PersonaModelo p = new PersonaModelo(Session.type);
            return lista(user, pass, Session.type, p.validarAdmin);
        }

        public static bool lista(string user, string pass, byte sessionType, Func<string, string, byte ,List<PersonaModelo>> metodoObtener)
        {
            PersonaModelo p = new PersonaModelo(Session.type);
            List<PersonaModelo> personas = metodoObtener(user, pass, Session.type);
            if (personas.Count == 1)
            {
                Session.saveToCache(personas[0]);
                return true;
            }
            return false;
        }

    }
}