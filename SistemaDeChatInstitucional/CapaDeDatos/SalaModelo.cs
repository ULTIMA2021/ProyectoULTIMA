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
        public SalaModelo(byte sessionType) : base(sessionType)
        {
        }

        public void crearSala()
        {
            this.comando.CommandText = "INSERT INTO Sala (idGrupo, idMateria, docenteCi, anfitrion, resumen ,creacion,isDone) VALUES(" +
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
            this.comando.CommandText = "UPDATE Sala SET resumen=@resumen WHERE idSala=@idSala;";
            this.comando.Parameters.AddWithValue("@resumen",resumen);
            this.comando.Parameters.AddWithValue("@idSala", idSala);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void salaFinalizada(int idSala)
        {
            this.comando.CommandText = "UPDATE Sala SET isDone=@isDone WHERE idSala=@idSala;";
            this.comando.Parameters.AddWithValue("@isDone", true);
            this.comando.Parameters.AddWithValue("@idSala", idSala);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }

        public List<SalaModelo> salaPorGrupoMateria(int idGrupo,int idMateria,byte sessionType)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT idSala,idGrupo,idMateria,docenteCi,anfitrion,resumen,isDone, creacion " +
                "FROM Sala " +
                "WHERE idGrupo=@idGrupo AND idMateria=@idMateria AND docenteCi is not null;";
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            return (cargarSalasAlist(this.comando,sessionType));
        }
        private List<SalaModelo> cargarSalasAlist(MySqlCommand command, byte sessionType)
        {
            lector = command.ExecuteReader();
            List<SalaModelo> salas = new List<SalaModelo>();
            while (lector.Read())
            {
                SalaModelo s = new SalaModelo(sessionType);
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

        public int salaPorMateriaCount(int idMateria, byte sessionType)
        {
            int count;
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT count(*) " +
                "FROM Sala " +
                "WHERE idMateria=@idMateria;";
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();

            lector = comando.ExecuteReader();
            lector.Read();
            count = int.Parse(lector[0].ToString());
            return count;
        }

    }
}
