using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaLogica
{
    public static class Session
    {
        public static string cedula { get; set; }
        public static string nombre { get; set; }
        public static string apellido { get; set; }
        public static string clave { get; set; }
        //foto
        //avatar
        public static byte type;//0-alumno   1-docente    2-admin    3-alumnoLogin   4-docenteLogin   5-adminLogin
        public static List<List<string>> grupoMaterias=new List<List<string>>();

        public static void saveToCache(PersonaModelo per, List<GrupoModelo> gList)
        {
            cedula = per.Cedula;
            nombre = per.Nombre;
            apellido = per.Apellido;
            clave = per.Clave;
            saveGrupoMaterias(gList);
        }

        private static void saveGrupoMaterias(List<GrupoModelo> gList) {
            foreach (GrupoModelo g in gList)
            {
            List<string> fila = new List<string>();
                fila.Add(g.idGrupo.ToString());
                fila.Add(g.nombreGrupo);
                fila.Add(g.idMateria.ToString());
                fila.Add(g.nombreMateria);
                grupoMaterias.Add(fila);
            }
        }
       
        public static string toString()
        {
            return "Session ToString: "+ cedula + " " + nombre + " " + apellido +" "+ clave;
        }
    }
}
