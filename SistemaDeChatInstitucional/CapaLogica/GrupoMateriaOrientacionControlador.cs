﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaLogica
{
    public static partial class Controlador
    {
        public static void deleteMateria(int idMateria, string idGrupo)
        {
            GrupoModelo g = new GrupoModelo(Session.type);
            g.idGrupo = int.Parse(idGrupo);
            g.idMateria = idMateria;
           // g.deleteMateriasDeGrupo();
        }

        public static void sacarGrupoMateria(int idMateria, int idGrupo)
        {
            GrupoModelo g = new GrupoModelo(Session.type);
            g.idGrupo = idGrupo;
            g.idMateria = idMateria;
            g.sacarFilaGrupoTieneMateria();
        }

        public static void nuevoGrupo(string nombreGrupo) {
            GrupoModelo g = new GrupoModelo(Session.type);
            g.nombreGrupo = nombreGrupo;
            g.crearGrupoNuevo();
        }

        public static void nuevaMateria(string nombreMateria)
        {
            MateriaModelo m = new MateriaModelo(Session.type);
            m.nombreMateria = nombreMateria;
            m.crearMateriaNueva();
        }

        public static void nuevaOrientacion(string nombreOrientacion)
        {
            OrientacionModelo o = new OrientacionModelo(Session.type);
            o.nombreOrientacion = nombreOrientacion;
            o.crearMateriaNueva();
        }
        //maybe delete
        public static void asignarMateriasAGrupo(List<int> materiasSeleccionadas, string idGrupo) {
            GrupoModelo g = new GrupoModelo(Session.type);
            foreach (int materia in materiasSeleccionadas)
                g.cargarMateriasAGrupo(materia.ToString(),idGrupo);
            
        }
        public static void asignarMateriasAGrupo(string idMateria, string idGrupo) => new GrupoModelo(Session.type).cargarMateriasAGrupo( idMateria, idGrupo); 

        public static string countSalaPorMateria(string idMateria)
        {
            MateriaModelo m = new MateriaModelo(Session.type);
            m.idMateria = int.Parse(idMateria);
            return m.countSalaPorMateria();
        }

        public static void asignarMateriasAGrupo(List<int> gruposSeleccionados, int idMateria)
        {
            GrupoModelo g = new GrupoModelo(Session.type);
            foreach (int grupo in gruposSeleccionados)
                g.cargarMateriasAGrupo(idMateria.ToString(), grupo.ToString());
        }

        public static void asignarOrientacionesAGrupos(List<int> grupoSeleccionados, string idOrientacion)
        {
            GrupoModelo g = new GrupoModelo(Session.type);
            g.idOrientacion = int.Parse(idOrientacion);
            foreach (int grupo in grupoSeleccionados)
            {
                g.idGrupo = grupo;
                g.cargarGruposAOrientacion();
            }
        }

        public static string grupoPorNombreGrupo(string nombreGrupo) {
            GrupoModelo g = new GrupoModelo(Session.type);
            return g.getGrupo(nombreGrupo, Session.type);
        }

        public static string MateriaPorNombreMateria(string nombreMateria)
        {
            MateriaModelo m = new MateriaModelo(Session.type);
            return m.getMateria(nombreMateria, Session.type);
        }

        public static string orientacionPorNombre(string nombreOrientacion)
        {
            OrientacionModelo o = new OrientacionModelo(Session.type);
            return o.getOrientacion(nombreOrientacion, Session.type);
        }


        public static List<string> obtenerMaterias()
          {
            MateriaModelo m = new MateriaModelo(Session.type);
            List<MateriaModelo> materias = m.getMateria(Session.type);
            List<string> pinga = new List<string>();

              foreach (MateriaModelo materia in materias)
                pinga.Add(materia.nombreMateria);
              
              return pinga;
          }

        public static DataTable obtenerMateriass()
        {
            MateriaModelo m = new MateriaModelo(Session.type);
            DataTable data = new DataTable();
            data.Columns.Add("idMateria");
            data.Columns.Add("Materia");

            foreach (MateriaModelo materia in m.getMateria(Session.type))
                data.Rows.Add(materia.idMateria , materia.nombreMateria);

            return data;
        }

        //un forma de darle check a las boxes del checked list
        public static List<int> obtenerMaterias(string idGrupo)
        {
            MateriaModelo m = new MateriaModelo(Session.type);
            List<MateriaModelo> todasLasMaterias = m.getMateria(Session.type);
            string idMateria;
            List<int> checkedListBoxIndexesToCheck = new List<int>();

            foreach (MateriaModelo materia in m.getGrupoTieneMateria(idGrupo, Session.type))
            {
                idMateria = materia.idMateria.ToString();
                //idMateriasDeGrupo.Add(materia.idMateria.ToString());
                for (int y = 0; y < todasLasMaterias.Count; y++)
                    if (todasLasMaterias[y].idMateria.ToString() == idMateria)
                    {
                        checkedListBoxIndexesToCheck.Add(y);
                        break;
                    }   
            }
            return checkedListBoxIndexesToCheck;
        }

        public static List<string> MateriasToListForRegister()
        {
            MateriaModelo materia = new MateriaModelo(Session.type);
            List<string> mString = new List<string>();
            foreach (MateriaModelo m in materia.getMateria(Session.type))
            {
                mString.Add($"{m.idMateria}   {m.nombreMateria}");
            }
            return mString;

        }

        public static List<string> gruposToListForRegister()
        {
            GrupoModelo grupo = new GrupoModelo(Session.type);
            List<string> gString = new List<string>();
            foreach (GrupoModelo g in grupo.getGrupo(Session.type))
            {
                gString.Add($"{g.idGrupo}   {g.nombreGrupo}");
            }
            return gString;
        }

        public static List<string> gruposSinOrientacion()
        {
            GrupoModelo grupo = new GrupoModelo(Session.type);
            List<string> gString = new List<string>();
            foreach (GrupoModelo g in grupo.getGruposSinOrientacion(Session.type))
            {
                gString.Add($"{g.idGrupo}   {g.nombreGrupo}");
            }
            return gString;

        }

        public static List<string> orientacionToListForRegister()
        {
            OrientacionModelo orientacion = new OrientacionModelo(Session.type);
            List<string> oString = new List<string>();
            foreach (OrientacionModelo o in orientacion.getOrientacion(Session.type))
            {
                oString.Add($"{o.idOrientacion}   {o.nombreOrientacion}");
            }
            return oString;

        }

        //Lista del query me muestra todas las materias-grupo pero la base no permite que hayan
        //mas de un docente para una materia-grupo
        //usar regular expression para extrar datos enves de usar index para mandar checked boxes.
        public static List<string> grupoMateriaToListForRegister()
        {
            List<string> gmString = new List<string>();
            GrupoModelo gm = new GrupoModelo(Session.type);
            string entry;
            foreach (GrupoModelo g in gm.getDocenteDictaGM(Session.type))
            {
                entry = $"{g.nombreGrupo}   {g.nombreMateria}";
                gmString.Add(entry);
            }
            return gmString;
        }

        public static List<List<string>> gruposDeMateria(string idMateria)
        {
            List<List <string>> GruposYMaterias = new List<List<string>>();
            GrupoModelo gm = new GrupoModelo(Session.type);
            foreach (GrupoModelo g in gm.grupoMateria(idMateria, Session.type))
            {
            List<string> grupoMateriaFila = new List<string>();
                grupoMateriaFila.Add(g.idGrupo.ToString());
                grupoMateriaFila.Add(g.idMateria.ToString());
                grupoMateriaFila.Add(g.nombreGrupo);
                grupoMateriaFila.Add(g.nombreMateria);
                GruposYMaterias.Add(grupoMateriaFila);
            }
            return GruposYMaterias;
        }

        public static DataTable obtenerOrientaciones()
        {
            OrientacionModelo o = new OrientacionModelo(Session.type);
            List<OrientacionModelo> orientaciones = o.getOrientacion(Session.type);
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Orientaciones");
            
            foreach (OrientacionModelo orientacion in orientaciones)
            {
                tabla.Rows.Add(orientacion.nombreOrientacion);
            }
            return tabla;
        }

        public static DataTable obtenerGrupos()
        {
            GrupoModelo g = new GrupoModelo(Session.type);
            List<GrupoModelo> grupos = g.getGrupo(Session.type);
            DataTable tabla = new DataTable();

            tabla.Columns.Add("idGrupo");
            tabla.Columns.Add("Grupos");

            foreach (GrupoModelo grupo in grupos)
                tabla.Rows.Add(grupo.idGrupo, grupo.nombreGrupo);
            

            return tabla;
        }
        public static List<string> obtenerGrupo(string idGrupo)
        {
            GrupoModelo g = new GrupoModelo(Session.type);
            g.getGrupo(idGrupo,Session.type);
            List<string> s = new List<string>();

            s.Add(g.idGrupo.ToString());
            s.Add(g.nombreGrupo);
            return s;
        }

        public static void actualizarNombreGrupo(string newName, string idGrupo) => new GrupoModelo(Session.type).actualizarNombreDeGrupo(newName,idGrupo);
        public static void actualizarNombreMateria(string newName, string idMateria) => new MateriaModelo(Session.type).actualizarNombreDeMateria(newName,idMateria);
        public static void actualizarNombreOrientacion(string newName, string idOrientacion) => new OrientacionModelo(Session.type).actualizarNombreDeOrientacion(newName,idOrientacion);
        public static void actualizarGrupoTieneMateria(string idMateria, string idGrupo, bool isDeleted) => new GrupoModelo(Session.type).actualizarGrupoTieneMateria(idMateria,idGrupo,isDeleted);
        public static void actualizarDocenteDictaGM(string idMateria, string idGrupo, bool status) => new GrupoModelo(Session.type).actualizarDocenteTieneGM(idMateria, idGrupo, status);
    
        public static bool validarGrupo(string idGrupo, string nombreGrupo)
        { 
            GrupoModelo g = new GrupoModelo(Session.type);
            g.getGrupo(idGrupo, nombreGrupo, Session.type);

            return true;
        }
    }
}
