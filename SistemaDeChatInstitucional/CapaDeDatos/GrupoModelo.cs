﻿using System;
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

        public GrupoModelo(byte sessionType) : base(sessionType)
        {
        }

        public void crearGrupoNuevo()
        {
            this.comando.CommandText = "INSERT INTO Grupo (nombreGrupo) VALUES(@nombreGrupo);";
            this.comando.Parameters.AddWithValue("nombreGrupo", this.nombreGrupo);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }
        public void actualizarNombreDeGrupo(string nombreGrupo, string idGrupo)
        {
            this.comando.CommandText = "UPDATE Grupo SET nombreGrupo = @nombreGrupo WHERE idGrupo = @idGrupo;";
            this.comando.Parameters.AddWithValue("@nombreGrupo",nombreGrupo );
            this.comando.Parameters.AddWithValue("@idGrupo",idGrupo);
            EjecutarQuery(comando,errorType);
        }
        public void sacarFilaGrupoTieneMateria()
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "DELETE FROM Grupo_tiene_Materia WHERE idMateria = @idMateria AND idGrupo = @idGrupo";
            this.comando.Parameters.AddWithValue("@idGrupo",this.idGrupo);
            this.comando.Parameters.AddWithValue("@idMateria",this.idMateria);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }

        public string countAlumnoTieneGrupo(string ci)
        {
            string count;
            command = "SELECT COUNT(*) FROM Alumno_tiene_Grupo WHERE alumnoCi=@ci;";
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
            command = "SELECT COUNT(*) FROM Docente_dicta_G_M WHERE docenteCi = @ci;";
            this.comando.Parameters.AddWithValue("@ci", ci);
            lector = comando.ExecuteReader();
            lector.Read();
            count = lector[0].ToString();
            lector.Close();
            return count;
        }

        public void nuevoIngresoAlumnoTieneGrupo(string alumnoCi, int idGrupo) {
            command = "INSERT INTO Alumno_tiene_Grupo (alumnoCi,idGrupo) VALUES (@alumnoCi,@idGrupo);";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("alumnoCi", alumnoCi);
            this.comando.Parameters.AddWithValue("idGrupo", idGrupo);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
            this.comando.Parameters.Clear();
        }
        public void nuevoIngresoDocenteTieneGM(string docenteCi, int idGrupo, int idMateria) {
            command = "INSERT INTO Docente_dicta_G_M (docenteCi,idGrupo,idMateria) VALUES (@docenteCi,@idGrupo,@idMateria);";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("docenteCi", docenteCi);
            this.comando.Parameters.AddWithValue("idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
            this.comando.Parameters.Clear();
        }
        public void actualizarDocenteTieneGM(string docenteCi, int idGrupo, int idMateria) {
            command = "UPDATE Docente_dicta_G_M SET docenteCi=@docenteCi WHERE idGrupo=@idGrupo AND idMateria=@idMateria;";
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
            command = "UPDATE Docente_dicta_G_M SET isDeleted=@isDeleted WHERE idGrupo=@idGrupo AND idMateria=@idMateria;";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("@isDeleted", status);
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
            this.comando.Parameters.Clear();
        }
        public void actualizarGrupoTieneMateria(string idMateria, string idGrupo,bool isDeleted)
        {
            this.comando.Parameters.Clear();
            command = "UPDATE Grupo_tiene_Materia SET isDeleted = @isDeleted WHERE idGrupo=@idGrupo AND idMateria=@idMateria;";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("@isDeleted", isDeleted);
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }

        public void cargarMateriasAGrupo(string idMateria, string idGrupo) {
            this.comando.Parameters.Clear();
            command = "INSERT INTO Grupo_tiene_Materia (idGrupo, idMateria) VALUES (@idGrupo, @idMateria);";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("@idGrupo",idGrupo);
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            this.comando.Prepare();
            EjecutarSpecialQuery(this.comando);
        }
        public void cargarGruposAOrientacion()
        {
            this.comando.Parameters.Clear();
            command = "INSERT INTO Orientacion_tiene_Grupo (idOrientacion, idGrupo) VALUES (@idOrientacion, @idGrupo);";
            this.comando.CommandText = command;
            this.comando.Parameters.AddWithValue("@idOrientacion", this.idOrientacion);
            this.comando.Parameters.AddWithValue("@idGrupo", this.idGrupo);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
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
                GrupoModelo gm = new GrupoModelo(sessionType);
                gm.idGrupo = Int32.Parse(lector[0].ToString());
                gm.idMateria = Int32.Parse(lector[1].ToString());
                gm.nombreGrupo = lector[2].ToString();
                gm.nombreMateria = lector[3].ToString();
                listaGM.Add(gm);
            }
            lector.Close();
            return listaGM;
        }

        public List<GrupoModelo> getGrupo(byte sessionType) {
            this.comando.CommandText = "SELECT idGrupo,nombreGrupo FROM Grupo WHERE isDeleted = false ORDER BY idGrupo ASC;";
            return cargarGrupoALista(this.comando, sessionType);
        }

        public string getGrupo(string nombreGrupo, byte sessionType)
        {
            string idGrupo="";
            this.comando.CommandText = "SELECT idGrupo,nombreGrupo FROM Grupo WHERE nombreGrupo=@nombreGrupo;";
            this.comando.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
            lector = comando.ExecuteReader();
            while (lector.Read())
                idGrupo = lector[0].ToString();
            lector.Close();
            return idGrupo;
        }
        public void getGrupo(string idGrupo, string nombreGrupo, byte sessionType)
        {
            this.comando.CommandText = "SELECT idGrupo,nombreGrupo FROM Grupo WHERE nombreGrupo=@nombreGrupo AND idGrupo=@idGrupo;";
            this.comando.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
            this.comando.Parameters.AddWithValue("@idGrupo", idGrupo);
            lector = comando.ExecuteReader();
            lector.Read();
            if (lector[0].ToString() is null)
                throw new Exception("grupo id and grup name has changed") ;
            lector.Close();
        }

        public List<GrupoModelo> getGruposSinOrientacion(byte sessionType)
        {
            this.comando.CommandText = "SELECT DISTINCT g.idGrupo,g.nombreGrupo " +
                "FROM Grupo g, Orientacion_tiene_Grupo og " +
                "WHERE g.idGrupo " +
                "NOT IN (SELECT idGrupo FROM Orientacion_tiene_Grupo) ORDER BY g.idGrupo ASC;";
            return cargarGrupoALista(this.comando, sessionType);
        }

        public override string ToString()
        {
            return $"{idGrupo}    {nombreGrupo}";
        }

        public List<GrupoModelo> getDocenteDictaGM(byte sessionType)
        {
            this.comando.CommandText = " SELECT dgm.idGrupo, dgm.idMateria, g.nombregrupo, m.NombreMateria " +
                "FROM Docente_dicta_G_M dgm, Grupo g, Materia m " +
                "WHERE dgm.docenteCi is null " +
                "AND dgm.idMateria = m.idMateria " +
                "AND g.idGrupo = dgm.idGrupo;";
            return cargarGrupoMateriaALista(this.comando, sessionType);
        }

        //nuevo******************************************************
        
            //se deberia modificar el cargar metodo arriba para que no tener 2
        private List<GrupoModelo> cargarGM(MySqlCommand command,byte sessionType) {
            lector = this.comando.ExecuteReader();
            List<GrupoModelo> listaGruposDelAlumno = new List<GrupoModelo>();
            while (lector.Read())
            {
                GrupoModelo g = new GrupoModelo(sessionType);
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

        public List<GrupoModelo> grupoMateria(string idMateria,byte sessionType)
        {
            this.comando.Parameters.Clear();
            this.comando.CommandText = "SELECT  gm.idGrupo, gm.idMateria, g.nombreGrupo, m.NombreMateria " +
                "FROM Grupo_tiene_Materia gm, Grupo g, Materia m " +
                "WHERE gm.idGrupo = g.idGrupo " +
                "AND gm.idMateria = m.idMateria " +
                "AND m.idMateria = @idMateria " +
                "AND g.isDeleted = false " +
                "AND m.isDeleted = false " +
                "AND gm.isDeleted = false;";
            this.comando.Parameters.AddWithValue("@idMateria", idMateria);
            return (cargarGrupoMateriaALista(this.comando, sessionType));
        }

        public List<GrupoModelo> getAlumnoGrupoyYmaterias(string ci, byte sessionType) {
            this.comando.CommandText = "SELECT g.idGrupo, g.nombreGrupo, m.idMateria, m.nombreMateria, g.isDeleted FROM Grupo g, Alumno_tiene_Grupo ag, Materia m, Grupo_tiene_Materia gm " +
                "WHERE ag.idGrupo=g.idGrupo " +
                "AND ag.alumnoCi=@ci " +
                "AND gm.idGrupo=ag.idGrupo " +
                "AND gm.idMateria=m.idMateria;";
            this.comando.Parameters.AddWithValue("@ci", ci);
            return cargarGM(this.comando,sessionType);
        }

        public List<GrupoModelo> getDocenteDictaGM(string ci, byte sessionType)
        {
            this.comando.CommandText = "SELECT dgm.idGrupo,g.nombreGrupo, dgm.idMateria, m.NombreMateria, g.isDeleted " +
                "FROM Docente_dicta_G_M dgm, Grupo g, Materia m " +
                "WHERE dgm.docenteCi=@ci " +
                "AND dgm.idMateria = m.idMateria " +
                "AND g.idGrupo = dgm.idGrupo;";
            this.comando.Parameters.AddWithValue("@ci",ci);
            return cargarGM(this.comando, sessionType);
        }
        public string getDocenteDictaGM(string idGrupo,string idMateria, byte sessionType)
        {
            string ci=null;
            this.comando.CommandText = "SELECT dgm.docenteCi " +
                "FROM Docente_dicta_G_M dgm " +
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
