using System;
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
    public partial class listarMaterias : Form
    {
        public listarMaterias() => InitializeComponent();
        

        private void listarMaterias_Load(object sender, EventArgs e)
        {
            clbGrupos.DataSource = Controlador.gruposToListForRegister();
            dgvListarMaterias.DataSource = Controlador.obtenerMaterias();

            clbGrupos.ClearSelected();
        }

        private void btnExit_Click_1(object sender, EventArgs e) => this.Dispose();
        
        //private List<int> getIndexesMateriaChecklist()
        //{
        //    List<int> checkedIndexes = new List<int>();
        //    int index;
        //    foreach (var item in clbGrupos.CheckedItems)
        //    {
        //        index = clbGrupos.Items.IndexOf(item) + 1;
        //        checkedIndexes.Add(index);
        //    }

        //    return checkedIndexes;
        //}

        private List<int> getIdsFromText()
        {
            List<int> actualId = new List<int>();
            char[] seperator = { ' ', ' ', ' ' };
            for (int i = 0; i < clbGrupos.CheckedItems.Count; i++)
            {
                actualId.Add(int.Parse(clbGrupos.CheckedItems[i].ToString().Split(seperator)[0]));
            }
            return actualId;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<int> gruposSeleccionados = getIdsFromText();
            string nombreMateria = textBox1.Text;
            try
            {
                Controlador.nuevaMateria(nombreMateria);
                string idMateria = Controlador.MateriaPorNombreMateria(nombreMateria);
                if (clbGrupos.SelectedIndices.Count > 0)
                    Controlador.asignarMateriasAGrupo(gruposSeleccionados, int.Parse(idMateria));

                textBox1.Clear();
                foreach (int i in clbGrupos.CheckedIndices)
                    clbGrupos.SetItemCheckState(i, CheckState.Unchecked);

                dgvListarMaterias.DataSource = null;
                dgvListarMaterias.DataSource = Controlador.obtenerMaterias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
        }

        private void dgvListarMaterias_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) => dgvListarMaterias.ClearSelection();
        
    }
}
