﻿using System;
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


                Console.WriteLine($"idgrupo: {idGrupo} idMateria: {idMateria}");
                salas = sala.salaPorGrupoMateria(idGrupo,idMateria, Session.type);
                loadSalasToDataTable(salasDataTable, salas,nombregrupo,nombreMateria);
            }

            return salasDataTable;
        }
        // se van cargando por grupo materia
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
    }
}
