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

        public OrientacionModelo(byte sessionType) : base(sessionType){}
        public OrientacionModelo() : base() { }

        public void crearMateriaNueva()
        {
            this.comando.CommandText = "INSERT INTO orientacion (nombreOrientacion) VALUES(@nombreOrientacion);";
            this.comando.Parameters.AddWithValue("nombreOrientacion",this.nombreOrientacion);
            EjecutarQuery(this.comando, errorType);
        }
        public void borrarOrientacion(string idOrientacion)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "DELETE FROM orientacion WHERE idOrientacion=@idOrientacion;";
            this.comando.Parameters.AddWithValue("@idOrientacion",idOrientacion);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }
        public void actualizarNombreDeOrientacion(string nombreOrientacion, string idOrientacion)
        {
            this.comando.CommandText = "UPDATE orientacion SET nombreOrientacion = @nombreOrientacion WHERE idOrientacion = @idOrientacion;";
            this.comando.Parameters.AddWithValue("@nombreOrientacion", nombreOrientacion);
            this.comando.Parameters.AddWithValue("@idOrientacion", idOrientacion);
            EjecutarQuery(comando, errorType);
        }
        private List<OrientacionModelo> cargarOrientacionAlista(MySqlCommand commando)
        {
            lector = commando.ExecuteReader();
            List<OrientacionModelo> listaO = new List<OrientacionModelo>();
            while (lector.Read())
            {
                OrientacionModelo o = new OrientacionModelo();
                o.idOrientacion = int.Parse(lector[0].ToString());
                o.nombreOrientacion = lector[1].ToString();
                listaO.Add(o);
            }
            lector.Close();
            return listaO;
        }

        public List<OrientacionModelo> getOrientacion()
        {
            this.comando.CommandText = "SELECT idOrientacion, nombreOrientacion FROM orientacion;";
            return cargarOrientacionAlista(this.comando);
        }

        public string getOrientacion(string nombreOrientacion)
        {
            string idOrientacion;
            this.comando.CommandText = "SELECT idOrientacion FROM orientacion WHERE nombreOrientacion=@nombreOrientacion;";
            this.comando.Parameters.AddWithValue("@nombreOrientacion", nombreOrientacion);
            lector = comando.ExecuteReader();
            lector.Read();
            idOrientacion = lector[0].ToString();
            lector.Close();
            return idOrientacion;
        }
    }
}
