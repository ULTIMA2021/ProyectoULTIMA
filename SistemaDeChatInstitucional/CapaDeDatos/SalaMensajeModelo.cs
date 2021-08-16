using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CapaDeDatos
{
    public class SalaMensajeModelo : Modelo
    {
        int idSala;
        int idMensaje;
        int autorCi;
        string contenido;
        DateTime fechaHora;
        string errorType = "SalaMensaje";

        public SalaMensajeModelo(byte sessionType) : base(sessionType) { }

        private List<SalaMensajeModelo> cargarMensajesALista(MySqlCommand commando, byte sessionType)
        {
            lector = commando.ExecuteReader();
            List<SalaMensajeModelo> listaMensajes = new List<SalaMensajeModelo>();
            while (lector.Read())
            {
                SalaMensajeModelo smsg = new SalaMensajeModelo(sessionType);
                smsg.idSala = int.Parse(lector[0].ToString());
                smsg.idMensaje = int.Parse(lector[1].ToString());
                smsg.autorCi = int.Parse(lector[2].ToString());
                smsg.contenido = lector[3].ToString();
                smsg.fechaHora = DateTime.Parse(lector[4].ToString());

                listaMensajes.Add(smsg);
            }
            lector.Close();
            return listaMensajes;
        }

        public void enviarMensaje() {
            this.comando.CommandText = "INSERT INTO Sala_Mensaje (idSala,autorCi, contenido, fechaHora) " +
                "VALUES (@idSala,@autorCi,@contenido, @fechaHora;)";
            this.comando.Parameters.AddWithValue("@idSala",idSala);
            this.comando.Parameters.AddWithValue("@autorCi", autorCi);
            this.comando.Parameters.AddWithValue("@contenido", contenido);
            this.comando.Parameters.AddWithValue("@fechaHora", fechaHora);
            this.comando.Prepare();
            EjecutarQuery(this.comando,errorType);
        }

        public List<SalaMensajeModelo> getMensajes(byte sessionType)
        {
            this.comando.CommandText = "SELECT (idSala,ci,isConnected) FROM Sala_members sm, Alumno_Tiene_Grupo ag, Docenete_dicta_G_M dgm WHERE " +
                "sm.idSala=@idSala AND (ag.alumnoCi=sm.ci OR dgm.docenteCi=sm.ci);";
            return (cargarMensajesALista(this.comando, sessionType));
        }

        public List<string> toStringList()
        {
            List<string> mensaje = new List<string>();
            mensaje.Add(this.idSala.ToString());
            mensaje.Add(this.idMensaje.ToString());
            mensaje.Add(this.autorCi.ToString());
            mensaje.Add(this.contenido);
            mensaje.Add(this.fechaHora.ToString());
            return mensaje;
        }
    }
}