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

        public void crearConsultaPrivada(int idConsultaPrivada,string docenteCi, string alumnoCi, string titulo, 
            string cpStatus, DateTime cpFechaHora)
        {
            this.comando.CommandText = "INSERT INTO ConsultaPrivada (idConsultaPrivada, docenteCi, alumnoCi, titulo, cpStatus, cpFechaHora) VALUES(" +
                                    "@idConsultaPrivada, @docenteCi, @alumnoCi, @titulo, @cpStatus, @cpFechaHora);";
            this.comando.Parameters.AddWithValue("idConsultaPrivada", idConsultaPrivada);
            this.comando.Parameters.AddWithValue("docenteCi", docenteCi);
            this.comando.Parameters.AddWithValue("alumnoCi", alumnoCi);
            this.comando.Parameters.AddWithValue("titulo", titulo);
            this.comando.Parameters.AddWithValue("cpStatus", cpStatus);
            this.comando.Parameters.AddWithValue("cpFechaHora", cpFechaHora);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }

        public List<ConsultaPrivadaModelo> getConsultas(int ciDocente, int ciAlumno)
        {                                              
            List<ConsultaPrivadaModelo> consultas = new List<ConsultaPrivadaModelo>();
            foreach (ConsultaPrivadaModelo consulta in getConsultas())
            {
                if (ciAlumno == consulta.ciAlumno && ciDocente == consulta.ciDocente) {
                    ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo();
                    cp.idConsultaPrivada = consulta.idConsultaPrivada;
                    cp.ciDocente = consulta.ciDocente;
                    cp.ciAlumno = consulta.ciAlumno;
                    consultas.Add(cp);
                    Console.WriteLine("getConsultas(int ciDocente, int ciAlumno)");
                    Console.WriteLine(cp.ToString());
                }
            }
            return consultas;
        }
        
        public List<ConsultaPrivadaModelo> getConsultas(int ciDocente)
        {
            List<ConsultaPrivadaModelo> consultas = new List<ConsultaPrivadaModelo>();
            foreach (ConsultaPrivadaModelo consulta in getConsultas())
            {
                if (ciDocente == consulta.ciDocente)
                {
                    ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo();
                    cp.idConsultaPrivada = consulta.idConsultaPrivada;
                    cp.ciDocente = consulta.ciDocente;
                    cp.ciAlumno = consulta.ciAlumno;
                    cp.cpFechaHora = consulta.cpFechaHora ;
                    cp.cpStatus = consulta.cpStatus;
                    cp.titulo = consulta.titulo;
                    consultas.Add(cp);
                    Console.WriteLine("getConsultas(int ciDocente, int ciAlumno)");
                    Console.WriteLine(cp.ToString());
                }
            }
            return consultas;
        }

        public List<ConsultaPrivadaModelo> getConsultas(string ciAlumno) {
            List<ConsultaPrivadaModelo> consultas = new List<ConsultaPrivadaModelo>();
            foreach (ConsultaPrivadaModelo consulta in getConsultas())
            {
                if (ciAlumno == consulta.ciAlumno.ToString())
                {
                    ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo();
                    cp.idConsultaPrivada = consulta.idConsultaPrivada;
                    cp.ciDocente = consulta.ciDocente;
                    cp.ciAlumno = consulta.ciAlumno;
                    cp.cpFechaHora = consulta.cpFechaHora;
                    cp.cpStatus = consulta.cpStatus;
                    cp.titulo = consulta.titulo;
                    consultas.Add(cp);
                    Console.WriteLine("getConsultas(int ciDocente, int ciAlumno)");
                    Console.WriteLine(cp.ToString());
                }
            }
            return consultas;
        }

        public List<ConsultaPrivadaModelo> getConsultas()
        {
            List<ConsultaPrivadaModelo> consultas = new List<ConsultaPrivadaModelo>();
            this.comando.CommandText = "SELECT idConsultaPrivada, docenteCi, alumnoCi, titulo, cpStatus, cpFechaHora FROM ConsultaPrivada;";
            lector = this.comando.ExecuteReader();
            while (lector.Read())
            {
                ConsultaPrivadaModelo cp = new ConsultaPrivadaModelo();
                cp.idConsultaPrivada = Int32.Parse(lector[0].ToString());
                cp.ciDocente = Int32.Parse(lector[1].ToString());
                cp.ciAlumno = Int32.Parse(lector[2].ToString());
                cp.titulo = lector[3].ToString();
                cp.cpStatus = lector[4].ToString();
                cp.cpFechaHora = DateTime.Parse(lector[5].ToString());
                Console.WriteLine("getConsultas()");
                Console.WriteLine(cp.ToString());
                consultas.Add(cp);
            }
                lector.Close();
                return consultas;
        }

        public int getIdConsultas(int ciDocente, int ciAlumno)
        {
            List<ConsultaPrivadaModelo> consultas = getConsultas(ciDocente, ciAlumno);
            int lastId = 0;
            try
            {
                lastId = consultas.Last().idConsultaPrivada;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("ERROR: " + e);
                return 0;
            }
            return lastId;
        }

        public override string ToString()
        {
            return $"idConsultaPrivada: {idConsultaPrivada} ciDocente: {ciDocente} ciAlumno: {ciAlumno}";
        }
    }
}
