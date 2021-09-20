using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class AlumnoTemporalModelo : Modelo
    {
        private string errorType = "Persona";
        public string Cedula;
        public string Nombre;
        public string Apellido;
        public string Clave;
        public string Apodo;
        public string foto;
        public string avatar;
        public bool isDeleted;
        public bool enLinea;

        public AlumnoTemporalModelo(byte sessionType) : base(sessionType)
        {
        }

        public AlumnoTemporalModelo()
        {
        }

        public AlumnoTemporalModelo obtenerAlumnoTemporal()
        {
            this.comando.CommandText = "SELECT ci, nombre, apellido, foto, avatar, enLinea FROM Persona";
            
            AlumnoTemporalModelo persona = new AlumnoTemporalModelo();
            lector = this.comando.ExecuteReader();
            while (lector.Read())
            {
                persona.Cedula = lector[0].ToString();
                persona.Nombre = lector[1].ToString();
                persona.Apellido = lector[2].ToString();
                persona.foto = null;    //lector[3];
                persona.avatar = null;  //lector[4];
            }

            lector.Close();
            return persona;
        }


        // YA HICE LA CONSULTA A LA BASE DE DATOS PARA TRAERME TODO SOBRE LOS ALUMNOS TEMPORALES
        // Y PODER COMENZAR A TRABAJAR EN EL REGISTRO DE INSCRIPCIONES PARA QUE EL ADMIN LO APRUEBE Y SE INGRESEN
        // A LA TABLA PERSONA

        
    }
}
