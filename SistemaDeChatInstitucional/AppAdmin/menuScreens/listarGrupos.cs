using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace AppAdmin.menuScreens
{
    public partial class listarGrupos : Form
    {
        bool modify = false;
        List<int> oldMaterias = new List<int>();
        int fuckingcounter = 0;
        char[] seperator = { ' ', ' ', ' ' };
        public listarGrupos() => InitializeComponent();
        private void btnExit_Click(object sender, EventArgs e) => this.Dispose();


        private void listarGrupos_Load(object sender, EventArgs e)
        {
            clbMaterias.DataSource = Controlador.MateriasToListForRegister();
            dgvListarGrupos.DataSource = Controlador.obtenerGrupos();

            clbMaterias.ClearSelected();
        }

        private List<int> getIdsFromText()
        {
            List<int> actualId = new List<int>();
            for (int i = 0; i < clbMaterias.CheckedItems.Count; i++)
                actualId.Add(int.Parse(clbMaterias.CheckedItems[i].ToString().Split(seperator)[0]));

            return actualId;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<int> materiasSeleccionadas = getIdsFromText();
            string nombreGrupo = textBox1.Text;
            if (modify)
            {

                //update grupo name 
                string idGrupo = dgvListarGrupos.CurrentRow.Cells["idGrupo"].Value.ToString();

                Controlador.actualizarNombreGrupo(nombreGrupo, idGrupo);
                string idMat="";
                foreach (int materia in materiasSeleccionadas) {
                    try
                    {
                        Controlador.asignarMateriasAGrupo(materia, idGrupo);
                    }
                    catch //foreign key constraint exc
                    { }
                    
                    for (int i = 0; i < oldMaterias.Count; i++)
                        for (int h = 0; h < clbMaterias.CheckedItems.Count; h++)
                            if (clbMaterias.CheckedIndices[h] != oldMaterias[i] && h == clbMaterias.Items.Count - 1)
                            {
                                idMat = clbMaterias.CheckedItems[clbMaterias.CheckedIndices[h]].ToString().Split(seperator)[0];
                                string countSalasDeMateria = Controlador.countSalaPorMateria(idMat);
                                Controlador.deleteMateria(int.Parse(idMat), idGrupo);
                            }
                               

                    
                }
            }
            else
            {
                try
                {
                    Controlador.nuevoGrupo(nombreGrupo);
                    string idGrupo = Controlador.grupoPorNombreGrupo(nombreGrupo);
                    Console.WriteLine($"THE GROUP ID IN THE SYSTEM IS {idGrupo}");
                    if (clbMaterias.SelectedIndices.Count > 0)
                        Controlador.asignarMateriasAGrupo(materiasSeleccionadas, idGrupo);

                    textBox1.Clear();
                    uncheckMyClb();
                    dgvListarGrupos.DataSource = null;
                    dgvListarGrupos.DataSource = Controlador.obtenerGrupos();
                    clbMaterias.ClearSelected();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Controlador.errorHandler(ex));
                }
            }
            modify = false;
            dgvListarGrupos.ClearSelection();
        }

        private void deleteGroup() {
            //get selected group id
            /*
            int affectedAlumnos = Controlador.getAlumnoPorGrupo(idGrupo);
            int affectedDocentes = Controlador.getDocentePorGrupo(idGrupo);
            int countConsulta = Controlador.getConsultasPorGrupoMateria(idGrupo,null);
            int countSala = Controlador.getSalasPorGrupoMateria(idGrupo, null);

            string text = $"Borrar el grupo {dgvListarGrupos.SelectedRows[0].ToString()} estaria afectando a: \n\t{affectedAlumnos} alumnos\n\t{affectedDocentes}docentes\n\t{countConsulta} consultas\n\t{countSala} salas\nRealmente desea continuar?";

            MessageBox.Show(text ); */
        }

        private void dgvListarGrupos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) { dgvListarGrupos.ClearSelection(); dgvListarGrupos.Columns["idGrupo"].Visible = false; }


        private void dgvListarGrupos_SelectionChanged(object sender, EventArgs e)
        {
            if (cbModificar.Checked)
            {
                loadMateriasForModificacion();
                textBox1.Text = dgvListarGrupos.CurrentRow.Cells["Grupos"].Value.ToString();
            }
        }

        private void loadMateriasForModificacion()
        {
            clbMaterias.DataSource = null;
            string idGrupo= dgvListarGrupos.CurrentRow.Cells["idGrupo"].Value.ToString();
            string nombreGrupo = dgvListarGrupos.CurrentRow.Cells["Grupos"].Value.ToString();

            if (fuckingcounter > 0 && Controlador.validarGrupo(idGrupo, nombreGrupo))
            {
            idGrupo = dgvListarGrupos.CurrentRow.Cells["idGrupo"].Value.ToString();
            clbMaterias.DataSource = Controlador.MateriasToListForRegister();
                foreach (int item in Controlador.obtenerMaterias(idGrupo))
                {
                    clbMaterias.SetItemChecked(item, true);
                    oldMaterias.Add(item);
                }
            }
            clbMaterias.ClearSelected();
            fuckingcounter++;
        }

        private void cbModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificar.Checked)
            {
                dgvListarGrupos.ClearSelection();
                dgvListarGrupos.Enabled = true;
                groupBox1.Text = "Modificar grupo";
                btnIngresar.Text = "Guardar cambios";
                loadMateriasForModificacion();
            }
            else
            {
                textBox1.Clear();
                dgvListarGrupos.Enabled = false;
                clbMaterias.ClearSelected();
                dgvListarGrupos.ClearSelection();
                uncheckMyClb();
                groupBox1.Text = "Ingresar nuevo grupo";
                btnIngresar.Text = "Ingresar";
            }
        }

        private void uncheckMyClb()
        {
            for (int i = 0; i < clbMaterias.Items.Count; i++)
                clbMaterias.SetItemChecked(i, false);
        }

    }
}
