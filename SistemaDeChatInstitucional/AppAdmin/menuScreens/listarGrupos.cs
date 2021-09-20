﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace AppAdmin.menuScreens
{
    public partial class listarGrupos : Form
    {
        public listarGrupos()
        {
            InitializeComponent();
            clbMaterias.ClearSelected();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listarGrupos_Load(object sender, EventArgs e)
        {
            clbMaterias.DataSource = Controlador.MateriasToListForRegister();
            dgvListarGrupos.DataSource = Controlador.obtenerGrupos();
        }

        private List<int> getIndexesMateriaChecklist()
        {
            List<int> checkedIndexes = new List<int>();
            int index;
                foreach (var item in clbMaterias.CheckedItems)
                {
                    index = clbMaterias.Items.IndexOf(item) + 1;
                    checkedIndexes.Add(index);
                    Console.WriteLine($" item: {item}   index of item in database:{ index}");
                }
            
            return checkedIndexes;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<int> materiasSeleccionadas = getIndexesMateriaChecklist();
            string nombreGrupo = textBox1.Text;
            try
            {
                Controlador.nuevoGrupo(nombreGrupo);
                string idGrupo = Controlador.grupoPorNombreGrupo(nombreGrupo);
                Console.WriteLine($"THE GROUP ID IN THE SYSTEM IS {idGrupo}");
                if (clbMaterias.SelectedIndices.Count > 0)
                    Controlador.asignarMateriasAGrupo(materiasSeleccionadas, idGrupo);

                textBox1.Clear();
                foreach (int i in clbMaterias.CheckedIndices)
                    clbMaterias.SetItemCheckState(i, CheckState.Unchecked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
        }
    }
}
