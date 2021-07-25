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

namespace Login
{
    public partial class FormularioRegistro : Form
    {
        
        public FormularioRegistro()
        {
            InitializeComponent();
            this.CenterToScreen();
            load();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            if (txtClave.Text == txtClaveVerificacion.Text && txtCedula.Text.Length==8)
            {
                if (AlumnoControlador.existePersona(txtCedula.Text))
                {
                    Console.WriteLine("this person is getting registered");
                    AlumnoControlador.AltaPersona(txtCedula.Text, txtNombre.Text, txtApellido.Text, txtClave.Text);
                    if (this.comboBoxUser.SelectedIndex == 0) {
                        AlumnoControlador.AltaAlumno(txtCedula.Text, txtApodo.Text,getIndexesChecklist());
                        this.checkedListBox1.DataSource = AlumnoControlador.gruposToListForRegister();

                    }
                    else if (this.comboBoxUser.SelectedIndex == 1)
                    {
                       AlumnoControlador.AltaDocente(txtCedula.Text, getIndexesChecklist());
                        this.checkedListBox1.DataSource = AlumnoControlador.grupoMateriaToListForRegister();
                    }
                    else
                    {
                        AlumnoControlador.AltaAdmin(txtCedula.Text);
                    }
                    //MessageBox.Show(" Ingresado! espere que lo confirme un administrador");

                }
                else MessageBox.Show("Una persona con esa cedula ya existe");

            }
            else MessageBox.Show("Las contraseñas no coinciden");

            MessageBox.Show($"Ingresado! Bienvenido {txtNombre.Text} {txtApellido.Text}");
            resetFields();
        }

        private void load() {
            this.comboBoxUser.SelectedIndex = 0;
        }
        private List<int> getIndexesChecklist() {
            List<int> checkedIndexes = new List<int>();
            int index;
            if (comboBoxUser.SelectedIndex == 0)
            {
                foreach (Object item in checkedListBox1.CheckedItems)
                {
                    index = checkedListBox1.Items.IndexOf(item) + 1;
                    checkedIndexes.Add(index);
                    Console.WriteLine($" item: {item}   index of item in database:{ index}");
                }
            }
            else if (comboBoxUser.SelectedIndex == 1)
            {
                foreach (Object item in checkedListBox1.CheckedItems)
                {
                    index = checkedListBox1.Items.IndexOf(item);
                    checkedIndexes.Add(index);
                    Console.WriteLine($" item: {item}   index of item in database:{ index+1}");
                }
            }

            return checkedIndexes;
        }
        private void comboBoxUser_SelectedValueChanged(object sender, EventArgs e)
        {

           // this.lblGrupo.Location= Point.;
            this.label14.Visible = true;
            this.lblAsterix.Visible = true;
            this.pbFoto.Enabled = true;
            this.pbFoto.Enabled = true;
            this.checkedListBox1.Enabled = true;
            this.txtApodo.Enabled = true;
            if (this.comboBoxUser.SelectedIndex == 0)
            {
                this.lblAsterix.Visible = false;
                this.lblGrupo.Text = "Grupo/s";
                this.checkedListBox1.DataSource = null;
                this.checkedListBox1.DataSource = AlumnoControlador.gruposToListForRegister();
                this.checkedListBox1.ClearSelected();
            }
            else if (this.comboBoxUser.SelectedIndex == 1)
            {
                this.lblAsterix.Visible = false;
                this.txtApodo.Enabled = false;
                this.lblGrupo.Text = "Grupo-materia";
                this.checkedListBox1.DataSource = null;
                this.checkedListBox1.DataSource = AlumnoControlador.grupoMateriaToListForRegister();
                this.checkedListBox1.ClearSelected();

            }
            else if (this.comboBoxUser.SelectedIndex == 2)
            {
                this.label14.Visible = false;
                this.lblAsterix.Visible = false;
                this.pbFoto.Enabled = false;
                this.pbFoto.Enabled = false;
                this.checkedListBox1.Enabled = false;
                this.txtApodo.Enabled = false;
                this.checkedListBox1.DataSource = null;

            }
        }
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirFoto = new OpenFileDialog();
            abrirFoto.Filter = "Imagenes|*.jpg; *.png; *.jpeg";
            abrirFoto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            abrirFoto.Title = "Seleccionar imagen";

            if (abrirFoto.ShowDialog() == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(abrirFoto.FileName);
            }
        }

        private void resetFields() {
            this.txtApellido.Clear();
            this.txtNombre.Clear();
            this.txtCedula.Clear();
            this.txtApodo.Clear();
            this.txtClave.Clear();
            this.txtClaveVerificacion.Clear();
            this.checkedListBox1.DataSource = null; 
        }

    }
}