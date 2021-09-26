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
    public partial class listarMaterias : Form
    {
        List<List<string>> gruposDeEstaMateria;          //[0]=idGrupo   [1]=idMat   [2]=nombreGrupo   [3]=nombremat
        List<string> todosMisGrupos;                     //formato, con 3 espacios: "{idGrupo}   {nombreGrupo}"
        char[] seperator = { ' ', ' ', ' ' };
        string idMateria;

        public listarMaterias() => InitializeComponent();
        

        private void listarMaterias_Load(object sender, EventArgs e)
        {
            loadAllGrupos();
            dgvListarMaterias.DataSource = Controlador.obtenerMateriass();
            dgvListarMaterias.Columns[0].Visible = false;

            clbGrupos.ClearSelected();
        }

        private void btnExit_Click_1(object sender, EventArgs e) => this.Dispose();
        
        private List<int> getIdsFromText()
        {
            List<int> actualId = new List<int>();
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
            idMateria = dgvListarMaterias.CurrentRow.Cells[0].Value.ToString();
            if (cbModificar.Checked)
            {
                try
                {
                    Controlador.actualizarNombreMateria(textBox1.Text, idMateria);
                    List<int>selectedGrupoIds = getIdsFromText();


                    for (int z = 0; z < clbGrupos.Items.Count; z++)
                    {
                        if (!clbGrupos.CheckedItems.Contains(clbGrupos.Items[z]))
                        {
                            int uncheckedIdGrupo = int.Parse(clbGrupos.Items[z].ToString().Split(seperator)[0]);
                            Console.WriteLine($"The group with ID:{uncheckedIdGrupo} will get deleted from grupoTieneMateria");
                            try
                            {
                            Controlador.sacarGrupoMateria(int.Parse(idMateria),uncheckedIdGrupo);
                            }
                            catch (Exception  ex)
                            {
                                if (ex.Message == "cannot delete grupoTieneMateria-1644")
                                {
                                    Controlador.actualizarGrupoTieneMateria(idMateria, uncheckedIdGrupo.ToString() , true);
                                    Controlador.updateEstadoSala(idMateria,uncheckedIdGrupo.ToString(),true);
                                    Controlador.actualizarDocenteDictaGM(idMateria, uncheckedIdGrupo.ToString(),true );
                                }
                            }
                        }
                    }
                    for (int i = 0; i < selectedGrupoIds.Count; i++)
                    {
                        try
                        {
                            Controlador.asignarMateriasAGrupo(idMateria, selectedGrupoIds[i].ToString());
                        }
                        catch (Exception ex)
                        {
                            if(ex.Message == "isDeleted set to FALSE docenteDictaGM-1644")
                                Controlador.actualizarGrupoTieneMateria(idMateria, selectedGrupoIds[i].ToString(), false);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(Controlador.errorHandler(ex));

                }

            }
            else
            {
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
                    dgvListarMaterias.DataSource = Controlador.obtenerMateriass();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Controlador.errorHandler(ex));
                }
            }
        }

        private void dgvListarMaterias_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) => dgvListarMaterias.ClearSelection();

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

        private void loadGruposOfSelectedMateria(string idMateria) => gruposDeEstaMateria = Controlador.gruposDeMateria(idMateria);
        private void loadAllGrupos()
        {
            clbGrupos.DataSource = null;
            todosMisGrupos = Controlador.gruposToListForRegister();
            clbGrupos.DataSource = todosMisGrupos;
        }
        private void cbModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbModificar.Checked)
            {
                
                dgvListarMaterias.ClearSelection();
                dgvListarMaterias.Enabled = true;
                gbMaterias.Text = "Modificar materia";
                btnIngresar.Text = "Guardar cambios";
            }
            else
            {
                textBox1.Clear();
                dgvListarMaterias.Enabled = false;
                clbGrupos.ClearSelected();
                dgvListarMaterias.ClearSelection();
                uncheckAllBoxes();
                gbMaterias.Text = "Ingresar nueva Materia";
                btnIngresar.Text = "Ingresar";
            }
        }

        private void dgvListarMaterias_SelectionChanged(object sender, EventArgs e)
        {
            if (cbModificar.Checked)
            {
                loadAllGrupos();
                idMateria = dgvListarMaterias.CurrentRow.Cells[0].Value.ToString();
                loadGruposOfSelectedMateria(idMateria);
                textBox1.Text = dgvListarMaterias.CurrentRow.Cells["Materia"].Value.ToString();
                checkBoxes();
            }
        }
    }
}
