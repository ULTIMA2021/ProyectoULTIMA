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
        //bool modify = false;

        // List<int> oldMaterias = new List<int>();

        List<List<string>> materiaDeEsteGrupo;          //[0]=idGrupo   [1]=idMat   [2]=nombreGrupo   [3]=nombremat
        List<string> todasMisMaterias;                  //formato, con 3 espacios: "{idGrupo}   {nombreGrupo}"
        char[] seperator = { ' ', ' ', ' ' };
        string idGrupo;
        public listarGrupos() => InitializeComponent();
        private void btnExit_Click(object sender, EventArgs e) => this.Dispose();


        private void listarGrupos_Load(object sender, EventArgs e)
        {
            clbMaterias.DataSource = Controlador.MateriasToListForRegister();
            dgvListarGrupos.DataSource = Controlador.obtenerGrupos();
            dgvListarGrupos.Columns[0].Visible = false;

            clbMaterias.ClearSelected();
        }

        private List<int> getIdsFromClb()
        {
            List<int> actualId = new List<int>();
            for (int i = 0; i < clbMaterias.CheckedItems.Count; i++)
                actualId.Add(int.Parse(clbMaterias.CheckedItems[i].ToString().Split(seperator)[0]));

            return actualId;
        }
        private void sacarMateriasDeGrupo()
        {
            for (int z = 0; z < clbMaterias.Items.Count; z++)
            {
                if (!clbMaterias.CheckedItems.Contains(clbMaterias.Items[z]))
                {
                    int uncheckedIdMateria = int.Parse(clbMaterias.Items[z].ToString().Split(seperator)[0]);
                    Console.WriteLine($"The group with ID:{uncheckedIdMateria} will get deleted from grupoTieneMateria");
                    try
                    {
                        Controlador.sacarGrupoMateria(uncheckedIdMateria, int.Parse(idGrupo));
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "cannot delete grupoTieneMateria-1644")
                        {
                            Controlador.actualizarGrupoTieneMateria(uncheckedIdMateria.ToString(), idGrupo, true);
                            Controlador.updateEstadoSala(uncheckedIdMateria.ToString(), idGrupo, true);
                            Controlador.actualizarDocenteDictaGM(uncheckedIdMateria.ToString(), idGrupo, true);
                        }
                    }
                }
            }
        }
        private void cargarMateriasAGrupo(List<int> selectedMateriaIds)
        {
            for (int i = 0; i < selectedMateriaIds.Count; i++)
            {
                try
                {
                    Controlador.asignarMateriasAGrupo(selectedMateriaIds[i].ToString(), idGrupo);
                }
                catch (Exception ex)
                {
                    if (ex.Message == "isDeleted set to FALSE docenteDictaGM-1644")
                        Controlador.actualizarGrupoTieneMateria(selectedMateriaIds[i].ToString(), idGrupo, false);
                }
            }

        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<int> materiasSeleccionadas = getIdsFromClb();
            string nombreGrupo = textBox1.Text;

            if (cbModificar.Checked)
            {

                try
                {
                    idGrupo = dgvListarGrupos.CurrentRow.Cells["idGrupo"].Value.ToString();
                    Controlador.actualizarNombreGrupo(nombreGrupo, idGrupo);
                    sacarMateriasDeGrupo();
                    cargarMateriasAGrupo(materiasSeleccionadas);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(Controlador.errorHandler(ex));
                }
            
            }
            else
            {
                try
                {
                    Controlador.nuevoGrupo(nombreGrupo);
                    idGrupo = Controlador.grupoPorNombreGrupo(nombreGrupo);
                    Console.WriteLine($"THE GROUP ID IN THE SYSTEM IS {idGrupo}");
                    if (clbMaterias.SelectedIndices.Count > 0)
                        Controlador.asignarMateriasAGrupo(materiasSeleccionadas, idGrupo);

                    textBox1.Clear();
                    uncheckAllBoxes();
                    dgvListarGrupos.DataSource = null;
                    dgvListarGrupos.DataSource = Controlador.obtenerGrupos();
                    clbMaterias.ClearSelected();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Controlador.errorHandler(ex));
                }
            }
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
                loadAllMaterias();
                idGrupo = dgvListarGrupos.CurrentRow.Cells[0].Value.ToString();
                loadMateriasOfSelectedGrupo(idGrupo);
                textBox1.Text = dgvListarGrupos.CurrentRow.Cells["Grupos"].Value.ToString();
                checkBoxes();
            }
        }

        private void loadMateriasOfSelectedGrupo(string idGrupo) => materiaDeEsteGrupo = Controlador.gruposDeMateria(int.Parse(idGrupo));

        private void loadAllMaterias()
        {
            clbMaterias.DataSource = null;
            todasMisMaterias = Controlador.MateriasToListForRegister();
            clbMaterias.DataSource = todasMisMaterias;
        }

        //private void loadMateriasForModificacion()
        //{
        //    clbMaterias.DataSource = null;
        //    string idGrupo= dgvListarGrupos.CurrentRow.Cells["idGrupo"].Value.ToString();
        //    string nombreGrupo = dgvListarGrupos.CurrentRow.Cells["Grupos"].Value.ToString();

        //    if (fuckingcounter > 0 && Controlador.validarGrupo(idGrupo, nombreGrupo))
        //    {
        //    idGrupo = dgvListarGrupos.CurrentRow.Cells["idGrupo"].Value.ToString();
        //    clbMaterias.DataSource = Controlador.MateriasToListForRegister();
        //        foreach (int item in Controlador.obtenerMaterias(idGrupo))
        //        {
        //            clbMaterias.SetItemChecked(item, true);
        //        }
        //    }
        //    clbMaterias.ClearSelected();
        //    fuckingcounter++;
        //}

        private void cbModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificar.Checked)
            {
                dgvListarGrupos.ClearSelection();
                dgvListarGrupos.Enabled = true;
                groupBox1.Text = "Modificar grupo";
                btnIngresar.Text = "Guardar cambios";
            }
            else
            {
                textBox1.Clear();
                dgvListarGrupos.Enabled = false;
                clbMaterias.ClearSelected();
                dgvListarGrupos.ClearSelection();
                uncheckAllBoxes();
                groupBox1.Text = "Ingresar nuevo grupo";
                btnIngresar.Text = "Ingresar";
            }
        }

        private void checkBoxes()
        {
            for (int i = 0; i < materiaDeEsteGrupo.Count; i++)
                for (int x = 0; x < todasMisMaterias.Count; x++)
                    if (todasMisMaterias[x].Split(seperator)[0] == materiaDeEsteGrupo[i][1])
                        clbMaterias.SetItemCheckState(x, CheckState.Checked);
        }
        private void uncheckAllBoxes()
        {
            for (int i = 0; i < clbMaterias.Items.Count; i++)
                clbMaterias.SetItemCheckState(i, CheckState.Unchecked);
        }
    }
}
