using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;


namespace CapaLogica
{
    public static partial class Controlador
    {
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

        public static void prepararMensaje(int idConsultaPrivada,string docenteCi, string alumnoCi,
            string titulo, string cpStatus, DateTime cpFechaHora)
        {
            ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo(Session.type);
            cp.crearConsultaPrivada(idConsultaPrivada,docenteCi, alumnoCi, titulo, cpStatus, cpFechaHora);
        }

        public static void enviarMensaje(int idCp_Mensaje, int idConsultaPrivada, int ciDocente, int ciAlumno, string contenido, string attachment,
                                   DateTime cp_mensajeFechaHora, string cp_mensajeStatus, int ciDestinatario)
        {
            MensajePrivadoModelo cpm = new MensajePrivadoModelo(Session.type);
            cpm.enviarMensaje(idCp_Mensaje,idConsultaPrivada, ciDocente, ciAlumno, contenido, attachment, cp_mensajeFechaHora, cp_mensajeStatus, ciDestinatario);
        }

        public static int GetidConsultaPrivada(int ciDocente, int ciAlumno)
        {
            ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo(Session.type);
            int idConsultaPrivada= cp.getIdConsultas(ciDocente, ciAlumno, Session.type);
            Console.WriteLine($"EL ID DE LA CONSULTA PREVIA ES: {idConsultaPrivada}");
            idConsultaPrivada++;
            Console.WriteLine($"EL ID DE LA CONSULTA NUEVA ES: {idConsultaPrivada}");
            return idConsultaPrivada;
        }

        // metodo original
        public static DataTable ConsultasPrivada() {
            ConsultaPrivadaModelo consulta = new ConsultaPrivadaModelo(Session.type);
            List<ConsultaPrivadaModelo> listaConsulta=null;
            if (Session.type == 0)
                listaConsulta = consulta.getConsultas(Session.cedula, Session.type);
            else if (Session.type == 1)
                listaConsulta = consulta.getConsultas(Int32.Parse(Session.cedula), Session.type);
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
            MensajePrivadoModelo mpm = new MensajePrivadoModelo(Session.type);
            List<List<string>> mensajesDeConsulta = new List<List<string>>();
            int x = 0;
            foreach (MensajePrivadoModelo m in mpm.mensajesDeConsulta(idConsultaPrivada, ciAlumno, ciDocente, Session.type))
            {
                mensajesDeConsulta.Add(m.toStringList());
                Console.WriteLine(mensajesDeConsulta[x].ToString());
                x++;
            }
            return mensajesDeConsulta;
        }

        public static string obtenerMensaje(int idConsultaPrivada, string ciAlumno, string ciDocente)
        {
            MensajePrivadoModelo mpm = new MensajePrivadoModelo(Session.type);
            string contenidoMensaje="";
            foreach (MensajePrivadoModelo m in mpm.mensajesDeConsulta(idConsultaPrivada, ciAlumno, ciDocente, Session.type))
            {
                contenidoMensaje = m.contenido;
                Console.WriteLine($"\n{m.ToString()}\n");
            }

            return contenidoMensaje;
        }

        public static List<string> gruposToListForRegister() {
            GrupoModelo grupo = new GrupoModelo(Session.type);
            List<string> gString = new List<string>();
            foreach (GrupoModelo g in grupo.getGrupo(Session.type)){
                gString.Add($"{g.idGrupo}   {g.nombreGrupo}");
            }
            return gString;
           
        }

        //Lista del query me muestra todas las materias-grupo pero la base no permite que hayan
        //mas de un docente para una materia-grupo
        //usar regular expression para extrar datos enves de usar index para mandar checked boxes.
        public static List<string> grupoMateriaToListForRegister() {
            List<string> gmString = new List<string>();
            GrupoModelo gm = new GrupoModelo(Session.type);
            string entry;
            foreach (GrupoModelo g in gm.getDocenteDictaGM(Session.type)) {
                entry = $"{g.nombreGrupo}   {g.nombreMateria}";
                gmString.Add(entry);
            }
            return gmString;
        }
    }
}
