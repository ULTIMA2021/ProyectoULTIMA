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
        private List<MateriaModelo> cargarMateriaALista(MySqlCommand commando, byte sessionType)
        {
            lector = commando.ExecuteReader();
            List<MateriaModelo> listaM = new List<MateriaModelo>();
            while (lector.Read())
            {
                MateriaModelo m = new MateriaModelo(sessionType);
                m.idMateria = Int32.Parse(lector[0].ToString());
                m.nombreMateria = lector[1].ToString();
                listaM.Add(m);
            }
            lector.Close();
            return listaM;
        }

        public List<MateriaModelo> getMateria(byte sessionType)
        {
            this.comando.CommandText = "SELECT idMateria,nombreMateria FROM Materia ORDER BY idMateria ASC;";
            return cargarMateriaALista(this.comando, sessionType);
        }

        public string getMateria(string nombreMateria, byte sessionType)
        {
            string idMateria;
            this.comando.CommandText = "SELECT idMateria, nombreMateria FROM Materia WHERE nombreMateria=@nombreMateria;";
            this.comando.Parameters.AddWithValue("@nombreMateria", nombreMateria);
            lector = comando.ExecuteReader();
            lector.Read();
            idMateria = lector[0].ToString();
            lector.Close();
            return idMateria;
        }

    }
}
