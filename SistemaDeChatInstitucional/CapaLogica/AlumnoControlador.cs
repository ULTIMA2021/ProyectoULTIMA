﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;


namespace CapaLogica
{
    public static class AlumnoControlador
    {
        public static string nombreRemitente;
        public static string nombreDestinatario;
        public static string mensajeEnviado;
        public static string ciDestinatario;
         //implementear en segunda entrega
         /*
        public static void AltaTempPersona(string cedula, string nombre, string apellido, string clave,string apodo, string foto, byte avatar)
        {
            PersonaModelo Persona = new PersonaModelo();
            Persona.Cedula = cedula;
            Persona.Nombre = nombre;
            Persona.Apellido = apellido;
            Persona.Clave = clave;
            Persona.foto = null;
            Persona.avatar = null;
            Persona.GuardarTemp(tipoUsuario);
        }
    */
        public static void AltaPersona(string cedula, string nombre, string apellido, string clave /*, string foto, byte avatar*/)
        {
            PersonaModelo Persona = new PersonaModelo();
            Persona.Cedula = cedula;
            Persona.Nombre = nombre;
            Persona.Apellido = apellido;
            Persona.Clave = clave;
            Persona.foto = null;
            Persona.avatar = null;
            Persona.GuardarPersona();
        }

        //usado en formulario registro para ingresar alumno nuevo a tabla alumno y alumno_tiene_grupo
        public static void AltaAlumno(string cedula, string apodo, List<int> GruposDeAlumno) {
            PersonaModelo p = new PersonaModelo();
            GrupoModelo g = new GrupoModelo();
            p.Cedula = cedula;
            p.Apodo = apodo;
            p.guardarAlumno();
            foreach (int grupo in GruposDeAlumno) {
                g.nuevoIngresoAlumnoTieneGrupo(cedula,grupo);
            }
        }

        public static void AltaDocente(string cedula,List<int> GruposMateriasDeDocente ) {
            PersonaModelo p = new PersonaModelo();
            GrupoModelo g = new GrupoModelo();
            p.Cedula = cedula;
            p.guardarDocente();
            List<GrupoModelo>gm=g.getDocenteDictaGM();
            int idMateria;
            int idGrupo;
            foreach (int grupoMateria in GruposMateriasDeDocente)
            {
                idMateria = gm[grupoMateria].idMateria;
                idGrupo = gm[grupoMateria].idGrupo;
                g.actualizarDocenteTieneGM(cedula, idGrupo, idMateria);
            }
        }

        public static void AltaAdmin(string cedula) {
            PersonaModelo p = new PersonaModelo();
            p.Cedula = cedula;
            p.guardarAdmin();
        }

        public static void bajaPersona() {
            PersonaModelo p = new PersonaModelo();
            p.Cedula = Session.cedula;
            p.actualizarPersona(true);
        }

        public static void actualizarEstadoPersona(bool state) {
            PersonaModelo p = new PersonaModelo();
            p.Cedula = Session.cedula;
            p.enLinea = state;
            p.actualizarPersona();
        }

        public static bool actualizarClavePersona(string claveVieja,string claveNueva)
        {
            if (Session.clave == claveVieja) {
                PersonaModelo p = new PersonaModelo();
                p.Cedula = Session.cedula;
                p.actualizarPersona(claveNueva);
                return true;
            }
            return false;
        }

        public static bool existePersona(string ci) {
            PersonaModelo p = new PersonaModelo();
            //
            if (p.obtenerPersona(ci).Cedula == ci) {
                Console.WriteLine($"PERSON {ci} EXISTS IN SYSTEM");
                return false;
            }
            Console.WriteLine($"PERSON {ci} DOES NOT EXIST IN SYSTEM");
            return true;
        }

        public static bool lista (string user, string pass, Func<string, string, List<PersonaModelo>> metodoObtener)
        {
            PersonaModelo p = new PersonaModelo();
            List<PersonaModelo> personas = metodoObtener(user, pass);
            if (personas.Count == 1)
            {
                Session.saveToCache(personas[0]);
                return true;
            }
            return false;
        }

