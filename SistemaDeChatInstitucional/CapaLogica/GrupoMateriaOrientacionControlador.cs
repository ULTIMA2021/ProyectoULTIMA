using System;
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

        public static void asignarMateriasAGrupo(List<int> materiasSeleccionadas, string idGrupo) {
            GrupoModelo g = new GrupoModelo(Session.type);
            g.idGrupo = int.Parse(idGrupo);
            foreach (int materia in materiasSeleccionadas)
            {
                g.idMateria = materia;
                g.cargarMateriasAGrupo();
            }
        }

        public static void asignarMateriasAGrupo(List<int> gruposSeleccionados, int idMateria)
        {
            GrupoModelo g = new GrupoModelo(Session.type);
            g.idMateria = idMateria;
            foreach (int grupo in gruposSeleccionados)
            {
                g.idGrupo = grupo;
                g.cargarMateriasAGrupo();
            }
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


        public static DataTable obtenerMaterias()
          {
              MateriaModelo m = new MateriaModelo(Session.type);
              List<MateriaModelo> materias = m.getMateria(Session.type);
              DataTable tabla = new DataTable();

              tabla.Columns.Add("Materias");

              foreach (MateriaModelo materia in materias)
              {
                  tabla.Rows.Add(materia.nombreMateria);
              }


              return tabla;
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

            tabla.Columns.Add("Grupos");

            foreach (GrupoModelo grupo in grupos)
            {
                tabla.Rows.Add(grupo.nombreGrupo);
            }


            return tabla;
        }
    }
}
