﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaLogica
{
    public static class AlumnoControlador
    {
        public static bool AltaDeAlumno(int cedula, string nombre, string apellido, string clave)
        {
            PersonaModelo Alumno = new PersonaModelo();

            Alumno.Cedula = cedula;
            Alumno.Nombre = nombre;
            Alumno.Apellido = apellido;
            Alumno.Clave = clave;

            Alumno.Guardar();

            return true;

        }
    }
}