        public static bool isAlumno(string user, string pass)
        {
            Session.type = 0;
            PersonaModelo p = new PersonaModelo();
            return lista(user, pass, p.validarAlumno);
        }

        public static bool isDocente(string user, string pass)
        {
            Session.type = 1;
            PersonaModelo p = new PersonaModelo();
            return lista(user, pass, p.validarDocente);
        }

        public static bool isAdmin(string user, string pass)
        {
            Session.type = 2;
            PersonaModelo p = new PersonaModelo();
            return lista(user, pass, p.validarAdmin);
        }

        /*   public static DataTable listarMaterias()
           {
               PersonaModelo p = new PersonaModelo();
               List<PersonaModelo> materias = p.obtenerMaterias();
               DataTable tabla = new DataTable();

               tabla.Columns.Add("Materias");

               foreach (PersonaModelo materia in materias)
               {
                   tabla.Rows.Add(materia.materia);
               }


               return tabla;
           }

           */

        public static bool obtenerAlumno(string ci)
        {
            UsuarioModelo u = new UsuarioModelo();
           if( u.obtenerAlumno(ci).Count==0)
                return true;
            return false;
        }

        //original
        public static string obtenerDestinatario(string ci)
        {
            PersonaModelo p = new PersonaModelo();
            List<PersonaModelo> personas = p.obtenerPersona();
            foreach(PersonaModelo persona in personas)
            {
                if(persona.Cedula == ci)
                    nombreDestinatario = persona.Nombre + " " + persona.Apellido;
            }
              return nombreDestinatario;
        }
        //original
        public static string obtenerRemitente(string ci)
        {
            PersonaModelo p = new PersonaModelo();
            List<PersonaModelo> personas = p.obtenerPersona();
            foreach (PersonaModelo persona in personas)
            {
                if (persona.Cedula == ci)
                    nombreRemitente = persona.Nombre + " " + persona.Apellido;
            }
            return nombreRemitente;
        }

        //cambiar esto para que cargue todo en ua lista, para mostrar fotos tambien
        //o cambiarlo para reutilizar en otro lugar
        public static string traemeEstaPersona(string ci) {
            PersonaModelo p = new PersonaModelo();
            p = p.obtenerPersona(ci);
            List<string> personaString = new List<string>();
            personaString.Add(p.Nombre);
            personaString.Add(" ");
            personaString.Add(p.Apellido);
            personaString.Add(" ");
            if (p.enLinea == true)
                personaString.Add($"     en Linea");
            return string.Join("",personaString);
        }

        public static DataTable obtenerDocentes()
        {
            UsuarioModelo u = new UsuarioModelo();
            //PersonaModelo p = new PersonaModelo();
            List<PersonaModelo> docentes = u.obtenerDocente();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Cedula");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Apellido");
            foreach (PersonaModelo docente in docentes)
            {
                tabla.Rows.Add( docente.Cedula,docente.Nombre, docente.Apellido);
            }
            return tabla;
        }

