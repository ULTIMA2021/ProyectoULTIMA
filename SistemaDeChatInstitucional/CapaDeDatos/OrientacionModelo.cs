using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CapaDeDatos
{
    public class OrientacionModelo : Modelo
    {
        public int idOrientacion;
        public string nombreOrientacion;
        public string errorType="Orientacion";

        public OrientacionModelo(byte sessionType) : base(sessionType)
        {
        }

        public void crearMateriaNueva()
        {
            this.comando.CommandText = "INSERT INTO Orientacion (nombreOrientacion) VALUES(@nombreOrientacion);";
            this.comando.Parameters.AddWithValue("nombreOrientacion",this.nombreOrientacion);
            EjecutarQuery(this.comando, errorType);
        }

        private List<OrientacionModelo> cargarMateriaALista(MySqlCommand commando, byte sessionType)
        {
            lector = commando.ExecuteReader();
            List<OrientacionModelo> listaO = new List<OrientacionModelo>();
            while (lector.Read())
            {
                OrientacionModelo o = new OrientacionModelo( sessionType);
                o.idOrientacion = Int32.Parse(lector[0].ToString());
                o.nombreOrientacion = lector[1].ToString();
                listaO.Add(o);
            }
            lector.Close();
            return listaO;
        }

        public List<OrientacionModelo> getOrientacion(byte sessionType)
        {
            this.comando.CommandText = "SELECT idOrientacion, nombreOrientacion FROM Orientacion;";
            return cargarMateriaALista(this.comando, sessionType);
        }

        public string getOrientacion(string nombreOrientacion, byte sessionType)
        {
            string idOrientacion;
            this.comando.CommandText = "SELECT idOrientacion FROM Orientacion WHERE nombreOrientacion=@nombreOrientacion;";
            this.comando.Parameters.AddWithValue("@nombreOrientacion", nombreOrientacion);
            lector = comando.ExecuteReader();
            lector.Read();
            idOrientacion = lector[0].ToString();
            lector.Close();
            return idOrientacion;
        }
    }
}
