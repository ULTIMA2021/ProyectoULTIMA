﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CapaLogica;


namespace AppAdmin.menuScreens
{
    public partial class listarMaterias : Form
    {
        List<List<string>> gruposDeEstaMateria;          //[0]=idGrupo   [1]=idMat   [2]=nombreGrupo   [3]=nombremat
        List<string> todosMisGrupos;                     //formato, con 3 espacios: "{idGrupo}   {nombreGrupo}"
        char[] seperator = { ' ', ' ', ' ' };
        string idMateria;

        public listarMaterias() => InitializeComponent();

        private List<int> getIdsFromText()
        {
            List<int> actualId = new List<int>();
            for (int i = 0; i < clbGrupos.CheckedItems.Count; i++)
            {
                actualId.Add(int.Parse(clbGrupos.CheckedItems[i].ToString().Split(seperator)[0]));
            }
            return actualId;
        }

        private void btnExit_Click_1(object sender, EventArgs e) => this.Dispose();
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            DialogResult confirmLogout = MessageBox.Show($"Esta seguro que quiere borrar la materia {textBox1.Text} ?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == confirmLogout)
            {
                try
                {
                    Controlador.deleteMateria(idMateria);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(Controlador.errorHandler(ex));
                }
            }
            //try
            //{
            //    Controlador.deleteMateria(idMateria);
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message == "set materia isDeleted=TRUE-1644")
            //    {
            //        Console.WriteLine("...OK setting materia isDeleted=true");
            //        Controlador.actualizarEstadoMateria(true, idMateria);
            //        Controlador.actualizarGrupoTieneMateria(int.Parse(idMateria), true);
            //        Controlador.updateEstadoSala(idMateria, true,1);
            //        Controlador.actualizarDocenteDictaGM(int.Parse(idMateria), true);
            //    }
            //    else
            //        MessageBox.Show(Controlador.errorHandler(ex));
            //}
            textBox1.Clear();
            uncheckAllBoxes();
            dgvListarMaterias.DataSource = null;
            dgvListarMaterias.DataSource = Controlador.obtenerMateriass();
            dgvListarMaterias.Columns[0].Visible = false;

            dgvListarMaterias.ClearSelection();
            clbGrupos.ClearSelected();
            MessageBox.Show($"La materia {textBox1.Text} se borro del sistema!");

            btnBorrar.Enabled = false;
            btnIngresar.Enabled = false;
            btnArchivar.Enabled = false;

            this.Enabled = true;
        }
        private void btnArchivar_Click(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                Controlador.actualizarEstadoMateria(true, idMateria);
                Controlador.actualizarGrupoTieneMateria(int.Parse(idMateria), true);
                Controlador.updateEstadoSala(idMateria, true, 1);
                Controlador.actualizarDocenteDictaGM(int.Parse(idMateria), true);
                MessageBox.Show("Materia archivada!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
            textBox1.Clear();
            uncheckAllBoxes();
            dgvListarMaterias.DataSource = null;
            dgvListarMaterias.DataSource = Controlador.obtenerMateriass();
            dgvListarMaterias.Columns[0].Visible = false;
            dgvListarMaterias.ClearSelection();
            clbGrupos.ClearSelected();

            btnBorrar.Enabled = false;
            btnIngresar.Enabled = false;
            btnArchivar.Enabled = false;

            Enabled = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            List<int> gruposSeleccionados = getIdsFromText();
            string nombreMateria = textBox1.Text;
            if (cbModificar.Checked)
            {
                try
                {
                    idMateria = dgvListarMaterias.CurrentRow.Cells[0].Value.ToString();
                    Controlador.actualizarNombreMateria(textBox1.Text, idMateria);
                    sacarGrupoDeMateria();
                    cargarGrupoAmateria(gruposSeleccionados);

                    textBox1.Clear();
                    uncheckAllBoxes();

                    dgvListarMaterias.DataSource = null;
                    dgvListarMaterias.DataSource = Controlador.obtenerMateriass();
                    dgvListarMaterias.Columns[0].Visible = false;

                    dgvListarMaterias.ClearSelection();
                    clbGrupos.ClearSelected();
                    MessageBox.Show($"Datos actualizados para la materia {nombreMateria}!");
                    btnBorrar.Enabled = false;
                    btnIngresar.Enabled = false;
                    btnArchivar.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Controlador.errorHandler(ex));
                }

            }
            else
                try
                {
                    Controlador.nuevaMateria(nombreMateria);
                    idMateria = Controlador.MateriaPorNombreMateria(nombreMateria);
                    if (clbGrupos.SelectedIndices.Count > 0)
                        Controlador.asignarMateriasAGrupo(gruposSeleccionados, int.Parse(idMateria));

                    dgvListarMaterias.DataSource = null;
                    dgvListarMaterias.DataSource = Controlador.obtenerMateriass();
                    textBox1.Clear();
                    uncheckAllBoxes();
                    dgvListarMaterias.Columns[0].Visible = false;
                    MessageBox.Show($"La materia {nombreMateria} ha sido Ingresada al sistema!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(Controlador.errorHandler(ex));
                }
            this.Enabled = true;
            clbGrupos.ClearSelected();
        }
        private void sacarGrupoDeMateria()
        {
            for (int z = 0; z < clbGrupos.Items.Count; z++)
            {
                if (!clbGrupos.CheckedItems.Contains(clbGrupos.Items[z]))
                {
                    int uncheckedIdGrupo = int.Parse(clbGrupos.Items[z].ToString().Split(seperator)[0]);
                    Console.WriteLine($"The group with ID:{uncheckedIdGrupo} will get deleted from grupoTieneMateria");
                    try
                    {
                        Controlador.sacarGrupoMateria(int.Parse(idMateria), uncheckedIdGrupo);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "cannot delete grupoTieneMateria-1644")
                        {
                            Controlador.actualizarGrupoTieneMateria(idMateria, uncheckedIdGrupo.ToString(), true);
                            Controlador.updateEstadoSala(idMateria, uncheckedIdGrupo.ToString(), true);
                            Controlador.actualizarDocenteDictaGM(idMateria, uncheckedIdGrupo.ToString(), true);
                        }
                    }
                }
            }
        }
        private void cargarGrupoAmateria(List<int> selectedGrupoIds)
        {
            for (int i = 0; i < selectedGrupoIds.Count; i++)
            {
                try
                {
                    Controlador.asignarMateriasAGrupo(idMateria, selectedGrupoIds[i].ToString());
                }
                catch (Exception ex)
                {
                    if (ex.Message == "isDeleted set to FALSE docenteDictaGM-1644")
                        Controlador.actualizarGrupoTieneMateria(idMateria, selectedGrupoIds[i].ToString(), false);
                }
            }
        }

