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
        int idOrientacion;
        string nombreOrientacion;
        public void crearMateriaNueva(string nombreOrientacion)
        {
            this.comando.CommandText = "INSERT INTO Orientacion (nombreMateria) VALUES(@nombreOrientacion);";
            this.comando.Parameters.AddWithValue("nombreOrientacion", nombreOrientacion);
            EjecutarQuery(this.comando);
        }
        private List<OrientacionModelo> cargarMateriaALista(MySqlCommand commando)
        {
            lector = commando.ExecuteReader();
            List<OrientacionModelo> listaO = new List<OrientacionModelo>();
            while (lector.Read())
            {
                OrientacionModelo o = new OrientacionModelo();
                o.idOrientacion = Int32.Parse(lector[0].ToString());
                o.nombreOrientacion = lector[1].ToString();
                listaO.Add(o);
            }
            lector.Close();
            return listaO;
        }
        public List<OrientacionModelo> getOrientacion()
        {
            this.comando.CommandText = "SELECT idGrupo,nombreGrupo FROM Grupo;";
            return cargarMateriaALista(this.comando);
        }
    }
}
