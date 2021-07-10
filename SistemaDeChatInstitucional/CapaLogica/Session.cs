using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaLogica
{
    public class Session
    {
        public  string cedula { get; set; }
        public  string nombre { get; set; }
        public  string apellido { get; set; }
        public  string clave { get; set; }

        public string toString()
        {
            return "Session ToString: "+ cedula + " " + nombre + " " + apellido +" "+ clave;
        }
        //foto
        //avatar
    }
}
