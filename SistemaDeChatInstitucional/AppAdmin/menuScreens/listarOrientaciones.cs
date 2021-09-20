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
    public partial class listarOrientaciones : Form
    {
        public listarOrientaciones()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<int> getIndexesMateriaChecklist()
        {
            List<int> checkedIndexes = new List<int>();
            int index;
            foreach (var item in clbGrupos.CheckedItems)
            {
                index = clbGrupos.Items.IndexOf(item) + 1;
                checkedIndexes.Add(index);
            }

            return checkedIndexes;
        }

        private void listarOrientaciones_Load_1(object sender, EventArgs e)
        {
            clbGrupos.DataSource = Controlador.gruposToListForRegister();
            dgvListarOrientaciones.DataSource = Controlador.obtenerOrientaciones();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<int> gruposSeleccionados = getIndexesMateriaChecklist();
            string nombreOrientacion = textBox1.Text;
            try
            {
                Controlador.nuevaOrientacion(nombreOrientacion);
                string idOrientacion = Controlador.orientacionPorNombre(nombreOrientacion);
                if (clbGrupos.SelectedIndices.Count > 0)
                    Controlador.asignarOrientacionesAGrupos(gruposSeleccionados, idOrientacion);

                textBox1.Clear();
                foreach (int i in clbGrupos.CheckedIndices)
                    clbGrupos.SetItemCheckState(i, CheckState.Unchecked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
        }
    }
}
