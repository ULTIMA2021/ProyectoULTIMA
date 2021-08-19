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
        public static DataTable loadSalasDePersona() {
            SalaModelo sala = new SalaModelo(Session.type);
            List<SalaModelo> salas = new List<SalaModelo>();
            DataTable salasDataTable = new DataTable();

            loadTableColumns(salasDataTable);

            int idGrupo;
            int idMateria;
            string nombregrupo;
            string nombreMateria;
            for (int x = 0; x < Session.grupoMaterias.Count; x++) {
                idGrupo = int.Parse(Session.grupoMaterias[x][0]);
                nombregrupo = Session.grupoMaterias[x][1];
                idMateria = int.Parse(Session.grupoMaterias[x][2]);
                nombreMateria = Session.grupoMaterias[x][3];


                //Console.WriteLine($"idgrupo: {idGrupo} idMateria: {idMateria}");
                try
                {
                    salas = sala.salaPorGrupoMateria(idGrupo, idMateria, Session.type);
                    loadSalasToDataTable(salasDataTable, salas, nombregrupo, nombreMateria);
                }
                catch (Exception)
                {
                    Console.WriteLine($"idgrupo: {idGrupo} idMateria: {idMateria} doesnt have a teacher assigned"); ;
                }
            }
            return salasDataTable;
        }

        private static void loadSalasToDataTable(DataTable table, List<SalaModelo>salas, string nombreGrupo, string nombreMateria) {
            string nombreAnfitron;
            string nombreDocente = traemeEstaPersona(salas[0].docenteCi.ToString());
            foreach(SalaModelo s in salas) {
                nombreAnfitron = traemeEstaPersona(s.anfitrion.ToString());

                table.Rows.Add(
                    s.idSala,
                    s.idGrupo,
                    s.idMateria,
                    s.docenteCi,
                    s.anfitrion,
                    nombreGrupo,
                    nombreMateria,
                    nombreDocente,
                    nombreAnfitron,
                    s.resumen,
                    s.isDone,
                    s.creacion);
            }
            
        }
        private static void loadTableColumns(DataTable table)
        {
            //hidden
            table.Columns.Add("idSala");
            table.Columns.Add("idGrupo");
            table.Columns.Add("idMateria");
            table.Columns.Add("docenteCi");
            table.Columns.Add("anfitrion");
            //visible
            table.Columns.Add("Grupo");
            table.Columns.Add("Materia");
            table.Columns.Add("Docente");
            table.Columns.Add("Anfitrion de chat");
            table.Columns.Add("resumen");
            table.Columns.Add("isDone");
            table.Columns.Add("creacion");

        }

        public static List<List<string>> getMensajesDeSala(int idSala) {
            List<List<string>> listaDeMsgString = new List<List<string>>();
            List<string> msgString = new List<string>();
            List<SalaMensajeModelo> listaDeMsg = new SalaMensajeModelo(Session.type).getMensajesDeSala(idSala,Session.type);
            /*
            los datos cargados a la lista son los siguientes:  

         int idSala;
         int idMensaje;
         int autorCi;
         string contenido;
         DateTime fechaHora;
         string nombre apellido;
             */
            string nombreApellido;
            foreach (SalaMensajeModelo mensaje in listaDeMsg) {
                msgString = mensaje.toStringList();
                nombreApellido = traemeEstaPersona(mensaje.autorCi.ToString());
                msgString.Add(nombreApellido);
                listaDeMsgString.Add(msgString);
                //Console.WriteLine($"\nidSala:{mensaje.idSala}\tidMensaje:{mensaje.idMensaje}\tautorCi:{mensaje.autorCi}\ncontenido: {mensaje.contenido}");
            }
            
            return listaDeMsgString;
        }

        public static void enviarMensajeChat(int idSala, int autorCi, string contenido, DateTime fecha) {
            SalaMensajeModelo msg = new SalaMensajeModelo(Session.type);
            msg.idSala = idSala;
            msg.autorCi = autorCi;
            msg.contenido = contenido;
            msg.fechaHora = fecha;
            msg.enviarMensaje();
        }


        public static int getSalaCount() {
            int salasDePersona = 0;
            for (int i = 0; i < Session.grupoMaterias.Count; i++)
                salasDePersona = salasDePersona + new SalaModelo(Session.type).salaPorMateriaCount(int.Parse(Session.grupoMaterias[i][2]),Session.type);
            return salasDePersona;
        }

        public static int getMensajesDeSalaCount(int idSala) =>  new SalaMensajeModelo(Session.type).getMensajesDeSalaCount(idSala,Session.type);
        
    }
}
