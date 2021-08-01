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
        public static byte type{ get; set; }//0-alumno   1-docente    2-admin   3=
        
    public static void saveToCache(PersonaModelo per)
        {
            cedula = per.Cedula;
            nombre = per.Nombre;
            apellido = per.Apellido;
            clave = per.Clave;
        }
        public static string toString()
        {
            return "Session ToString: "+ cedula + " " + nombre + " " + apellido +" "+ clave;
        }
        
    }
}
