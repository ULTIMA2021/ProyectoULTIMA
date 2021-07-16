﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace CapaDeDatos
{
    public class MateriaModelo: Modelo
    {

        int idMateria;
        string nombreMateria;
        public void crearMateriaNueva(string nombreMateria)
        {
            this.comando.CommandText = "INSERT INTO Materia (nombreMateria) VALUES(@nombreMateria);";
            this.comando.Parameters.AddWithValue("nomberMateria", nombreMateria);
            EjecutarQuery(this.comando);
        }
        private List<MateriaModelo> cargarMateriaALista(MySqlCommand commando)
        {
            lector = commando.ExecuteReader();
            List<MateriaModelo> listaM = new List<MateriaModelo>();
            while (lector.Read())
            {
                MateriaModelo m = new MateriaModelo();
                m.idMateria = Int32.Parse(lector[0].ToString());
                m.nombreMateria = lector[1].ToString();
                listaM.Add(m);
            }
            lector.Close();
            return listaM;
        }

        public List<MateriaModelo> getMateria()
        {
            this.comando.CommandText = "SELECT idGrupo,nombreGrupo FROM Grupo;";
            return cargarMateriaALista(this.comando);
        }


    }
}
