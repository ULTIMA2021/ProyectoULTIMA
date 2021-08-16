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
        int idSala;
        int idGrupo;
        int idMateria;
        int docenteCi;
        int anfitrion;
        string resumen;
        bool isDone;
        DateTime creacion;
        string errorType = "Sala";
        public SalaModelo(byte sessionType) : base(sessionType)
        {
        }

        public void crearSala()
        {
            this.comando.CommandText = "INSERT INTO Sala (idGrupo, idMateria, docenteCi, anfitrion,creacion) VALUES(" +
                                    "@idGrupo,@idMateria,@docenteCi,@anfitrion,@creacion);";
            this.comando.Parameters.AddWithValue("idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("idMateria", idMateria);
            this.comando.Parameters.AddWithValue("docenteCi", docenteCi);
            this.comando.Parameters.AddWithValue("anfitrion", anfitrion);
            this.comando.Parameters.AddWithValue("creacion", creacion);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void salaResumenUpdate()
        {
            this.comando.CommandText = "UPDATE Sala SET resumen=@resumen WHERE idSala=@idSala;";
            this.comando.Parameters.AddWithValue("resumen",resumen);
            this.comando.Parameters.AddWithValue("idSala", idSala);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void salaFinalizada()
        {
            this.comando.CommandText = "UPDATE Sala SET isDone=@isDone WHERE idSala=@idSala;";
            this.comando.Parameters.AddWithValue("isDone", true);
            this.comando.Parameters.AddWithValue("idSala", idSala);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void salaPorGrupoMateria()
        {
            this.comando.CommandText = "SELECT idSala,idGrupo,idMateria,docenteCi,anfitrion,resumen,creacion FROM Sala WHERE idGrupo=@idGrupo AND idMateria=@idMateria;";
            this.comando.Parameters.AddWithValue("idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        private List<SalaModelo> cargarSalasAlist(MySqlCommand command, byte sessionType)
        {
            lector = command.ExecuteReader();
            List<SalaModelo> salas = new List<SalaModelo>();
            while (lector.Read())
            {
                SalaModelo s = new SalaModelo(sessionType);
                s.idSala = int.Parse(lector[0].ToString());
                salas.Add(s);
            }
            lector.Close();
            return salas;
        }

        public List<SalaModelo> getSala(byte sessionType)
        {
            this.comando.CommandText = "SELECT s.idSala,s.idGrupo,s.idMateria,s.docenteCi,s.anfitrion,s.resumen,s.isDone,s.creacion) " +
                "FROM Sala s, Alumno_tiene_Grupo ag, Docente_dicta_G_M dgm WHERE " +
                "s.idMateria=";
            return (cargarSalasAlist(this.comando, sessionType));
        }
    }
}