        public static DataTable obtenerDocentes(int dummy) {
            UsuarioModelo u = new UsuarioModelo();
            List<PersonaModelo> MisDocentes = u.obtenerDocente();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Cedula");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Apellido");
            foreach (PersonaModelo docente in MisDocentes)
            {
                tabla.Rows.Add(docente.Cedula,docente.Nombre, docente.Apellido);
            }
            return tabla;
        }

        public static void prepararMensaje(int idConsultaPrivada,string docenteCi, string alumnoCi,
            string titulo, string cpStatus, DateTime cpFechaHora)
        {
            ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo();
            cp.crearConsultaPrivada(idConsultaPrivada,docenteCi, alumnoCi, titulo, cpStatus, cpFechaHora);
        }

        public static void enviarMensaje(int idCp_Mensaje, int idConsultaPrivada, int ciDocente, int ciAlumno, string contenido, string attachment,
                                   DateTime cp_mensajeFechaHora, string cp_mensajeStatus, int ciDestinatario)
        {
            MensajePrivadoModelo cpm = new MensajePrivadoModelo();
            cpm.enviarMensaje(idCp_Mensaje,idConsultaPrivada, ciDocente, ciAlumno, contenido, attachment, cp_mensajeFechaHora, cp_mensajeStatus, ciDestinatario);
        }

        public static int GetidConsultaPrivada(int ciDocente, int ciAlumno)
        {
            ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo();
            int idConsultaPrivada= cp.getIdConsultas(ciDocente, ciAlumno);
            Console.WriteLine($"EL ID DE LA CONSULTA PREVIA ES: {idConsultaPrivada}");
            idConsultaPrivada++;
            Console.WriteLine($"EL ID DE LA CONSULTA NUEVA ES: {idConsultaPrivada}");
            return idConsultaPrivada;
        }

        // metodo original
        public static DataTable ConsultasPrivada() {
            ConsultaPrivadaModelo consulta = new ConsultaPrivadaModelo();
            List<ConsultaPrivadaModelo> listaConsulta=null;
            if (Session.type == 0)
                listaConsulta = consulta.getConsultas(Session.cedula);
            else if (Session.type == 1)
                listaConsulta = consulta.getConsultas(Int32.Parse(Session.cedula));
            DataTable tabla = new DataTable();
            tabla.Columns.Add("idConsultaPrivada");
            tabla.Columns.Add("idMensaje");
            tabla.Columns.Add("ciDocente");
            tabla.Columns.Add("ciAlumno");
            tabla.Columns.Add("titulo de consulta");
            tabla.Columns.Add("Status de consulta");
            tabla.Columns.Add("Fecha Creada");
            tabla.Columns.Add("Destinatario");
            foreach (ConsultaPrivadaModelo c in listaConsulta)
            { 
                tabla.Rows.Add(c.idConsultaPrivada, c.idMensaje, c.ciDocente,c.ciAlumno,c.titulo, c.cpStatus, c.cpFechaHora, c.ciDestinatario);
            }
            return tabla;
        }

        public static List<List<string>> getMsgsFromConsulta(int idConsultaPrivada, string ciAlumno, string ciDocente) {
            MensajePrivadoModelo mpm = new MensajePrivadoModelo();
            List<List<string>> mensajesDeConsulta = new List<List<string>>();
            int x = 0;
            foreach (MensajePrivadoModelo m in mpm.mensajesDeConsulta(idConsultaPrivada, ciAlumno, ciDocente))
            {
                mensajesDeConsulta.Add(m.toStringList());
                Console.WriteLine(mensajesDeConsulta[x].ToString());
                x++;
            }
            return mensajesDeConsulta;
        }

        public static string obtenerMensaje(int idConsultaPrivada, string ciAlumno, string ciDocente)
        {
            MensajePrivadoModelo mpm = new MensajePrivadoModelo();
            
            foreach (MensajePrivadoModelo m in mpm.mensajesDeConsulta(idConsultaPrivada, ciAlumno, ciDocente))
            {
                mensajeEnviado = m.contenido;
                Console.WriteLine($"\n{m.ToString()}\n");
            }

            return mensajeEnviado;
        }

        public static List<string> gruposToListForRegister() {
            GrupoModelo grupo = new GrupoModelo();
            List<string> gString = new List<string>();
            foreach (GrupoModelo g in grupo.getGrupo()){
                gString.Add($"{g.idGrupo}   {g.nombreGrupo}");
            }
            return gString;
           
        }

        //Lista del query me muestra todas las materias-grupo pero la base no permite que hayan
        //mas de un docente para una materia-grupo
        //usar regular expression para extrar datos enves de usar index para mandar checked boxes.
        public static List<string> grupoMateriaToListForRegister() {
            List<string> gmString = new List<string>();
            GrupoModelo gm = new GrupoModelo();
            string entry;
            foreach (GrupoModelo g in gm.getDocenteDictaGM()) {
                entry = $"{g.nombreGrupo}   {g.nombreMateria}";
                gmString.Add(entry);
            }
            return gmString;
        }
    }
}
