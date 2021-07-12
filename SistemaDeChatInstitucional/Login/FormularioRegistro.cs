﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            MessageBox.Show(" ");
            //metodos de capalogica
            //verificar que no exista ya la persona
            //verificaar campos, o de una intentar guardarlos en la base para ver que pasa, ver el sql script por si se decide verificar en la app
            // si esta todo bien, mandar datos a admin para confirmacion
            // capaz que se tiene que agregar un atributo mas para Persona en la base de datos que sea isConfirmed. nose Hay que ver 
        }

        private void load() {
            this.comboBoxUser.SelectedIndex = 0;
        }
 
        private void comboBoxUser_SelectedValueChanged(object sender, EventArgs e)
        {

           // this.lblGrupo.Location= Point.;
            this.label14.Visible = true;
            this.lblAsterix.Visible = true;
            this.pictureBox1.Enabled = true;
            this.pbFoto.Enabled = true;
            this.checkedListBox1.Enabled = true;
            this.txtApodo.Enabled = true;
            if (this.comboBoxUser.SelectedIndex == 1)
            {
                this.lblAsterix.Visible = false;
                this.txtApodo.Enabled = false;
                this.lblGrupo.Text = "Grupo-materia";
                //invocar algun metodo que le haga un update a la checklist con las entradas de grupoMateria que no estan en la tabla docente_dicta_G_M
                //se podria combinar grupo y materia de la tabla a un string y pasarlo como una opcion para elegir
            }
            else if (this.comboBoxUser.SelectedIndex == 2)
            {
                this.label14.Visible = false;
                this.lblAsterix.Visible = false;
                this.pictureBox1.Enabled = false;
                this.pbFoto.Enabled = false;
                this.checkedListBox1.Enabled = false;
                this.txtApodo.Enabled = false;

            }
            
        }
    }
}
