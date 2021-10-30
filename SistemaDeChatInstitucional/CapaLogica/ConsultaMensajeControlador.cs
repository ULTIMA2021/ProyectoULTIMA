using System;
using System.Collections.Generic;
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
            string titulo, string cpStatus, DateTime cpFechaHora) => new ConsultaPrivadaModelo(Session.type).crearConsultaPrivada(idConsultaPrivada, docenteCi, alumnoCi, titulo, cpStatus, cpFechaHora);


        public static void enviarMensaje(int idCp_Mensaje, int idConsultaPrivada, int ciDocente, int ciAlumno, string contenido, string attachment,
                                   DateTime cp_mensajeFechaHora, string cp_mensajeStatus, int ciDestinatario) 
            => new MensajePrivadoModelo(Session.type).enviarMensaje(idCp_Mensaje, idConsultaPrivada, ciDocente, ciAlumno, contenido, attachment, cp_mensajeFechaHora, cp_mensajeStatus, ciDestinatario);

        public static int GetidConsultaPrivada(int ciDocente, int ciAlumno)
        {
            ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo(Session.type);
            int idConsultaPrivada = cp.getIdConsultas(ciDocente, ciAlumno);
            //Console.WriteLine($"EL ID DE LA CONSULTA PREVIA ES: {idConsultaPrivada}");
            idConsultaPrivada++;
           // Console.WriteLine($"EL ID DE LA CONSULTA NUEVA ES: {idConsultaPrivada}");
            return idConsultaPrivada;
        }

        // metodo original
        public static DataTable ConsultasPrivada(string ci, byte type)
        {
            ConsultaPrivadaModelo consulta = new ConsultaPrivadaModelo(Session.type);
            List<ConsultaPrivadaModelo> listaConsulta = new List<ConsultaPrivadaModelo>();
            if (type == 0)
                listaConsulta = consulta.getConsultas(ci);
            else if (type == 1)
                listaConsulta = consulta.getConsultas(int.Parse(ci));
            DataTable tabla = new DataTable();
            tabla.Columns.Add("idConsultaPrivada");
            tabla.Columns.Add("idMensaje");
            tabla.Columns.Add("ciDocente");
            tabla.Columns.Add("Alumno");
            tabla.Columns.Add("Tema");
            tabla.Columns.Add("Status");
            tabla.Columns.Add("Fecha ultimo mensaje");
            tabla.Columns.Add("Destinatario");
            foreach (ConsultaPrivadaModelo c in listaConsulta)
            {
                tabla.Rows.Add(c.idConsultaPrivada, c.idMensaje, c.ciDocente, c.ciAlumno, c.titulo, c.cpStatus, c.cpFechaHora, c.ciDestinatario);
            }
            return tabla;
        }

        public static List<List<string>> getMsgsFromConsulta(int idConsultaPrivada, string ciAlumno, string ciDocente)
        {
            List<List<string>> mensajesDeConsulta = new List<List<string>>();
            foreach (MensajePrivadoModelo m in new MensajePrivadoModelo(Session.type).mensajesDeConsulta(idConsultaPrivada, ciAlumno, ciDocente))
            {
                
                if (Session.type == 0 || Session.type == 1)
                    new MensajePrivadoModelo(Session.type).updateStatus(Session.cedula, idConsultaPrivada.ToString());
                mensajesDeConsulta.Add(m.toStringList());
            }
            return mensajesDeConsulta;
        }

        public static string obtenerMensaje(int idConsultaPrivada, string ciAlumno, string ciDocente)
        {
            MensajePrivadoModelo mpm = new MensajePrivadoModelo(Session.type);
            string contenidoMensaje = "";
            foreach (MensajePrivadoModelo m in mpm.mensajesDeConsulta(idConsultaPrivada, ciAlumno, ciDocente))
            {
                contenidoMensaje = m.contenido;
               // Console.WriteLine($"\n{m.ToString()}\n");
            }

            return contenidoMensaje;
        }
    }
}
