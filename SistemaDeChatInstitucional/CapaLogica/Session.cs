using System;
using System.Collections.Generic;

using CapaDeDatos;

namespace CapaLogica
{
    public static class Session
    {
        public static string cedula { get; set; }
        public static string nombre { get; set; }
        public static string apellido { get; set; }
        public static string clave { get; set; }
        public static byte[] foto { get; set; }
        //foto
        public static byte type;//0-alumno   1-docente    2-admin    3-alumnoLogin   4-docenteLogin   5-adminLogin
        public static List<List<string>> grupoMaterias=new List<List<string>>();

        public static void saveToCache(PersonaModelo per, List<GrupoModelo> gList)
        {
            cedula = per.Cedula;
            nombre = per.Nombre;
            apellido = per.Apellido;
            clave = per.Clave;
            foto = per.foto;
            if(!(gList is null))
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
                fila.Add(g.isDeleted);
                Console.WriteLine($"idGrupo: {fila[0]}   nombreGrupo: {fila[1]}   idmateria: {fila[2]}   nombreMateria: {fila[3]}   isDeleted: {fila[4]}");
                grupoMaterias.Add(fila);
            }
        }
       
        public static string toString()
        {
            return "Session ToString: "+ cedula + " " + nombre + " " + apellido +" "+ clave;
        }
    }
}
