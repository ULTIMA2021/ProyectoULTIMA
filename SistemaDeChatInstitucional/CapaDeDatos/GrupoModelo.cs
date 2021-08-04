using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CapaDeDatos
{
    public class GrupoModelo : Modelo
    {
        public int idMateria;
        public int idGrupo;
        public int idOrientacion;
        public string nombreMateria;
        public string nombreGrupo;
        public string nombreOrientacion;

        public GrupoModelo(byte sessionType) : base(sessionType)
        {
        }

        public void crearGrupoNuevo(string nombreGrupo)
        {
            this.comando.CommandText = "INSERT INTO Grupo (nombreGrupo) VALUES(@nombreGrupo);";
            this.comando.Parameters.AddWithValue("nombreGrupo",nombreGrupo);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
        }
        public void nuevoIngresoAlumnoTieneGrupo(string alumnoCi, int idGrupo) {
            command = "INSERT INTO Alumno_Tiene_Grupo (alumnoCi,idGrupo) VALUES (@alumnoCi,@idGrupo);";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("alumnoCi", alumnoCi);
            this.comando.Parameters.AddWithValue("idGrupo", idGrupo);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
            this.comando.Parameters.Clear();
        }
        public void nuevoIngresoDocenteTieneGM(string docenteCi, int idGrupo,int idMateria) {
            command = "INSERT INTO Docente_Dicta_G_M (docenteCi,idGrupo,idMateria) VALUES (@docenteCi,@idGrupo,@idMateria);";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("docenteCi", docenteCi);
            this.comando.Parameters.AddWithValue("idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
            this.comando.Parameters.Clear();
        }
        public void actualizarDocenteTieneGM(string docenteCi, int idGrupo, int idMateria){
            command = "UPDATE Docente_Dicta_G_M SET docenteCi=@docenteCi WHERE idGrupo=@idGrupo AND idMateria=@idMateria;";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("docenteCi", docenteCi);
            this.comando.Parameters.AddWithValue("idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(this.comando);
            this.comando.Parameters.Clear();
        }

        private List<GrupoModelo> cargarGrupoALista(MySqlCommand commando, byte sessionType)
        {
            lector = commando.ExecuteReader();
            List<GrupoModelo> listaG = new List<GrupoModelo>();
            while (lector.Read())
            {
                GrupoModelo g = new GrupoModelo(sessionType);
                g.idGrupo = Int32.Parse(lector[0].ToString());
                g.nombreGrupo = lector[1].ToString();
                listaG.Add(g);
            }
            lector.Close();
            return listaG;
        }
        private List<GrupoModelo> cargarGrupoMateriaALista(MySqlCommand commando, byte sessionType)
        {
            lector = commando.ExecuteReader();
            List<GrupoModelo> listaGM = new List<GrupoModelo>();
            while (lector.Read())
            {
                GrupoModelo gm = new GrupoModelo( sessionType);
                gm.idGrupo = Int32.Parse(lector[0].ToString());
                gm.idMateria = Int32.Parse(lector[1].ToString());
                gm.nombreGrupo = lector[2].ToString();
                try { gm.nombreMateria = lector[3].ToString();
                }
                catch (Exception e){
                    Console.WriteLine("NO TE CAIGAS PUTA");
                }
                listaGM.Add(gm);
            }
            lector.Close();
            return listaGM;
        }
        
        public List<GrupoModelo> getGrupo(byte sessionType) {
            this.comando.CommandText = "SELECT idGrupo,nombreGrupo FROM Grupo;";
            return cargarGrupoALista(this.comando, sessionType);
        }
        public List<GrupoModelo> getGrupo(string idGrupo,byte sessionType)
        {
            this.comando.CommandText = "SELECT idGrupo,nombreGrupo FROM Grupo WHERE idGrupo=@idGrupo;";
            this.comando.Parameters.AddWithValue("idGrupo",idGrupo);
            return cargarGrupoALista(this.comando, sessionType);
        }

        //sin implementacion
        public List<GrupoModelo> getGrupoTieneMateria(byte sessionType) {
            this.comando.CommandText = "SELECT gm.idGrupo, gm.idMateria,g.nombreGrupo,m.nombreMateria " +
                "FROM Grupo_Tiene_Materia gm, grupo g, materia m " +
                "WHERE gm.idGrupo = g.idGrupo AND gm.idMateria = m.idMateria; ";
            return(cargarGrupoMateriaALista(this.comando, sessionType));
        }

        public override string ToString()
        {
            return $"{idGrupo}    {nombreGrupo}";
        }

        public List<GrupoModelo> getDocenteDictaGM(byte sessionType)
        {
            this.comando.CommandText = " SELECT  dgm.idGrupo, dgm.idMateria, g.nombregrupo, m.NombreMateria " +
                "FROM docente_dicta_G_M dgm, Grupo g, Materia m " +
                "WHERE dgm.docenteCi is null " +
                "AND dgm.idMateria = m.idMateria " +
                "AND g.idGrupo = dgm.idGrupo;";
            return cargarGrupoMateriaALista(this.comando, sessionType);
        }
    }
}
