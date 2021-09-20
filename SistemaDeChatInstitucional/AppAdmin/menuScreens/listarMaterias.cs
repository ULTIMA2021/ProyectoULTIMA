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
        public listarMaterias()
        {
            InitializeComponent();
        }

        private void listarMaterias_Load(object sender, EventArgs e)
        {
            clbGrupos.DataSource = Controlador.gruposToListForRegister();
            dgvListarMaterias.DataSource = Controlador.obtenerMaterias();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
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

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<int> gruposSeleccionados = getIndexesMateriaChecklist();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
        }
    }
}
