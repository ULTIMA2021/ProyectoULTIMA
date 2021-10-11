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
        string idOrientacion;
        List<string> takenGroup = new List<string>();
        List<List<string>> gruposDeEstaOrientacion;          //[0]=idGrupo   [1]=idMat   [2]=nombreGrupo   [3]=nombremat
        List<string> todosMisGrupos;                     //formato, con 3 espacios: "{idGrupo}   {nombreGrupo}"
        char[] seperator = { ' ', ' ', ' ' };

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
            dgvListarOrientaciones.Columns["id"].Visible = false;
            clbGrupos.ClearSelected();
        }
        private void loadAllGrupos()
        {
            clbGrupos.DataSource = null;
            todosMisGrupos = Controlador.gruposToListForRegister();
            clbGrupos.DataSource = todosMisGrupos;
        }
        private void loadGruposOfSelectedOrientacion(string idOrientacion) => gruposDeEstaOrientacion = Controlador.gruposDeOrientacion(idOrientacion);

        private void sacarGrupoDeOrientacion()
        {
            for (int z = 0; z < clbGrupos.Items.Count; z++)
            {
                if (!clbGrupos.CheckedItems.Contains(clbGrupos.Items[z]))
                {
                    int uncheckedIdGrupo = int.Parse(clbGrupos.Items[z].ToString().Split(seperator)[0]);
                    Console.WriteLine($"The group with ID:{uncheckedIdGrupo} will get deleted from orientacion_tiene_grupo");
                    Controlador.sacarGrupoOrientacion(int.Parse(idOrientacion), uncheckedIdGrupo);
                }
            }
        }
        private void cargarGrupoAOrientacion(List<int> selectedGrupoIds)
        {
            for (int i = 0; i < selectedGrupoIds.Count; i++)
                try
                {
                    Controlador.asignarGruposAOrientacion(idOrientacion, selectedGrupoIds[i].ToString());
                }
                catch (Exception ex)
                {
                    if (ex.Message != "Grupo-1062")
                        throw ex;
                    else
                        takenGroup.Add(selectedGrupoIds[i].ToString());
                }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<int> gruposSeleccionados = getIdsFromText();
            string nombreOrientacion = textBox1.Text;
            takenGroup.Clear();
            if (cbModificar.Checked)
            {
                try
                {
                    Controlador.actualizarNombreOrientacion(textBox1.Text, idOrientacion);
                    sacarGrupoDeOrientacion();
                    cargarGrupoAOrientacion(gruposSeleccionados);
                    if (takenGroup.Count > 0)
                    {
                        string groups = "\n";
                        foreach (var item in takenGroup)
                        {
                            groups = $"{groups} \n{clbGrupos.Items[int.Parse(item)-1].ToString()}";
                        }
                        MessageBox.Show($"Los siguientes grupos ya estan cargados:{groups}");
                        textBox1.Clear();
                        uncheckAllBoxes();
                        dgvListarOrientaciones.DataSource = null;
                        clbGrupos.DataSource = null;
                        listarOrientaciones_Load_1(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(Controlador.errorHandler(ex));
                }
            }
            else
                try
                {
                    Controlador.nuevaOrientacion(nombreOrientacion);
                    string idOrientacion = Controlador.orientacionPorNombre(nombreOrientacion);
                    if (clbGrupos.SelectedIndices.Count > 0)
                        Controlador.asignarOrientacionesAGrupos(gruposSeleccionados, idOrientacion);

                    textBox1.Clear();
                    uncheckAllBoxes();
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

        private void uncheckAllBoxes()
        {
            foreach (int i in clbGrupos.CheckedIndices)
                clbGrupos.SetItemCheckState(i, CheckState.Unchecked);
        }
        private void checkBoxes()
        {
            for (int i = 0; i < gruposDeEstaOrientacion.Count; i++)
                for (int x = 0; x < todosMisGrupos.Count; x++)
                    if (todosMisGrupos[x].Split(seperator)[0] == gruposDeEstaOrientacion[i][0])
                        clbGrupos.SetItemCheckState(x, CheckState.Checked);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                Controlador.deleteOrientacion(dgvListarOrientaciones.CurrentRow.Cells["id"].Value.ToString());
                DialogResult confirmLogout = MessageBox.Show("Realmente desea borrar la orientacion?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == confirmLogout)
                {
                    Console.WriteLine("...OK setting orientacion isDeleted=true");
                    textBox1.Clear();
                    uncheckAllBoxes();
                    dgvListarOrientaciones.DataSource = null;
                    dgvListarOrientaciones.DataSource = Controlador.obtenerOrientaciones();
                    dgvListarOrientaciones.Columns["id"].Visible = false;
                    clbGrupos.ClearSelected();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
        }

        private void cbModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificar.Checked)
            {
                btnBorrar.Enabled = true;
                dgvListarOrientaciones.ClearSelection();
                dgvListarOrientaciones.Enabled = true;
                groupBox1.Text = "Modificar orientacion";
                btnIngresar.Text = "Guardar cambios";
            }
            else
            {
                btnBorrar.Enabled = false;
                textBox1.Clear();
                dgvListarOrientaciones.Enabled = false;
                clbGrupos.ClearSelected();
                dgvListarOrientaciones.ClearSelection();
                uncheckAllBoxes();
                groupBox1.Text = "Ingresar nueva orientacion";
                btnIngresar.Text = "Ingresar";
            }
        }
       
        private void dgvListarOrientaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (cbModificar.Checked)
            {
                loadAllGrupos();
                idOrientacion = dgvListarOrientaciones.CurrentRow.Cells["id"].Value.ToString();
                loadGruposOfSelectedOrientacion(idOrientacion);
                textBox1.Text = dgvListarOrientaciones.CurrentRow.Cells["Orientaciones"].Value.ToString();
                checkBoxes();
            }
        }
    }
}

