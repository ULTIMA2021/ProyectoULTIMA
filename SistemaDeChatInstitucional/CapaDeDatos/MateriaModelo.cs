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

        public MateriaModelo(byte sessionType) : base(sessionType){}
        public MateriaModelo() : base(){}

        public void crearMateriaNueva()
        {
            this.comando.CommandText = "INSERT INTO materia (nombreMateria) VALUES(@nombreMateria);";
            this.comando.Parameters.AddWithValue("@nombreMateria", this.nombreMateria);
            EjecutarQuery(this.comando, errorType);
        }
        public void actualizarNombreDeMateria(string nombreMateria, string idMateria)
        {
            this.comando.CommandText = "UPDATE materia SET nombreMateria = @nombreMateria WHERE idMateria = @idMateria;";
            this.comando.Parameters.AddWithValue("@nombreMateria", nombreMateria);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(comando, errorType);
        }
        public void actualizarEstadoDeMateria(bool isDeleted, string idMateria)
        {
            this.comando.CommandText = "UPDATE materia SET isDeleted = @isDeleted WHERE idMateria = @idMateria;";
            this.comando.Parameters.AddWithValue("@isDeleted", isDeleted);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(comando, errorType);
        }

        public void borrarMateria(string idMateria)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "DELETE FROM materia WHERE idMateria = @idMateria;";
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }

        private List<MateriaModelo> cargarMateriaALista(MySqlCommand commando)
        {
            lector = commando.ExecuteReader();
            List<MateriaModelo> listaM = new List<MateriaModelo>();
            while (lector.Read())
            {
                MateriaModelo m = new MateriaModelo();
                m.idMateria = int.Parse(lector[0].ToString());
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

        public List<MateriaModelo> getMateria()
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT idMateria,nombreMateria FROM materia WHERE isDeleted = FALSE ORDER BY nombreMateria ASC;";
            return cargarMateriaALista(this.comando);
        }

        public string getMateria(string nombreMateria)
        {
            string idMateria;
            this.comando.CommandText = "SELECT idMateria, nombreMateria FROM materia WHERE nombreMateria=@nombreMateria ORDER BY nombreMateria ASC;";
            this.comando.Parameters.AddWithValue("@nombreMateria", nombreMateria);
            lector = comando.ExecuteReader();
            lector.Read();
            idMateria = lector[0].ToString();
            lector.Close();
            return idMateria;
        }

        public List<MateriaModelo> getGrupoTieneMateria(string idGrupo)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT gm.idMateria, m.nombreMateria " +
                "FROM grupo_tiene_materia gm, materia m " +
                "WHERE gm.idGrupo = @idGrupo AND gm.idMateria = m.idMateria; ";
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            return (cargarMateriaALista(this.comando));
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
