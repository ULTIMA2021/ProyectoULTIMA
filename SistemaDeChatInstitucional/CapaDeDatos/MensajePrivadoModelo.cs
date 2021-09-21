﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace CapaDeDatos
{
    public class MensajePrivadoModelo : Modelo
    {
         int idCp_mensaje;
         int idConsultaPrivada;
         int ciDocente;
         int ciAlumno;
         public string contenido;
        //public attachment
         DateTime cp_mensajeFechaHora;
         public  string cp_mensajeStatus; //'recibido','leido'
         public int ciDestinatario;
         string errorType="MensajePrivado";

        public MensajePrivadoModelo(byte sessionType) : base(sessionType)
        {
        }

        public void enviarMensaje(int idCp_Mensaje, int idConsultaPrivada, int ciDocente, int ciAlumno, string contenido, string attachment,
                                   DateTime cp_mensajeFechaHora, string cp_mensajeStatus,int ciDestinatario)
        {
            this.comando.CommandText = "INSERT INTO CP_mensaje (idCp_Mensaje,idConsultaPrivada,ciDocente,ciAlumno, contenido, attachment, " +
                                        "cp_mensajeFechaHora, cp_mensajeStatus,ciDestinatario) VALUES(@idCp_Mensaje ,@idConsultaPrivada, " +
                                        "@ciDocente, @ciAlumno, @contenido, @attachment, @cp_mensajeFechaHora, @cp_mensajeStatus, @ciDestinatario);";
            this.comando.Parameters.AddWithValue("idCp_Mensaje", idCp_Mensaje);
            this.comando.Parameters.AddWithValue("idConsultaPrivada", idConsultaPrivada);
            this.comando.Parameters.AddWithValue("ciDocente", ciDocente);
            this.comando.Parameters.AddWithValue("ciAlumno", ciAlumno);
            this.comando.Parameters.AddWithValue("contenido", contenido);
            this.comando.Parameters.AddWithValue("attachment", attachment);
            this.comando.Parameters.AddWithValue("cp_mensajeFechaHora", cp_mensajeFechaHora);
            this.comando.Parameters.AddWithValue("cp_mensajeStatus", cp_mensajeStatus);
            this.comando.Parameters.AddWithValue("ciDestinatario", ciDestinatario);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        private List<MensajePrivadoModelo> cargarMensajePrivadoALista(MySqlCommand commando, byte sessionType)
        {
            lector = commando.ExecuteReader();
            List<MensajePrivadoModelo> listaCpm = new List<MensajePrivadoModelo>();
            while (lector.Read())
            {
                MensajePrivadoModelo cpm = new MensajePrivadoModelo(sessionType);
                cpm.idConsultaPrivada = Int32.Parse(lector[0].ToString());
                cpm.ciAlumno = Int32.Parse(lector[1].ToString());
                cpm.ciDocente = Int32.Parse(lector[2].ToString());
                cpm.idCp_mensaje = Int32.Parse(lector[3].ToString());
                cpm.contenido = lector[4].ToString();
                //cpm.attachment = null;
                cpm.cp_mensajeFechaHora = DateTime.Parse(lector[6].ToString());
                cpm.cp_mensajeStatus = lector[7].ToString();
                cpm.ciDestinatario = Int32.Parse(lector[8].ToString());
               // Console.WriteLine("mensajesDeConsulta:");
               // Console.WriteLine(cpm.ToString());
                listaCpm.Add(cpm);
            }
            lector.Close();
            return listaCpm;
        }
        public List<MensajePrivadoModelo> mensajesDeConsulta(byte sessionType) {
            this.comando.CommandText = "SELECT cpm.idConsultaPrivada, cpm.ciAlumno, cpm.ciDocente, cpm.idCp_mensaje, cpm.contenido, " +
                "cpm.attachment, cpm.cp_mensajeFechaHora, cpm.cp_mensajeStatus, cpm.ciDestinatario FROM CP_mensaje cpm; ";
            return cargarMensajePrivadoALista(this.comando, sessionType);
        }
        public List<MensajePrivadoModelo> mensajesDeConsulta(int ciAlumno, byte sessionType)
        {
            this.comando.CommandText = "SELECT cpm.idConsultaPrivada, cpm.ciAlumno, cpm.ciDocente, cpm.idCp_mensaje, cpm.contenido, " +
                "cpm.attachment, cpm.cp_mensajeFechaHora, cpm.cp_mensajeStatus,cpm.ciDestinatario FROM CP_mensaje cpm" +
                "WHERE cpm.ciAlumno=@ciAlumno; ";
            this.comando.Parameters.AddWithValue("ciAlumno", ciAlumno);
            return cargarMensajePrivadoALista(this.comando, sessionType);
        }
        public List<MensajePrivadoModelo> mensajesDeConsulta(string ciDocente, byte sessionType)
        {
            this.comando.CommandText = "SELECT cpm.idConsultaPrivada, cpm.ciAlumno, cpm.ciDocente, cpm.idCp_mensaje, cpm.contenido, " +
               "cpm.attachment, cpm.cp_mensajeFechaHora, cpm.cp_mensajeStatus FROM CP_mensaje cpm" +
               "WHERE cpm.ciDocente=@ciDocente; ";
            this.comando.Parameters.AddWithValue("ciDocente", ciDocente);
            return cargarMensajePrivadoALista(this.comando, sessionType);
        }
        public List<MensajePrivadoModelo> mensajesDeConsulta(int idConsultaPrivada, string ciAlumno, string ciDocente, byte sessionType)
        {
            this.comando.CommandText = "SELECT cpm.idConsultaPrivada, cpm.ciAlumno, cpm.ciDocente, cpm.idCp_mensaje, cpm.contenido, " +
               "cpm.attachment, cpm.cp_mensajeFechaHora, cpm.cp_mensajeStatus, cpm.ciDestinatario FROM CP_mensaje cpm " +
               "WHERE cpm.idConsultaPrivada=@idConsultaPrivada AND cpm.ciAlumno=@ciAlumno AND cpm.ciDocente=@ciDocente ; ";
            this.comando.Parameters.AddWithValue("idConsultaPrivada", idConsultaPrivada);
            this.comando.Parameters.AddWithValue("ciAlumno", ciAlumno);
            this.comando.Parameters.AddWithValue("ciDocente", ciDocente);
            return cargarMensajePrivadoALista(this.comando,  sessionType);
        }
        public string mensajesDeConsultaCount() {
            string count;
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT count(*) from CP_Mensaje WHERE cp_mensajeStatus = @cp_mensajeStatus AND ciDestinatario = @ciDestinatario; ";
            this.comando.Parameters.AddWithValue("@ciDestinatario", this.ciDestinatario);
            this.comando.Parameters.AddWithValue("@cp_mensajeStatus", this.cp_mensajeStatus);
            lector = comando.ExecuteReader();
            lector.Read();
            count = lector[0].ToString();
            lector.Close();
            return count;
        }
        public void updateStatus() {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "UPDATE CP_mensaje SET cp_mensajeStatus = 'leido' " +
                "WHERE ciDestinatario = @ciDestinatario AND " +
                "idConsultaPrivada = @idConsultaPrivada;";
            this.comando.Parameters.AddWithValue("@ciDestinatario", this.ciDestinatario);
            this.comando.Parameters.AddWithValue("@idConsultaPrivada", this.idConsultaPrivada);
            EjecutarQuery(this.comando, errorType);
        }
        public override string ToString()
        {
            return $"Consulta {this.idConsultaPrivada}\tAlumno {this.ciAlumno}\tDocente {this.ciDocente}\n" +
                $"mensaje Index {this.idCp_mensaje}\t contenido {this.contenido}\n" +
                $"mensajeFechaHora{this.cp_mensajeFechaHora}\n" +
                $"statusMensaje {this.cp_mensajeStatus}\t ciDestinatario {this.ciDestinatario}";
        }
        public List<string> toStringList()
        {
            List<string> mensaje = new List<string>();
            mensaje.Add(this.idConsultaPrivada.ToString());
            mensaje.Add(this.ciAlumno.ToString());
            mensaje.Add(this.ciDocente.ToString());
            mensaje.Add(this.idCp_mensaje.ToString());
            mensaje.Add(this.contenido);
            mensaje.Add(this.cp_mensajeFechaHora.ToString());
            mensaje.Add(this.cp_mensajeStatus);
            mensaje.Add(this.ciDestinatario.ToString());

            return mensaje;
        }

    }
}
