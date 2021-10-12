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
    public partial class UsuarioRegistro : Form
    {
        public UsuarioRegistro()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            comboBoxUser.SelectedIndex = 0;
            label14.Visible = true;
            pbFoto.Enabled = true;
            txtApodo.Enabled = true;
            lblApodoAst.Visible = false;
            lblOptions.Text = "Grupo/s";
            clbOpciones.DataSource = null;
            clbOpciones.DataSource = Controlador.gruposToListForRegister();
            dgvPersonas.DataSource = null;
           // dgvPersonas.DataSource = Controlador.
        }
        private void btnExit_Click(object sender, EventArgs e) => Dispose();

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //-check that correct groups and mats are being loaded, no deleted ones.
            //-If persona does exist ask if they want to reactivate acc

            if (txtClave.Text == txtClaveVerificacion.Text && txtCedula.Text.Length == 8 && comboBoxUser.SelectedIndex > 0)
            {
                if (Controlador.existePersona(txtCedula.Text))// not really needed, we just throw it at the db, no need for this
                {
                    try
                    {
                        Console.WriteLine("this person is getting registered");
                        string safePW = CryptographyUtils.doEncryption(@txtClaveVerificacion.Text, null, null);
                        
                        Controlador.AltaPersona(
                            txtCedula.Text.Trim(' '),
                            txtNombre.Text.Trim(' '),
                            txtApellido.Text.Trim(' '),
                            safePW);
                        if (comboBoxUser.SelectedIndex == 1)
                        {
                            Controlador.AltaAlumno(txtCedula.Text, txtApodo.Text, getIndexesChecklist());
                            clbOpciones.DataSource = Controlador.gruposToListForRegister();

                        }
                        else if (comboBoxUser.SelectedIndex == 2)
                        {
                            Controlador.AltaDocente(txtCedula.Text, getIndexesChecklist());
                            clbOpciones.DataSource = Controlador.grupoMateriaToListForRegister();
                        }
                        else if(comboBoxUser.SelectedIndex == 3)
                        {
                            Controlador.AltaAdmin(txtCedula.Text);
                        }
                        resetFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Controlador.errorHandler(ex));
                    }
                }
                else MessageBox.Show("Una persona con esa cedula ya existe");
            }
            else MessageBox.Show("Las contraseñas no coinciden");
        }
        private void resetFields()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtCedula.Clear();
            txtApodo.Clear();
            txtClave.Clear();
            txtClaveVerificacion.Clear();
            clbOpciones.DataSource = null;
            comboBoxUser.SelectedIndex = 0;
        }
        private List<int> getIndexesChecklist()
        {
            List<int> checkedIndexes = new List<int>();
            int index;
            if (comboBoxUser.SelectedIndex == 1)
            {
                foreach (Object item in clbOpciones.CheckedItems)
                {
                    index = clbOpciones.Items.IndexOf(item) + 1;
                    checkedIndexes.Add(index);
                    Console.WriteLine($" item: {item}   index of item in database:{ index}");
                }
            }
            else if (comboBoxUser.SelectedIndex == 2)
            {
                foreach (Object item in clbOpciones.CheckedItems)
                {
                    index = clbOpciones.Items.IndexOf(item);
                    checkedIndexes.Add(index);
                    Console.WriteLine($" item: {item}   index of item in database:{ index + 1}");
                }
            }

            return checkedIndexes;
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirFoto = new OpenFileDialog();
            abrirFoto.Filter = "Imagenes|*.jpg; *.png; *.jpeg";
            abrirFoto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            abrirFoto.Title = "Seleccionar imagen";

            if (abrirFoto.ShowDialog() == DialogResult.OK)
                pbFoto.Image = Image.FromFile(abrirFoto.FileName);
        }

        private void listarDocentes_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            // this.lblGrupo.Location= Point.;
            lblApodoAst.Visible = true;
            pbFoto.Enabled = true;
            clbOpciones.Enabled = true;
            txtApodo.Enabled = true;
            switch (comboBoxUser.SelectedIndex)
            {

                case 1:
                    lblApodoAst.Visible = true;
                    lblOptions.Text = "Grupos:";
                    clbOpciones.DataSource = null;
                    clbOpciones.DataSource = Controlador.gruposToListForRegister();
                    clbOpciones.ClearSelected();
                    lblOptions.Location = new Point(441, 32);
                    break;
                case 2:
                    lblApodoAst.Visible = false;
                    txtApodo.Enabled = false;
                    lblOptions.Text = "Grupo-materia:";
                    clbOpciones.DataSource = null;
                    clbOpciones.DataSource = Controlador.grupoMateriaToListForRegister();
                    clbOpciones.ClearSelected();
                    lblOptions.Location = new Point(389, 32);
                    break;
                case 3:
                    lblApodoAst.Visible = false;
                    pbFoto.Enabled = false;
                    clbOpciones.Enabled = false;
                    txtApodo.Enabled = false;
                    clbOpciones.DataSource = null;
                    break;
            }
        }

        private void dgvPersonas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
    }
}
