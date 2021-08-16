using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CapaDeDatos
{
    public class SalaMembersModelo : Modelo
    {
        int idSala;
        int ci;
        bool isConnected;
        string errorType = "SalaMembers";

        public SalaMembersModelo(byte sessionType) : base(sessionType)
        {
        }
        
        //se puede poner un trigger para cuando se crea una que se haga esto para cada alumno de cada grupo
        public void insertMembers(string ci, string idSala) {
            this.comando.CommandText = "INSERT INTO Sala_Members(idSala, ci) VALUES (" +
                "@idSala,@ci);";
            this.comando.Parameters.AddWithValue("idSala", idSala);
            this.comando.Parameters.AddWithValue("ci", ci);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }

        public void updateIsConnected(string ci, string idSala,bool isConnected)
        {
            this.comando.CommandText = "UPDATE Sala_members SET isConnected=@isConnected WHERE " +
                "idSala=@idSala AND ci=@ci;";
            this.comando.Parameters.AddWithValue("idSala", idSala);
            this.comando.Parameters.AddWithValue("ci", ci);
            this.comando.Parameters.AddWithValue("isConnected", isConnected);
            this.comando.Prepare();
            EjecutarQuery(this.comando, errorType);
        }

        private List<SalaMembersModelo> cargarMembersAlist(MySqlCommand command, byte sessionType) {
            lector = command.ExecuteReader();
            List<SalaMembersModelo> personas = new List<SalaMembersModelo>();
            while (lector.Read())
            {
                SalaMembersModelo sm = new SalaMembersModelo(sessionType);
                sm.idSala = int.Parse(lector[0].ToString());
                sm.ci = int.Parse(lector[1].ToString());
                sm.isConnected = bool.Parse(lector[2].ToString());
                personas.Add(sm);
            }
            lector.Close();
            return personas;
        }

        public List<SalaMembersModelo> getSalaMembers(string idSala, byte sessionType) {
            this.comando.CommandText = "SELECT DISTINCT idSala,ci,isConnected FROM " +
                "Sala_members sm, Alumno_Tiene_Grupo ag, Docente_dicta_G_M dgm " +
                "WHERE sm.idSala=@idSala " +
                "AND (ag.alumnoCi=sm.ci OR dgm.docenteCi=sm.ci);";
            this.comando.Parameters.AddWithValue("@idSala",idSala);
            return (cargarMembersAlist(this.comando,sessionType));
        }
    }
}
