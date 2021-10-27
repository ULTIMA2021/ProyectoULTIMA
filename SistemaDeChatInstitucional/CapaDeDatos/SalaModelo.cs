using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CapaDeDatos
{
    public class SalaModelo : Modelo
    {
        public int idSala;
        public int idGrupo;
        public int idMateria;
        public int docenteCi;
        public int anfitrion;
        public string resumen;
        public bool isDone;
        public DateTime creacion;
        string errorType = "Sala";
        public SalaModelo(byte sessionType) : base(sessionType){}
        public SalaModelo() : base() { }

        public void crearSala()
        {
            this.comando.CommandText = "INSERT INTO sala (idGrupo, idMateria, docenteCi, anfitrion, resumen ,creacion,isDone) VALUES(" +
                                    "@idGrupo,@idMateria,@docenteCi,@anfitrion,@resumen,@creacion,@isDone);";
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Parameters.AddWithValue("@docenteCi", docenteCi);
            this.comando.Parameters.AddWithValue("@anfitrion", anfitrion);
            this.comando.Parameters.AddWithValue("@resumen", resumen);
            this.comando.Parameters.AddWithValue("@creacion", creacion);
            this.comando.Parameters.AddWithValue("@isDone", false);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void salaResumenUpdate()
        {
            this.comando.CommandText = "UPDATE sala SET resumen=@resumen WHERE idSala=@idSala;";
            this.comando.Parameters.AddWithValue("@resumen",resumen);
            this.comando.Parameters.AddWithValue("@idSala", idSala);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void updateEstado(int idSala, bool estado)
        {
            this.comando.CommandText = "UPDATE sala SET isDone=@isDone WHERE idSala=@idSala;";
            this.comando.Parameters.AddWithValue("@isDone", estado);
            this.comando.Parameters.AddWithValue("@idSala", idSala);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void updateEstado(string idGrupo, bool estado)
        {
            this.comando.CommandText = "UPDATE sala SET isDone=@isDone WHERE idGrupo=@idGrupo;";
            this.comando.Parameters.AddWithValue("@isDone", estado);
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void updateEstado(string idMateria, bool estado, byte dummy)
        {
            this.comando.CommandText = "UPDATE sala SET isDone=@isDone WHERE idMateria=@idMateria;";
            this.comando.Parameters.AddWithValue("@isDone", estado);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void updateEstado(string idMateria, string idGrupo, bool estado)
        {
            this.comando.CommandText = "UPDATE sala SET isDone=@isDone WHERE idGrupo=@idGrupo AND idMateria=@idMateria;";
            this.comando.Parameters.AddWithValue("@isDone", estado);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }


        //o las salas abiertas o las cerradas
        public List<SalaModelo> salaPorGrupoMateria(int idGrupo,int idMateria, bool isDone)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT idSala,idGrupo,idMateria,docenteCi,anfitrion,resumen,isDone, creacion " +
                "FROM sala " +
                "WHERE idGrupo=@idGrupo AND idMateria=@idMateria AND isDone=@isDone AND docenteCi IS NOT NULL;";
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Parameters.AddWithValue("@isDone", isDone);
            this.comando.Prepare();
            return (cargarSalasAlist(this.comando));
        }
        public List<SalaModelo> cargarSalasAlist(MySqlCommand command)
        {
            lector = command.ExecuteReader();
            List<SalaModelo> salas = new List<SalaModelo>();
            while (lector.Read())
            {
                SalaModelo s = new SalaModelo();
                s.idSala = int.Parse(lector[0].ToString());
                s.idGrupo = int.Parse(lector[1].ToString()); 
                s.idMateria = int.Parse(lector[2].ToString());
                s.docenteCi = int.Parse(lector[3].ToString());
                s.anfitrion = int.Parse(lector[4].ToString());
                s.resumen = lector[5].ToString();
                s.isDone = bool.Parse(lector[6].ToString());
                s.creacion = DateTime.Parse(lector[7].ToString()); 
                salas.Add(s);
            }
            lector.Close();
            return salas;
        }

        public int salaPorMateriaCount(int idMateria,bool isDone)
        {
            int count;
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT count(*) " +
                "FROM sala " +
                "WHERE idMateria=@idMateria AND isDone=@isDone;";
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Parameters.AddWithValue("@isDone", isDone);
            this.comando.Prepare();

            lector = comando.ExecuteReader();
            lector.Read();
            count = int.Parse(lector[0].ToString());
            return count;
        }

    }
}
