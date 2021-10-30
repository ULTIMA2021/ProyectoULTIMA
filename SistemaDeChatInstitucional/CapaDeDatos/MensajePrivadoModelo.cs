using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace CapaDeDatos
{
    public class MensajePrivadoModelo : Modelo
    {
         public int idCp_mensaje;
         public int idConsultaPrivada;
         public int ciDocente;
         public int ciAlumno;
         public string contenido;
        //public attachment
         public DateTime cp_mensajeFechaHora;
         public  string cp_mensajeStatus; //'recibido','leido'
         public int ciDestinatario;
         string errorType="MensajePrivado";

        public MensajePrivadoModelo(byte sessionType) : base(sessionType)
        {
        }
        public MensajePrivadoModelo() : base()
        {
        }

        public void enviarMensaje(int idCp_Mensaje, int idConsultaPrivada, int ciDocente, int ciAlumno, string contenido, string attachment,
                                   DateTime cp_mensajeFechaHora, string cp_mensajeStatus,int ciDestinatario)
        {
            this.comando.CommandText = "INSERT INTO cp_mensaje (idCp_Mensaje,idConsultaPrivada,ciDocente,ciAlumno, contenido, attachment, " +
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
        private List<MensajePrivadoModelo> cargarMensajePrivadoALista(MySqlCommand commando)
        {
            lector = commando.ExecuteReader();
            List<MensajePrivadoModelo> listaCpm = new List<MensajePrivadoModelo>();
            while (lector.Read())
            {
                MensajePrivadoModelo cpm = new MensajePrivadoModelo();
                cpm.idConsultaPrivada = int.Parse(lector[0].ToString());
                cpm.ciAlumno = int.Parse(lector[1].ToString());
                cpm.ciDocente = int.Parse(lector[2].ToString());
                cpm.idCp_mensaje = int.Parse(lector[3].ToString());
                cpm.contenido = lector[4].ToString();
                //cpm.attachment = null;
                cpm.cp_mensajeFechaHora = DateTime.Parse(lector[6].ToString());
                cpm.cp_mensajeStatus = lector[7].ToString();
                cpm.ciDestinatario = int.Parse(lector[8].ToString());
               // Console.WriteLine("mensajesDeConsulta:");
               // Console.WriteLine(cpm.ToString());
                listaCpm.Add(cpm);
            }
            lector.Close();
            return listaCpm;
        }
        public List<MensajePrivadoModelo> mensajesDeConsulta() {
            this.comando.CommandText = "SELECT cpm.idConsultaPrivada, cpm.ciAlumno, cpm.ciDocente, cpm.idCp_mensaje, cpm.contenido, " +
                "cpm.attachment, cpm.cp_mensajeFechaHora, cpm.cp_mensajeStatus, cpm.ciDestinatario FROM cp_mensaje cpm; ";
            return cargarMensajePrivadoALista(this.comando);
        }
        public List<MensajePrivadoModelo> mensajesDeConsulta(int ciAlumno)
        {
            this.comando.CommandText = "SELECT cpm.idConsultaPrivada, cpm.ciAlumno, cpm.ciDocente, cpm.idCp_mensaje, cpm.contenido, " +
                "cpm.attachment, cpm.cp_mensajeFechaHora, cpm.cp_mensajeStatus,cpm.ciDestinatario FROM cp_mensaje cpm" +
                "WHERE cpm.ciAlumno=@ciAlumno; ";
            this.comando.Parameters.AddWithValue("ciAlumno", ciAlumno);
            return cargarMensajePrivadoALista(this.comando);
        }
        public List<MensajePrivadoModelo> mensajesDeConsulta(string ciDocente)
        {
            this.comando.CommandText = "SELECT cpm.idConsultaPrivada, cpm.ciAlumno, cpm.ciDocente, cpm.idCp_mensaje, cpm.contenido, " +
               "cpm.attachment, cpm.cp_mensajeFechaHora, cpm.cp_mensajeStatus FROM cp_mensaje cpm" +
               "WHERE cpm.ciDocente=@ciDocente; ";
            this.comando.Parameters.AddWithValue("ciDocente", ciDocente);
            return cargarMensajePrivadoALista(this.comando);
        }
        public List<MensajePrivadoModelo> mensajesDeConsulta(int idConsultaPrivada, string ciAlumno, string ciDocente)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT cpm.idConsultaPrivada, cpm.ciAlumno, cpm.ciDocente, cpm.idCp_mensaje, cpm.contenido, " +
               "cpm.attachment, cpm.cp_mensajeFechaHora, cpm.cp_mensajeStatus, cpm.ciDestinatario FROM cp_mensaje cpm " +
               "WHERE cpm.idConsultaPrivada=@idConsultaPrivada AND cpm.ciAlumno=@ciAlumno AND cpm.ciDocente=@ciDocente ; ";
            this.comando.Parameters.AddWithValue("idConsultaPrivada", idConsultaPrivada);
            this.comando.Parameters.AddWithValue("ciAlumno", ciAlumno);
            this.comando.Parameters.AddWithValue("ciDocente", ciDocente);
            return cargarMensajePrivadoALista(this.comando);
        }
        public string mensajesDeConsultaCount() {
            string count;
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT count(*) from cp_mensaje WHERE cp_mensajeStatus = @cp_mensajeStatus AND ciDestinatario = @ciDestinatario; ";
            this.comando.Parameters.AddWithValue("@ciDestinatario", this.ciDestinatario);
            this.comando.Parameters.AddWithValue("@cp_mensajeStatus", this.cp_mensajeStatus);
            lector = comando.ExecuteReader();
            lector.Read();
            count = lector[0].ToString();
            lector.Close();
            return count;
        }
        public void updateStatus(string ciDestinatario, string idConsultaPrivada) {
            this.comando.CommandText = "UPDATE cp_mensaje SET cp_mensajeStatus = 'leido' " +
                "WHERE ciDestinatario = @ciDestinatario " +
                "AND idConsultaPrivada = @idConsultaPrivada;";
            this.comando.Parameters.AddWithValue("@ciDestinatario", ciDestinatario);
            this.comando.Parameters.AddWithValue("@idConsultaPrivada", idConsultaPrivada);
            this.comando.Prepare();
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
