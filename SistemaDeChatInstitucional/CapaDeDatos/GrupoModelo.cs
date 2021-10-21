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
        public int ci;
        public string errorType = "Grupo";
        public string isDeleted;

        public GrupoModelo(byte sessionType) : base(sessionType){}
        public GrupoModelo() : base() { }

        public void crearGrupoNuevo()
        {
            this.comando.CommandText = "INSERT INTO grupo (nombreGrupo) VALUES(@nombreGrupo);";
            this.comando.Parameters.AddWithValue("nombreGrupo", this.nombreGrupo);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void actualizarNombreDeGrupo(string nombreGrupo, string idGrupo)
        {
            this.comando.CommandText = "UPDATE grupo SET nombreGrupo = @nombreGrupo WHERE idGrupo = @idGrupo;";
            this.comando.Parameters.AddWithValue("@nombreGrupo",nombreGrupo );
            this.comando.Parameters.AddWithValue("@idGrupo",idGrupo);
            EjecutarQuery(comando,errorType);
        }
        public void actualizarEstadoDeGrupo(bool isDeleted, string idGrupo)
        {
            this.comando.CommandText = "UPDATE grupo SET isDeleted = @isDeleted WHERE idGrupo = @idGrupo;";
            this.comando.Parameters.AddWithValue("@isDeleted", isDeleted);
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            EjecutarQuery(comando, errorType);
        }
        public void sacarFilaGrupoTieneMateria()
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "DELETE FROM grupo_tiene_materia WHERE idMateria = @idMateria AND idGrupo = @idGrupo";
            this.comando.Parameters.AddWithValue("@idGrupo",this.idGrupo);
            this.comando.Parameters.AddWithValue("@idMateria",this.idMateria);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }
        public void sacarFilaOrientacionTieneGrupo()
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "DELETE FROM orientacion_tiene_grupo WHERE idOrientacion = @idOrientacion AND idGrupo = @idGrupo";
            this.comando.Parameters.AddWithValue("@idGrupo", this.idGrupo);
            this.comando.Parameters.AddWithValue("@idOrientacion", this.idOrientacion);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }
        public void borrarGrupo(string idGrupo)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "DELETE FROM grupo WHERE idGrupo = @idGrupo;";
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }


        public string countAlumnoTieneGrupo(string ci)
        {
            string count;
            command = "SELECT COUNT(*) FROM alumno_tiene_grupo WHERE alumnoCi=@ci;";
            this.comando.Parameters.AddWithValue("@ci", ci);
            lector = comando.ExecuteReader();
            lector.Read();
            count = lector[0].ToString();
            lector.Close();
            return count;
        }
        public string countDocenteDictaGrupo(string ci)
        {
            string count;
            command = "SELECT COUNT(*) FROM docente_dicta_g_m WHERE docenteCi = @ci;";
            this.comando.Parameters.AddWithValue("@ci", ci);
            lector = comando.ExecuteReader();
            lector.Read();
            count = lector[0].ToString();
            lector.Close();
            return count;
        }

        public void nuevoIngresoAlumnoTieneGrupo(string alumnoCi, int idGrupo) {
            this.comando.Parameters.Clear();
            command = "INSERT INTO alumno_tiene_grupo (alumnoCi,idGrupo) VALUES (@alumnoCi,@idGrupo);";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("alumnoCi", alumnoCi);
            this.comando.Parameters.AddWithValue("idGrupo", idGrupo);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
            this.comando.Parameters.Clear();
        }
        public void nuevoIngresoDocenteTieneGM(string docenteCi, int idGrupo, int idMateria) {
            command = "INSERT INTO docente_dicta_g_m (docenteCi,idGrupo,idMateria) VALUES (@docenteCi,@idGrupo,@idMateria);";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("docenteCi", docenteCi);
            this.comando.Parameters.AddWithValue("idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
            this.comando.Parameters.Clear();
        }
        public void actualizarDocenteTieneGM(string docenteCi, int idGrupo, int idMateria) {
            command = "UPDATE docente_dicta_g_m SET docenteCi=@docenteCi WHERE idGrupo=@idGrupo AND idMateria=@idMateria;";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("docenteCi", docenteCi);
            this.comando.Parameters.AddWithValue("idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
            this.comando.Parameters.Clear();
        }
        public void actualizarDocenteTieneGM(string idMateria, string idGrupo, bool status)
        {
            command = "UPDATE docente_dicta_g_m SET isDeleted=@isDeleted WHERE idGrupo=@idGrupo AND idMateria=@idMateria;";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("@isDeleted", status);
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
            this.comando.Parameters.Clear();
        }
        public void actualizarDocenteTieneGM(string idGrupo, bool status)
        {
            command = "UPDATE docente_dicta_g_m SET isDeleted=@isDeleted WHERE idGrupo=@idGrupo;";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("@isDeleted", status);
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
            this.comando.Parameters.Clear();
        }
        public void actualizarDocenteTieneGM(int idMateria, bool status)
        {
            command = "UPDATE docente_dicta_g_m SET isDeleted=@isDeleted WHERE idMateria=@idMateria;";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("@isDeleted", status);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
            this.comando.Parameters.Clear();
        }

        public void actualizarGrupoTieneMateria(string idMateria, string idGrupo,bool isDeleted)
        {
            this.comando.Parameters.Clear();
            command = "UPDATE grupo_tiene_materia SET isDeleted = @isDeleted WHERE idGrupo=@idGrupo AND idMateria=@idMateria;";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("@isDeleted", isDeleted);
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }
        public void actualizarGrupoTieneMateria(string idGrupo, bool isDeleted)
        {
            this.comando.Parameters.Clear();
            command = "UPDATE grupo_tiene_materia SET isDeleted = @isDeleted WHERE idGrupo=@idGrupo;";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("@isDeleted", isDeleted);
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }
        public void actualizarGrupoTieneMateria(int idMateria, bool isDeleted)
        {
            this.comando.Parameters.Clear();
            command = "UPDATE grupo_tiene_materia SET isDeleted = @isDeleted WHERE idMateria=@idMateria;";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("@isDeleted", isDeleted);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }

        public void cargarMateriasAGrupo(string idMateria, string idGrupo) {
            this.comando.Parameters.Clear();
            command = "INSERT INTO grupo_tiene_materia (idGrupo, idMateria) VALUES (@idGrupo, @idMateria);";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("@idGrupo",idGrupo);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }
        public void cargarGruposAOrientacion(string idOrientacion, string idGrupo)
        {
            this.comando.Parameters.Clear();
            command = "INSERT INTO orientacion_tiene_grupo (idOrientacion, idGrupo) VALUES (@idOrientacion, @idGrupo);";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("@idOrientacion", idOrientacion);
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }

        private List<GrupoModelo> cargarGrupoALista(MySqlCommand commando)
        {
            lector = commando.ExecuteReader();
            List<GrupoModelo> listaG = new List<GrupoModelo>();
            while (lector.Read())
            {
                GrupoModelo g = new GrupoModelo();
                g.idGrupo = int.Parse(lector[0].ToString());
                g.nombreGrupo = lector[1].ToString();
                listaG.Add(g);
            }
            lector.Close();
            return listaG;
        }
        private List<GrupoModelo> cargarGrupoMateriaALista(MySqlCommand commando)
        {
            lector = commando.ExecuteReader();
            List<GrupoModelo> listaGM = new List<GrupoModelo>();
            while (lector.Read())
            {
                GrupoModelo gm = new GrupoModelo();
                gm.idGrupo = int.Parse(lector[0].ToString());
                gm.idMateria = int.Parse(lector[1].ToString());
                gm.nombreGrupo = lector[2].ToString();
                gm.nombreMateria = lector[3].ToString();
                listaGM.Add(gm);
            }
            lector.Close();
            return listaGM;
        }
        private List<GrupoModelo> cargarGrupoOrientacionALista(MySqlCommand commando)
        {
            lector = commando.ExecuteReader();
            List<GrupoModelo> listaGO = new List<GrupoModelo>();
            while (lector.Read())
            {
                GrupoModelo go = new GrupoModelo();
                go.idGrupo = int.Parse(lector[0].ToString());
                go.idOrientacion = int.Parse(lector[1].ToString());
                go.nombreGrupo = lector[2].ToString();
                go.nombreOrientacion = lector[3].ToString();
                listaGO.Add(go);
            }
            lector.Close();
            return listaGO;
        }

        public List<GrupoModelo> getGrupo() {
            this.comando.CommandText = "SELECT idGrupo,nombreGrupo FROM grupo WHERE isDeleted = false ORDER BY idGrupo ASC;";
            return cargarGrupoALista(this.comando);
        }

        public string getGrupo(string nombreGrupo)
        {
            string idGrupo="";
            this.comando.CommandText = "SELECT idGrupo,nombreGrupo FROM grupo WHERE nombreGrupo=@nombreGrupo;";
            this.comando.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
            lector = comando.ExecuteReader();
            while (lector.Read())
                idGrupo = lector[0].ToString();
            lector.Close();
            return idGrupo;
        }
        public GrupoModelo getGrupo(int id,byte sessionType)
        {
            GrupoModelo g = new GrupoModelo(sessionType);
            this.comando.CommandText = "SELECT idGrupo,nombreGrupo FROM grupo WHERE idGrupo=@idGrupo;";
            this.comando.Parameters.AddWithValue("@idGrupo", id);
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                g.idGrupo = int.Parse(lector[0].ToString());
                g.nombreGrupo = lector[1].ToString();
            }
            lector.Close();
            return g;
        }

        public List<GrupoModelo> getGruposSinOrientacion()
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT DISTINCT g.idGrupo,g.nombreGrupo " +
                "FROM grupo g, orientacion_tiene_grupo og " +
                "WHERE g.idGrupo " +
                "NOT IN (SELECT idGrupo FROM orientacion_tiene_grupo) ORDER BY g.idGrupo ASC;";
            return cargarGrupoALista(this.comando);
        }
        public List<GrupoModelo> getGruposDeOrientacion(string idOrientacion)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT g.idGrupo,o.idOrientacion, g.nombreGrupo, o.nombreOrientacion " +
                "FROM grupo g, orientacion o, orientacion_tiene_grupo og " +
                "WHERE og.idGrupo=g.idGrupo " +
                "AND og.idOrientacion = o.idOrientacion " +
                "AND og.idOrientacion = @idOrientacion ORDER BY g.idGrupo ASC;";
            this.comando.Parameters.AddWithValue("@idOrientacion", idOrientacion);
            return cargarGrupoALista(this.comando);
        }

        public override string ToString()
        {
            return $"{idGrupo}    {nombreGrupo}";
        }

        public List<GrupoModelo> getDocenteDictaGM()
        {
            this.comando.CommandText = " SELECT dgm.idGrupo, dgm.idMateria, g.nombreGrupo, m.nombreMateria " +
                "FROM docente_dicta_g_m dgm, grupo g, materia m " +
                "WHERE dgm.docenteCi is null " +
                "AND dgm.idMateria = m.idMateria " +
                "AND g.idGrupo = dgm.idGrupo;";
            return cargarGrupoMateriaALista(this.comando);
        }

        //nuevo******************************************************
        
            //se deberia modificar el cargar metodo arriba para que no tener 2
        private List<GrupoModelo> cargarGM(MySqlCommand command) {
            lector = this.comando.ExecuteReader();
            List<GrupoModelo> listaGruposDelAlumno = new List<GrupoModelo>();
            while (lector.Read())
            {
                GrupoModelo g = new GrupoModelo();
                g.idGrupo = int.Parse(lector[0].ToString());
                g.nombreGrupo = lector[1].ToString();
                g.idMateria = int.Parse(lector[2].ToString());
                g.nombreMateria = lector[3].ToString();
                g.isDeleted = lector[4].ToString();
                listaGruposDelAlumno.Add(g);
            }
            lector.Close();
            return listaGruposDelAlumno;
        }

        public List<GrupoModelo> grupoMateria()
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT gm.idGrupo, gm.idMateria, g.nombreGrupo, m.nombreMateria " +
                "FROM grupo_tiene_materia gm, grupo g, materia m " +
                "WHERE gm.idGrupo = g.idGrupo " +
                "AND gm.idMateria = m.idMateria " +
                "AND g.isDeleted = false " +
                "AND m.isDeleted = false " +
                "AND gm.isDeleted = false ORDER BY gm.idGrupo ASC;";
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            return cargarGrupoMateriaALista(this.comando);
        }
        public List<GrupoModelo> grupoMateria(string idMateria)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT  gm.idGrupo, gm.idMateria, g.nombreGrupo, m.nombreMateria " +
                "FROM grupo_tiene_materia gm, grupo g, materia m " +
                "WHERE gm.idGrupo = g.idGrupo " +
                "AND gm.idMateria = m.idMateria " +
                "AND m.idMateria = @idMateria " +
                "AND g.isDeleted = false " +
                "AND m.isDeleted = false " +
                "AND gm.isDeleted = false;";
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            return cargarGrupoMateriaALista(this.comando);
        }
        public List<GrupoModelo> grupoMateria(int idGrupo)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT  gm.idGrupo, gm.idMateria, g.nombreGrupo, m.nombreMateria " +
                "FROM grupo_tiene_materia gm, grupo g, materia m " +
                "WHERE gm.idGrupo = g.idGrupo " +
                "AND gm.idMateria = m.idMateria " +
                "AND g.idGrupo = @idGrupo " +
                "AND g.isDeleted = false " +
                "AND m.isDeleted = false " +
                "AND gm.isDeleted = false;";
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            return cargarGrupoMateriaALista(this.comando);
        }

        public List<GrupoModelo> getAlumnoGrupoyYmaterias(string ci) {
            this.comando.CommandText = "SELECT g.idGrupo, g.nombreGrupo, m.idMateria, m.nombreMateria, g.isDeleted FROM grupo g, alumno_tiene_grupo ag, materia m, grupo_tiene_materia gm " +
                "WHERE ag.idGrupo=g.idGrupo " +
                "AND ag.alumnoCi=@ci " +
                "AND gm.idGrupo=ag.idGrupo " +
                "AND gm.idMateria=m.idMateria;";
            this.comando.Parameters.AddWithValue("@ci", ci);
            return cargarGM(this.comando);
        }
        public List<GrupoModelo> getAlumnoGrupos(string ci)
        {
            //this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT DISTINCT g.idGrupo, g.nombreGrupo, g.isDeleted FROM grupo g, alumno_tiene_grupo ag, grupo_tiene_materia gm " +
                "WHERE ag.idGrupo=g.idGrupo " +
                "AND ag.alumnoCi=@ci " +
                "AND gm.idGrupo=ag.idGrupo ORDER BY g.idGrupo ASC;";
            this.comando.Parameters.AddWithValue("@ci", ci);
            List<GrupoModelo> grupos = new List<GrupoModelo>();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                GrupoModelo g = new GrupoModelo();
                g.idGrupo = int.Parse(lector[0].ToString());
                g.nombreGrupo = lector[1].ToString();
                g.isDeleted = lector[2].ToString();
                grupos.Add(g);
            }
            lector.Close();
            return grupos;
        }

        public List<GrupoModelo> getDocenteDictaGM(string ci)
        {
            this.comando.CommandText = "SELECT dgm.idGrupo,g.nombreGrupo, dgm.idMateria, m.nombreMateria, g.isDeleted " +
                "FROM docente_dicta_g_m dgm, grupo g, materia m " +
                "WHERE dgm.docenteCi=@ci " +
                "AND dgm.idMateria = m.idMateria " +
                "AND g.idGrupo = dgm.idGrupo ORDER BY dgm.idGrupo ASC;";
            this.comando.Parameters.AddWithValue("@ci",ci);
            return cargarGM(this.comando);
        }
        public string getDocenteDictaGM(string idGrupo,string idMateria)
        {
            string ci=null;
            this.comando.CommandText = "SELECT dgm.docenteCi " +
                "FROM docente_dicta_g_m dgm " +
                "WHERE dgm.idMateria = @idMateria " +
                "AND dgm.idGrupo= @idGrupo;";
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            lector = this.comando.ExecuteReader();
            while (lector.Read()) {
            ci = lector[0].ToString();
            }
            lector.Close();
            if (string.IsNullOrEmpty(ci))
                throw new Exception("DGM-noTeacher");
            return ci;
        }


    }
}
