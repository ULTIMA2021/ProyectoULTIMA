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
    public partial class listarOrientaciones : Form
    {
        public listarOrientaciones() => InitializeComponent();
        private void btnExit_Click(object sender, EventArgs e) => this.Dispose();
        

        private List<int> getIdsFromText()
        {
            List<int> actualId = new List<int>();
            char[] seperator = {' ',' ',' '};
            for (int i = 0; i < clbGrupos.CheckedItems.Count ; i++)
            {
                actualId.Add(int.Parse(clbGrupos.CheckedItems[i].ToString().Split(seperator)[0]));
            }
            return actualId;
        }

        private void listarOrientaciones_Load_1(object sender, EventArgs e)
        {
            clbGrupos.DataSource = Controlador.gruposSinOrientacion();
            dgvListarOrientaciones.DataSource = Controlador.obtenerOrientaciones();

            clbGrupos.ClearSelected();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<int> gruposSeleccionados = getIdsFromText();
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

                dgvListarOrientaciones.DataSource = null;
                clbGrupos.DataSource = null;
                listarOrientaciones_Load_1(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
        }

        private void dgvListarOrientaciones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) => dgvListarOrientaciones.ClearSelection();

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }
    }
}
