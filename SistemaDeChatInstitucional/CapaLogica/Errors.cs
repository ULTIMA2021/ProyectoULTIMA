using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public static partial class Controlador
    {

        //cambiar esto para que no le tire el exception msg. Esta ahora para ver que error es que pasa
        public static string errorHandler(Exception ex)
        {
            string msg; 
            switch (ex.Message)
            {
                case "Connection-0":
                    msg = "No se pudo conectar a la base de datos";
                    break;
                case "Connection-1042":
                    msg = "La conexion a esa direccion no existe";
                    break;
                case "Connection-":
                    msg = "Hubo un error con la conexion"; 
                    break;

                case "Persona-1062":
                    msg = "esa persona ya existe";
                    break;
                case "Persona-1048":
                    msg = "Todos los campos indicados deben estar llenos";
                    break;
                case "Persona-1366":
                    msg = "Todos los campos indicados deben estar llenos";
                    break;

                case "Grupo-1062":
                    msg = "ese grupo ya existe";
                    break;
                case "Grupo-1048":
                    msg = "Todos los campos indicados deben estar llenos";
                    break;
                case "Grupo-1644":
                    msg = "el nombre es invalido";
                    break;

                case "Materia-1062":
                    msg = "esa materia ya existe";
                    break;
                case "Materia-1048":
                    msg = "Todos los campos indicados deben estar llenos";
                    break;
                case "Materia-1644":
                    msg = "el nombre es invalido";
                    break;

                case "Orientacion-1062":
                    msg = "esa orientacion ya existe";
                    break;
                case "Orientacion-1048":
                    msg = "Todos los campos indicados deben estar llenos";
                    break;
                case "Orientacion-1644":
                    msg = "el nombre es invalido";
                    break;

                case "ConsultaPrivada-1062":
                    msg = "Algo raro paso, no se pudo mandar la consulta";
                    break;
                case "ConsultaPrivada-1048":
                    msg = "No puede mandar una consulta sin un asunto";
                    break;

                case "MensajePrivado-1062":
                    msg = "Algo raro paso, no se pudo mandar la consulta";
                    break;
                case "MensajePrivado-1048":
                    msg = "No puede mandar una consulta sin contenido";
                    break;


                case "DGM-noTeacher":
                    msg = "no esta asignado un docente para esa materia";
                    break;

                case "NO DOCENTES FOR PERSON":
                    msg = "no estan asignados docentes para sus materias";
                    break;

                default:
                    msg = "Error desconocido";
                    break;
            }
            return $"ERROR CODE: {ex.Message}\n\n{msg}";
        }
    }
}
