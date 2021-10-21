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
        public int idSala;
        public int idMensaje;
        public  int autorCi;
        public string contenido;
        public DateTime fechaHora;
        public string errorType = "SalaMensaje";

        public SalaMensajeModelo(byte sessionType) : base(sessionType) { }
        public SalaMensajeModelo() : base() { }


        private List<SalaMensajeModelo> cargarMensajesALista(MySqlCommand commando)
        {
            lector = commando.ExecuteReader();
            List<SalaMensajeModelo> listaMensajes = new List<SalaMensajeModelo>();
            while (lector.Read())
            {
                SalaMensajeModelo smsg = new SalaMensajeModelo();
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
            this.comando.CommandText = "INSERT INTO sala_mensaje (idSala,autorCi, contenido, fechaHora) " +
                "VALUES (@idSala,@autorCi,@contenido, @fechaHora);";
            this.comando.Parameters.AddWithValue("@idSala",idSala);
            this.comando.Parameters.AddWithValue("@autorCi", autorCi);
            this.comando.Parameters.AddWithValue("@contenido", contenido);
            this.comando.Parameters.AddWithValue("@fechaHora", fechaHora);
            this.comando.Prepare();
            EjecutarQuery(this.comando,errorType);

        }

        public List<SalaMensajeModelo> getMensajesDeSala(int idSala) {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT sm.idSala, sm.idMensaje, sm.autorCi, sm.contenido, sm.fechaHora " +
                "FROM sala_mensaje sm " +
                "WHERE sm.idSala = @idSala " +
                "ORDER BY sm.fechaHora;";
            this.comando.Parameters.AddWithValue("@idSala", idSala);
            return cargarMensajesALista(this.comando);
        }

        public int getMensajesDeSalaCount(int idSala)
        {
            int count;
            this.comando.Parameters.Clear();
            this.comando.CommandText = " SELECT count(*) FROM sala_mensaje sm where sm.idSala = @idSala;";
            this.comando.Parameters.AddWithValue("@idSala", idSala);
            lector = comando.ExecuteReader();
            lector.Read();
            count  = int.Parse(lector[0].ToString());
            lector.Close();
            return count;
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