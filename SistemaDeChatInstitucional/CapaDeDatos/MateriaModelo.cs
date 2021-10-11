using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace CapaDeDatos
{
    public class MateriaModelo: Modelo
    {

        public int idMateria;
        public string nombreMateria;
        public string isDeleted;
        public string errorType="Materia";

        public MateriaModelo(byte sessionType) : base(sessionType)
        {
        }

        public void crearMateriaNueva()
        {
            this.comando.CommandText = "INSERT INTO Materia (nombreMateria) VALUES(@nombreMateria);";
            this.comando.Parameters.AddWithValue("@nombreMateria", this.nombreMateria);
            EjecutarQuery(this.comando, errorType);
        }
        public void actualizarNombreDeMateria(string nombreMateria, string idMateria)
        {
            this.comando.CommandText = "UPDATE Materia SET nombreMateria = @nombreMateria WHERE idMateria = @idMateria;";
            this.comando.Parameters.AddWithValue("@nombreMateria", nombreMateria);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(comando, errorType);
        }
        public void actualizarEstadoDeMateria(bool isDeleted, string idMateria)
        {
            this.comando.CommandText = "UPDATE Materia SET isDeleted = @isDeleted WHERE idMateria = @idMateria;";
            this.comando.Parameters.AddWithValue("@isDeleted", isDeleted);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(comando, errorType);
        }

        public void borrarMateria(string idMateria)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "DELETE FROM Materia WHERE idMateria = @idMateria;";
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }

        private List<MateriaModelo> cargarMateriaALista(MySqlCommand commando, byte sessionType)
        {
            lector = commando.ExecuteReader();
            List<MateriaModelo> listaM = new List<MateriaModelo>();
            while (lector.Read())
            {
                MateriaModelo m = new MateriaModelo(sessionType);
                m.idMateria = Int32.Parse(lector[0].ToString());
                m.nombreMateria = lector[1].ToString();
                try
                {
                    m.isDeleted = lector[2].ToString();
                }
                catch (Exception)
                {
                    m.isDeleted = null;
                }
                listaM.Add(m);
            }
            lector.Close();
            return listaM;
        }

        public List<MateriaModelo> getMateria(byte sessionType)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT idMateria,nombreMateria FROM Materia WHERE isDeleted = false ORDER BY nombreMateria ASC;";
            return cargarMateriaALista(this.comando, sessionType);
        }

        public string getMateria(string nombreMateria, byte sessionType)
        {
            string idMateria;
            this.comando.CommandText = "SELECT idMateria, nombreMateria FROM Materia WHERE nombreMateria=@nombreMateria ORDER BY nombreMateria ASC;";
            this.comando.Parameters.AddWithValue("@nombreMateria", nombreMateria);
            lector = comando.ExecuteReader();
            lector.Read();
            idMateria = lector[0].ToString();
            lector.Close();
            return idMateria;
        }

        public List<MateriaModelo> getGrupoTieneMateria(string idGrupo, byte sessionType)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT gm.idMateria, m.nombreMateria " +
                "FROM Grupo_tiene_Materia gm, materia m " +
                "WHERE gm.idGrupo = @idGrupo AND gm.idMateria = m.idMateria; ";
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            return (cargarMateriaALista(this.comando, sessionType));
        }

        public string countSalaPorMateria()
        {
            string count = null;
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT count(*) from Sala WHERE idMateria = @idMateria;";
            this.comando.Parameters.AddWithValue("@idMateria", this.idMateria);
            lector = comando.ExecuteReader();
            lector.Read();
            count = lector[0].ToString();
            lector.Close();
            return count;

        }
    }
}
