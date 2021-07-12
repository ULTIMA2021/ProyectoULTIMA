using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using MySql.Data.MySqlClient;


namespace CapaDeDatos
{
    public class ConsultaPrivadaModelo : Modelo
    {

        public int idConsultaPrivada;
        public int ciDocente;
        public int ciAlumno;
        public string titulo;
        public string cpStatus;
        public DateTime cpFechaHora;

        

        public void EjecutarQuery(MySqlCommand comando)
        {
            comando.ExecuteNonQuery();
        }


        public void prepararMensaje(string docenteCi, string alumnoCi, string titulo, string cpStatus, DateTime cpFechaHora)
        {
            this.comando.CommandText = "INSERT INTO ConsultaPrivada ( docenteCi, alumnoCi, titulo, cpStatus, cpFechaHora) VALUES(" +
                                    " @docenteCi, @alumnoCi, @titulo, @cpStatus, @cpFechaHora);";

          //  this.comando.Parameters.AddWithValue("idConsultaPrivada", idConsultaPrivada);
            this.comando.Parameters.AddWithValue("docenteCi", docenteCi);
            this.comando.Parameters.AddWithValue("alumnoCi", alumnoCi);
            this.comando.Parameters.AddWithValue("titulo", titulo);
            this.comando.Parameters.AddWithValue("cpStatus", cpStatus);
            this.comando.Parameters.AddWithValue("cpFechaHora", cpFechaHora);

            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }


        public void enviarMensaje(int idConsultaPrivada, string contenido, string attachment,
                                   DateTime cp_mensajeFechaHora, string cp_mensajeStatus)
        {
            this.comando.CommandText = "INSERT INTO CP_mensaje (idConsultaPrivada, contenido, attachment, " +
                                        "cp_mensajeFechaHora, cp_mensajeStatus) VALUES(@idConsultaPrivada, " +
                                        "@contenido, @attachment, @cp_mensajeFechaHora, @cp_mensajeStatus);";


            this.comando.Parameters.AddWithValue("idConsultaPrivada", idConsultaPrivada);
            this.comando.Parameters.AddWithValue("contenido", contenido);
            this.comando.Parameters.AddWithValue("attachment", attachment);
            this.comando.Parameters.AddWithValue("cp_mensajeFechaHora", cp_mensajeFechaHora);
            this.comando.Parameters.AddWithValue("cp_mensajeStatus", cp_mensajeStatus);

            this.comando.Prepare();
            EjecutarQuery(this.comando);


        }


        public List<ConsultaPrivadaModelo> getConsultas(int ciDocente, int ciAlumno)  //intentando conseguir el id de consultaprivada para
        {                                                           // pasar por parametro en enviarmensaje
            List<ConsultaPrivadaModelo> consultas = new List<ConsultaPrivadaModelo>();

           

            foreach (ConsultaPrivadaModelo consulta in getConsultas())
            {
                if (ciAlumno == consulta.ciAlumno && ciDocente == consulta.ciDocente) {

                    lector = this.comando.ExecuteReader();

                   // lector.Read();

                    ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo();
                    cp.idConsultaPrivada = Int32.Parse(lector[0].ToString());
                    cp.ciDocente = Int32.Parse(lector[1].ToString());
                    cp.ciAlumno = Int32.Parse(lector[2].ToString());
                }
            }

            lector.Close();
            return consultas;
        }

        public int getIdConsultas(int ciDocente, int ciAlumno)
        {

            int index;
            List<ConsultaPrivadaModelo> consultas = getConsultas(ciDocente, ciAlumno);
            lector = this.comando.ExecuteReader();


            Console.WriteLine(consultas.Last()); 
            return consultas.Last().idConsultaPrivada;
            
        }


        public int getConsultas(int ciDocente)
        {


            return ciDocente;
        }

        public List<ConsultaPrivadaModelo> getConsultas()
        {
            List<ConsultaPrivadaModelo> consultas = new List<ConsultaPrivadaModelo>();
            

            this.comando.CommandText = "SELECT idConsultaPrivada, docenteCi, alumnoCi, titulo, cpStatus, cpFechaHora FROM ConsultaPrivada;";

            lector = this.comando.ExecuteReader();

            while (lector.Read())
            {
                ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo();
              //  Console.WriteLine("ci: " + lector[0].ToString() + "    " + lector[1].ToString() + "    " + lector[2].ToString() + "    " + lector[3].ToString());
                cp.idConsultaPrivada = Int32.Parse(lector[0].ToString());
                cp.ciDocente = Int32.Parse(lector[1].ToString());
                cp.ciAlumno = Int32.Parse(lector[2].ToString());
                cp.titulo = lector[3].ToString();
                cp.cpStatus = lector[4].ToString();
                cp.cpFechaHora = DateTime.Parse(lector[5].ToString());

                consultas.Add(cp);
            }

                lector.Close();
                return consultas;
        }



    }
}
