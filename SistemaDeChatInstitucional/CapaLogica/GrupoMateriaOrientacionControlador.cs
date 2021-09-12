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
        /*   public static DataTable listarMaterias()
          {
              PersonaModelo p = new PersonaModelo();
              List<PersonaModelo> materias = p.obtenerMaterias();
              DataTable tabla = new DataTable();

              tabla.Columns.Add("Materias");

              foreach (PersonaModelo materia in materias)
              {
                  tabla.Rows.Add(materia.materia);
              }


              return tabla;
          }

          */

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
    }
}
