using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string cp_mensajeStatus; //'recibido','leido'

        public void enviarMensaje(int idCp_Mensaje, int idConsultaPrivada, int ciDocente, int ciAlumno, string contenido, string attachment,
                                   DateTime cp_mensajeFechaHora, string cp_mensajeStatus)
        {
            this.comando.CommandText = "INSERT INTO CP_mensaje (idCp_Mensaje,idConsultaPrivada,ciDocente,ciAlumno, contenido, attachment, " +
                                        "cp_mensajeFechaHora, cp_mensajeStatus) VALUES(@idCp_Mensaje ,@idConsultaPrivada, " +
                                        "@ciDocente, @ciAlumno, @contenido, @attachment, @cp_mensajeFechaHora, @cp_mensajeStatus);";
            this.comando.Parameters.AddWithValue("idCp_Mensaje", idCp_Mensaje);
            this.comando.Parameters.AddWithValue("idConsultaPrivada", idConsultaPrivada);
            this.comando.Parameters.AddWithValue("ciDocente", ciDocente);
            this.comando.Parameters.AddWithValue("ciAlumno", ciAlumno);
            this.comando.Parameters.AddWithValue("contenido", contenido);
            this.comando.Parameters.AddWithValue("attachment", attachment);
            this.comando.Parameters.AddWithValue("cp_mensajeFechaHora", cp_mensajeFechaHora);
            this.comando.Parameters.AddWithValue("cp_mensajeStatus", cp_mensajeStatus);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }
       
        private List<MensajePrivadoModelo> cargarMensajePrivadoALista(MySqlCommand commando)
        {
            lector = commando.ExecuteReader();
            List<MensajePrivadoModelo> listaCpm = new List<MensajePrivadoModelo>();
            while (lector.Read())
            {
                MensajePrivadoModelo cpm = new MensajePrivadoModelo();
                cpm.idConsultaPrivada = Int32.Parse(lector[0].ToString());
                cpm.ciAlumno = Int32.Parse(lector[1].ToString());
                cpm.ciDocente = Int32.Parse(lector[2].ToString());
                cpm.idCp_mensaje = Int32.Parse(lector[3].ToString());
                cpm.contenido = lector[4].ToString();
                //cpm.attachment = null;
                cpm.cp_mensajeFechaHora = DateTime.Parse(lector[6].ToString());
                cpm.cp_mensajeStatus = lector[6].ToString();
                Console.WriteLine("mensajesDeConsulta:");
                Console.WriteLine(cpm.ToString());
                listaCpm.Add(cpm);
            }
            lector.Close();
            return listaCpm;
        }
        public List<MensajePrivadoModelo> mensajesDeConsulta() {
            List<MensajePrivadoModelo> listaCpm = new List<MensajePrivadoModelo>();
            this.comando.CommandText = "SELECT cpm.idConsultaPrivada, cpm.ciAlumno, cpm.ciDocente, cpm.idCp_mensaje, cpm.contenido, " +
                "cpm.attachment, cpm.cp_mensajeFechaHora, cpm.cp_mensajeStatus FROM CP_Mensaje cpm; ";
            return cargarMensajePrivadoALista(this.comando);
        }
        public List<MensajePrivadoModelo> mensajesDeConsulta(int ciAlumno)
        {
            List<MensajePrivadoModelo> listaCpm = new List<MensajePrivadoModelo>();
            this.comando.CommandText = "SELECT cpm.idConsultaPrivada, cpm.ciAlumno, cpm.ciDocente, cpm.idCp_mensaje, cpm.contenido, " +
                "cpm.attachment, cpm.cp_mensajeFechaHora, cpm.cp_mensajeStatus FROM CP_Mensaje cpm" +
                "WHERE cpm.ciAlumno=@ciAlumno; ";
            this.comando.Parameters.AddWithValue("ciAlumno", ciAlumno);
            return cargarMensajePrivadoALista(this.comando);
        }
        public List<MensajePrivadoModelo> mensajesDeConsulta(string ciDocente)
        {
            this.comando.CommandText = "SELECT cpm.idConsultaPrivada, cpm.ciAlumno, cpm.ciDocente, cpm.idCp_mensaje, cpm.contenido, " +
               "cpm.attachment, cpm.cp_mensajeFechaHora, cpm.cp_mensajeStatus FROM CP_Mensaje cpm" +
               "WHERE cpm.ciDocente=@ciDocente; ";
            this.comando.Parameters.AddWithValue("ciDocente", ciDocente);
            return cargarMensajePrivadoALista(this.comando);
        }
    }
}
