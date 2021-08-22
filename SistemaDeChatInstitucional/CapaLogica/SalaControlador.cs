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
        public static void nuevaSala(
            string idGrupo,
            string idMateria,
            string docente,
            string anfitrion,
            string resumen,
            DateTime fechaHora){
            SalaModelo sala = new SalaModelo(Session.type);
            sala.idGrupo = int.Parse(idGrupo);
            sala.idMateria = int.Parse(idMateria);
            if (string.IsNullOrEmpty(docente))
                docente = new GrupoModelo(Session.type).getDocenteDictaGM(idGrupo, idMateria, Session.type).ToString();
            sala.docenteCi = int.Parse(docente);
            sala.anfitrion = int.Parse(anfitrion);
            sala.resumen = resumen;
            sala.creacion = fechaHora;
            
            sala.crearSala();
        }

        public static void finalizarSala(int idSala) => new SalaModelo(Session.type).salaFinalizada(idSala);

        public static DataTable loadSalasDePersona() {
            List<SalaModelo> salasPorGM = new List<SalaModelo>();
            DataTable salasDataTable = new DataTable();
            loadTableColumns(salasDataTable);
            int idGrupo;
            int idMateria;
            for (int x = 0; x < Session.grupoMaterias.Count; x++) {
                idGrupo = int.Parse(Session.grupoMaterias[x][0]);
                idMateria = int.Parse(Session.grupoMaterias[x][2]);               
                salasPorGM.AddRange(new SalaModelo(Session.type).salaPorGrupoMateria(idGrupo, idMateria, Session.type)); 
            }
            salasPorGM.Sort((y, z) => DateTime.Compare(z.creacion, y.creacion));
            loadSalasToDataTable(salasDataTable, salasPorGM);
            

            return salasDataTable;
        }

        private static void loadSalasToDataTable(DataTable table, List<SalaModelo>salas) {
            string nombreAnfitron;
            string nombreGrupo="";
            string nombreMateria="";
            string nombreDocente;// = traemeEstaPersona(salas[0].docenteCi.ToString());
            int counter=0;
            foreach(SalaModelo s in salas) {
                nombreAnfitron = traemeEstaPersona(s.anfitrion.ToString());
                nombreDocente = traemeEstaPersona(s.docenteCi.ToString());

                for (int i = 0; i < Session.grupoMaterias.Count; i++)
                {
                    if (s.idGrupo.ToString() == Session.grupoMaterias[i][0] && s.idMateria.ToString() == Session.grupoMaterias[i][2])
                    {
                        nombreGrupo = Session.grupoMaterias[i][1];
                        nombreMateria = Session.grupoMaterias[i][3];
                        break;
                    }
                }
                
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
            counter++;
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
        /*
        los datos cargados a getMensajesDeSala siguen este orden y son los siguientes:
        int idSala;
        int idMensaje;
        int autorCi
        string contenido;
        DateTime fechaHora;
        string nombre apellido;
         */
        public static List<List<string>> getMensajesDeSala(int idSala) {
            List<List<string>> listaDeMsgString = new List<List<string>>();
            List<string> msgString = new List<string>();
            List<SalaMensajeModelo> listaDeMsg = new SalaMensajeModelo(Session.type).getMensajesDeSala(idSala,Session.type);
        
            string nombreApellido;
            foreach (SalaMensajeModelo mensaje in listaDeMsg) {
                msgString = mensaje.toStringList();
                nombreApellido = traemeEstaPersona(mensaje.autorCi.ToString());
                msgString.Add(nombreApellido);
                listaDeMsgString.Add(msgString);
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

        public static List<List<string>> getPersonasEnSala(string idSala) {
            List<SalaMembersModelo> memberList = new SalaMembersModelo(Session.type).getSalaMembers(idSala,Session.type);
            List<List<string>> memberListString = new List<List<string>>();
            foreach (SalaMembersModelo member in memberList) {

                List<string> memberString = member.toStringList();
                memberString.Add(traemeEstaPersona(member.ci.ToString()));

                memberListString.Add(memberString);
            }
            memberListString.Sort((a, b) => a[2].CompareTo(b[2]));

            return memberListString;
        }
        /*
        public static List<List<string>> getPersonasEnSala1(string idSala)
        {
            List<SalaMembersModelo> onMemberList = new SalaMembersModelo(Session.type).getSalaMembers(idSala,true, Session.type);
            List<List<string>> onMemberListString = new List<List<string>>();
            foreach (SalaMembersModelo member in onMemberList)
            {
                List<string> memberString = member.toStringList();
                memberString.Add(traemeEstaPersona(member.ci.ToString()));

                onMemberListString.Add(memberString);
            }

            onMemberListString.Sort((a, b) => a[2].CompareTo(b[2]));
            return onMemberListString;
        }
        public static List<List<string>> getPersonasNoEnSala(string idSala)
        {
            List<SalaMembersModelo> offMemberList = new SalaMembersModelo(Session.type).getSalaMembers(idSala, false, Session.type);
            List<List<string>> offMemberListString = new List<List<string>>();
            foreach (SalaMembersModelo member in offMemberList)
            {
                List<string> memberString = member.toStringList();
                memberString.Add(traemeEstaPersona(member.ci.ToString()));

                offMemberListString.Add(memberString);
            }

            offMemberListString.Sort((a, b) => a[2].CompareTo(b[2]));
            return offMemberListString;
        }
        */
        public static int getPersonasEnSalaCount(string idSala,bool isConnected) => new SalaMembersModelo(Session.type).getSalaMembersCount(idSala,isConnected);
       
        public static void updateSalaConnection(string idSala,bool isConnected) => new SalaMembersModelo(Session.type).updateIsConnected(Session.cedula,idSala,isConnected);
    }
}