        private void checkBoxes()
        {
            for (int i = 0; i < gruposDeEstaMateria.Count; i++)
                for (int x = 0; x < todosMisGrupos.Count; x++)
                    if (todosMisGrupos[x].Split(seperator)[0] == gruposDeEstaMateria[i][0])
                        clbGrupos.SetItemCheckState(x, CheckState.Checked);
        }
        private void uncheckAllBoxes()
        {
            for (int i = 0; i < clbGrupos.Items.Count; i++)
                clbGrupos.SetItemCheckState(i, CheckState.Unchecked);
        }

        private void listarMaterias_Load(object sender, EventArgs e)
        {
            try
            {
                loadAllGrupos();
                dgvListarMaterias.DataSource = Controlador.obtenerMateriass();
                dgvListarMaterias.Columns[0].Visible = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
  
            clbGrupos.ClearSelected();
        }
        private void loadAllGrupos()
        {
            clbGrupos.DataSource = null;
            todosMisGrupos = Controlador.gruposToListForRegister();
            clbGrupos.DataSource = todosMisGrupos;
        }
        private void loadGruposOfSelectedMateria(string idMateria) => gruposDeEstaMateria = Controlador.gruposDeMateria(idMateria);
        private void cbModificar_CheckedChanged(object sender, EventArgs e)
        {
            Enabled = false;
            if (cbModificar.Checked)
            {
                btnBorrar.Visible = true;
                btnArchivar.Visible = true;
                btnIngresar.Enabled = false;

                dgvListarMaterias.ClearSelection();
                dgvListarMaterias.Enabled = true;
                btnArchivar.Visible = true;
                gbMaterias.Text = "Modificar materia";
                btnIngresar.Text = "Guardar";
            }
            else
            {
                btnArchivar.Visible = false;
                btnArchivar.Enabled = false;

                btnBorrar.Visible = false;
                btnBorrar.Enabled = false;

                btnIngresar.Enabled = true;

                textBox1.Clear();
                dgvListarMaterias.Enabled = false;
                clbGrupos.ClearSelected();
                dgvListarMaterias.ClearSelection();
                uncheckAllBoxes();
                gbMaterias.Text = "Ingresar nueva Materia";
                btnIngresar.Text = "Ingresar";
            }
            Enabled = true;
        }

        private void dgvListarMaterias_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) => dgvListarMaterias.ClearSelection();
        private void dgvListarMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Enabled = false;
            if (cbModificar.Checked)
            {
                loadAllGrupos();
                idMateria = dgvListarMaterias.CurrentRow.Cells[0].Value.ToString();
                loadGruposOfSelectedMateria(idMateria);
                textBox1.Text = dgvListarMaterias.CurrentRow.Cells["Materia"].Value.ToString();
                checkBoxes();
                btnBorrar.Enabled = true;
                btnArchivar.Enabled = true;
                btnIngresar.Enabled = true;
            }
            Enabled = true;
        }

    }
}
