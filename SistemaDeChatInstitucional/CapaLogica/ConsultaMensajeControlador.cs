using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaLogica
{
    public static partial class Controlador
    {
        public static string getMensajesStatusCount( string status)
        {
            MensajePrivadoModelo m = new MensajePrivadoModelo(Session.type);
            m.ciDestinatario = int.Parse(Session.cedula);
            m.cp_mensajeStatus = status;
            return m.mensajesDeConsultaCount();
        }


        public static void finalizarConsulta(int idConsultaPrivada, int ciDocente, int ciAlumno)
        {
            ConsultaPrivadaModelo cpm = new ConsultaPrivadaModelo(Session.type);
            cpm.ciAlumno = ciAlumno;
            cpm.ciDocente = ciDocente;
            cpm.idConsultaPrivada = idConsultaPrivada;
            cpm.updateConsultaStatus();
        }

        public static void prepararMensaje(int idConsultaPrivada, string docenteCi, string alumnoCi,
            string titulo, string cpStatus, DateTime cpFechaHora)
        {
            ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo(Session.type);
            cp.crearConsultaPrivada(idConsultaPrivada, docenteCi, alumnoCi, titulo, cpStatus, cpFechaHora);
        }

        public static void enviarMensaje(int idCp_Mensaje, int idConsultaPrivada, int ciDocente, int ciAlumno, string contenido, string attachment,
                                   DateTime cp_mensajeFechaHora, string cp_mensajeStatus, int ciDestinatario)
        {
            MensajePrivadoModelo cpm = new MensajePrivadoModelo(Session.type);
            cpm.enviarMensaje(idCp_Mensaje, idConsultaPrivada, ciDocente, ciAlumno, contenido, attachment, cp_mensajeFechaHora, cp_mensajeStatus, ciDestinatario);
        }

        public static int GetidConsultaPrivada(int ciDocente, int ciAlumno)
        {
            ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo(Session.type);
            int idConsultaPrivada = cp.getIdConsultas(ciDocente, ciAlumno, Session.type);
            //Console.WriteLine($"EL ID DE LA CONSULTA PREVIA ES: {idConsultaPrivada}");
            idConsultaPrivada++;
           // Console.WriteLine($"EL ID DE LA CONSULTA NUEVA ES: {idConsultaPrivada}");
            return idConsultaPrivada;
        }

        // metodo original
        public static DataTable ConsultasPrivada()
        {
            ConsultaPrivadaModelo consulta = new ConsultaPrivadaModelo(Session.type);
            List<ConsultaPrivadaModelo> listaConsulta = null;
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
                tabla.Rows.Add(c.idConsultaPrivada, c.idMensaje, c.ciDocente, c.ciAlumno, c.titulo, c.cpStatus, c.cpFechaHora, c.ciDestinatario);
            }
            return tabla;
        }

        public static List<List<string>> getMsgsFromConsulta(int idConsultaPrivada, string ciAlumno, string ciDocente)
        {
            MensajePrivadoModelo mpm = new MensajePrivadoModelo(Session.type);
            List<List<string>> mensajesDeConsulta = new List<List<string>>();
            int x = 0;
            foreach (MensajePrivadoModelo m in mpm.mensajesDeConsulta(idConsultaPrivada, ciAlumno, ciDocente, Session.type))
            {
                if(Session.type==0 || Session.type==1)
                    m.updateStatus();
                mensajesDeConsulta.Add(m.toStringList());
               // Console.WriteLine(mensajesDeConsulta[x].ToString());
                x++;
            }
            return mensajesDeConsulta;
        }

        public static string obtenerMensaje(int idConsultaPrivada, string ciAlumno, string ciDocente)
        {
            MensajePrivadoModelo mpm = new MensajePrivadoModelo(Session.type);
            string contenidoMensaje = "";
            foreach (MensajePrivadoModelo m in mpm.mensajesDeConsulta(idConsultaPrivada, ciAlumno, ciDocente, Session.type))
            {
                contenidoMensaje = m.contenido;
               // Console.WriteLine($"\n{m.ToString()}\n");
            }

            return contenidoMensaje;
        }
    }
}
