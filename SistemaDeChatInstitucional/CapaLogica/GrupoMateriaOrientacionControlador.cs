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
        public static void deleteOrientacion(string idOrientacion) => new OrientacionModelo(Session.type).borrarOrientacion(idOrientacion);
        public static void deleteMateria(string idMateria) => new MateriaModelo(Session.type).borrarMateria(idMateria);
        public static void deleteGrupo(string idGrupo) => new GrupoModelo(Session.type).borrarGrupo(idGrupo);
        public static void sacarGrupoMateria(int idMateria, int idGrupo)
        {
            GrupoModelo g = new GrupoModelo(Session.type);
            g.idGrupo = idGrupo;
            g.idMateria = idMateria;
            g.sacarFilaGrupoTieneMateria();
        }
        public static void sacarGrupoOrientacion(int idOrienatcion, int idGrupo)
        {
            GrupoModelo g = new GrupoModelo(Session.type);
            g.idGrupo = idGrupo;
            g.idOrientacion = idOrienatcion;
            g.sacarFilaOrientacionTieneGrupo();
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
        public static void asignarGruposAOrientacion(string idOrientacion, string idGrupo) => new GrupoModelo(Session.type).cargarGruposAOrientacion(idOrientacion,idGrupo);
        public static void asignarMateriasAGrupo(List<int> gruposSeleccionados, int idMateria)
        {
            GrupoModelo g = new GrupoModelo(Session.type);
            foreach (int grupo in gruposSeleccionados)
                g.cargarMateriasAGrupo(idMateria.ToString(), grupo.ToString());
        }
        public static void asignarOrientacionesAGrupos(List<int> grupoSeleccionados, string idOrientacion)
        {
            GrupoModelo g = new GrupoModelo(Session.type);
            foreach (int grupo in grupoSeleccionados)
                g.cargarGruposAOrientacion(idOrientacion,grupo.ToString());
        }

        public static string countSalaPorMateria(string idMateria)
        {
            MateriaModelo m = new MateriaModelo(Session.type);
            m.idMateria = int.Parse(idMateria);
            return m.countSalaPorMateria();
        }


        public static string grupoPorNombreGrupo(string nombreGrupo) => new GrupoModelo(Session.type).getGrupo(nombreGrupo);
        public static string MateriaPorNombreMateria(string nombreMateria) => new MateriaModelo(Session.type).getMateria(nombreMateria);
        public static string orientacionPorNombre(string nombreOrientacion) => new OrientacionModelo(Session.type).getOrientacion(nombreOrientacion);

        public static List<string> obtenerMaterias()
          {
            MateriaModelo m = new MateriaModelo(Session.type);
            List<MateriaModelo> materias = m.getMateria();
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

            foreach (MateriaModelo materia in m.getMateria())
                data.Rows.Add(materia.idMateria , materia.nombreMateria);

            return data;
        }

        //un forma de darle check a las boxes del checked list
        public static List<int> obtenerMaterias(string idGrupo)
        {
            MateriaModelo m = new MateriaModelo(Session.type);
            List<MateriaModelo> todasLasMaterias = m.getMateria();
            string idMateria;
            List<int> checkedListBoxIndexesToCheck = new List<int>();

            foreach (MateriaModelo materia in m.getGrupoTieneMateria(idGrupo))
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
            foreach (MateriaModelo m in materia.getMateria())
            {
                mString.Add($"{m.idMateria}   {m.nombreMateria}");
            }
            return mString;

        }

        public static List<string> gruposToListForRegister()
        {
            GrupoModelo grupo = new GrupoModelo(Session.type);
            List<string> gString = new List<string>();
            foreach (GrupoModelo g in grupo.getGrupo())
            {
                gString.Add($"{g.idGrupo}   {g.nombreGrupo}");
            }
            return gString;
        }

        public static List<string> gruposSinOrientacion()
        {
            GrupoModelo grupo = new GrupoModelo(Session.type);
            List<string> gString = new List<string>();
            foreach (GrupoModelo g in grupo.getGruposSinOrientacion())
            {
                gString.Add($"{g.idGrupo}   {g.nombreGrupo}");
            }
            return gString;

        }

        public static List<string> orientacionToListForRegister()
        {
            OrientacionModelo orientacion = new OrientacionModelo(Session.type);
            List<string> oString = new List<string>();
            foreach (OrientacionModelo o in orientacion.getOrientacion())
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
            foreach (GrupoModelo g in gm.getDocenteDictaGM())
            {
                entry = $"{g.nombreGrupo}   {g.nombreMateria}";
                gmString.Add(entry);
            }
            return gmString;
        }
        public static List<string> grupoMateriaToListForModification()
        {
            List<string> gmString = new List<string>();
            GrupoModelo gm = new GrupoModelo(Session.type);
            string entry;
            foreach (GrupoModelo g in gm.grupoMateria())
            {
                entry = $"{g.nombreGrupo}   {g.nombreMateria}";
                gmString.Add(entry);
            }
            return gmString;
        }


        public static List<List<string>> gruposDeMateria(string idMateria) //grupos no ocultados de la materia indicada
        {
            List<List <string>> GruposYMaterias = new List<List<string>>();
            GrupoModelo gm = new GrupoModelo(Session.type);
            foreach (GrupoModelo g in gm.grupoMateria(idMateria))
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
        public static List<List<string>> gruposDeMateria(int idGrupo) //materias no ocultadas del grupo indicado
        {
            List<List<string>> GruposYMaterias = new List<List<string>>();
            GrupoModelo gm = new GrupoModelo(Session.type);
            foreach (GrupoModelo g in gm.grupoMateria(idGrupo))
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
        public static List<List<string>> gruposDeOrientacion(string idOrientacion)
        {
            List<List<string>> gruposDeOrientacion = new List<List<string>>();
            GrupoModelo go = new GrupoModelo(Session.type);
            foreach (GrupoModelo g in go.getGruposDeOrientacion(idOrientacion))
            {
                List<string> grupoOrientacion = new List<string>();
                grupoOrientacion.Add(g.idGrupo.ToString());
                grupoOrientacion.Add(g.idMateria.ToString());
                grupoOrientacion.Add(g.nombreGrupo);
                grupoOrientacion.Add(g.nombreMateria);
                gruposDeOrientacion.Add(grupoOrientacion);
            }
            return gruposDeOrientacion;

        }

        public static DataTable obtenerOrientaciones()
        {
            OrientacionModelo o = new OrientacionModelo(Session.type);
            List<OrientacionModelo> orientaciones = o.getOrientacion();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id");
            tabla.Columns.Add("Orientaciones");
            
            foreach (OrientacionModelo orientacion in orientaciones)
            {
                tabla.Rows.Add(orientacion.idOrientacion,orientacion.nombreOrientacion);
            }
            return tabla;
        }
        public static DataTable obtenerGrupos()
        {
            GrupoModelo g = new GrupoModelo(Session.type);
            List<GrupoModelo> grupos = g.getGrupo();
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
            g = g.getGrupo(int.Parse(idGrupo),Session.type);
            List<string> s = new List<string>();

            s.Add(g.idGrupo.ToString());
            s.Add(g.nombreGrupo);
            return s;
        }
        public static List<List<string>> obtenerGrupos(int ci)
        {
            List<List<string>> grupos = new List<List<string>>();

            foreach (var grupo in new GrupoModelo(Session.type).getAlumnoGrupos(ci.ToString()))
            {
                List<string> gString = new List<string>();
                gString.Add(grupo.idGrupo.ToString());
                gString.Add(grupo.nombreGrupo.ToString());
                grupos.Add(gString);
            }
            return grupos;
        }
        //public static List<List<string>> obtenerGrupoMaterias()
        //{
        //    foreach (var grupoMateria in new GrupoModelo(Session.type).grup();
        //    {

        //    }
        //}
        public static List<List<string>> obtenerGrupoMaterias(string ci)
        {
            List<List<string>> grupoMaterias = new List<List<string>>();
            foreach (var gm in new GrupoModelo(Session.type).getDocenteDictaGM(ci))
            {
                if (gm.isDeleted == "False")
                {
                    List<string> gmString = new List<string>();
                    gmString.Add(gm.idGrupo.ToString());
                    gmString.Add(gm.nombreGrupo);
                    gmString.Add(gm.idMateria.ToString());
                    gmString.Add(gm.nombreMateria);
                    grupoMaterias.Add(gmString);
                }
            }
            return grupoMaterias;
        }

        public static void actualizarEstadoGrupo(bool isDeleted, string idGrupo) => new GrupoModelo(Session.type).actualizarEstadoDeGrupo(isDeleted, idGrupo);
        public static void actualizarEstadoMateria(bool isDeleted, string idMateria) => new MateriaModelo(Session.type).actualizarEstadoDeMateria(isDeleted, idMateria);

        public static void actualizarNombreGrupo(string newName, string idGrupo) => new GrupoModelo(Session.type).actualizarNombreDeGrupo(newName,idGrupo);
        public static void actualizarNombreMateria(string newName, string idMateria) => new MateriaModelo(Session.type).actualizarNombreDeMateria(newName,idMateria);
        public static void actualizarNombreOrientacion(string newName, string idOrientacion) => new OrientacionModelo(Session.type).actualizarNombreDeOrientacion(newName,idOrientacion);

        public static void actualizarGrupoTieneMateria(string idMateria, string idGrupo, bool isDeleted) => new GrupoModelo(Session.type).actualizarGrupoTieneMateria(idMateria,idGrupo,isDeleted);
        public static void actualizarGrupoTieneMateria(string idGrupo, bool isDeleted) => new GrupoModelo(Session.type).actualizarGrupoTieneMateria(idGrupo,isDeleted);
        public static void actualizarGrupoTieneMateria(int idMateria, bool isDeleted) => new GrupoModelo(Session.type).actualizarGrupoTieneMateria(idMateria, isDeleted);

        public static void actualizarDocenteDictaGM(string idMateria, string idGrupo, bool status) => new GrupoModelo(Session.type).actualizarDocenteTieneGM(idMateria, idGrupo, status);
        public static void actualizarDocenteDictaGM(string idGrupo, bool status) => new GrupoModelo(Session.type).actualizarDocenteTieneGM(idGrupo, status);
        public static void actualizarDocenteDictaGM(int idMateria, bool status) => new GrupoModelo(Session.type).actualizarDocenteTieneGM(idMateria, status);

    }
}
