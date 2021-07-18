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
using AppAlumno;
using AppDocente;
using AppAdmin;
namespace Login

{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();
            
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUsuario.Text != "Usuario")
            {
                if (txtContra.Text != "Contraseña")
                {
                    try
                    {
                        validarUsuario();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else errorMessage("* Ingrese contraseña.");
            }
            else errorMessage("* Ingrese un usuario.");
        }
        

        //new
        private void validarUsuario()
        {
            if (AlumnoControlador.isAlumno(txtUsuario.Text, txtContra.Text))
            {
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(newAlu));
                this.Hide();
                bienvenido bv = new bienvenido();
                newSession(t, bv);
                txtUsuario.Text = "Usuario";
                txtContra.Text = "Contraseña";
                txtContra.PasswordChar = '\0';
                return;
            }
            if (AlumnoControlador.isDocente(txtUsuario.Text, txtContra.Text))
            {
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(newDoc));
                this.Hide();
                bienvenido bv = new bienvenido();
                newSession(t,bv);
                txtUsuario.Text = "Usuario";
                txtContra.Text = "Contraseña";
                txtContra.PasswordChar = '\0';
                return;
            }
            if (AlumnoControlador.isAdmin(txtUsuario.Text, txtContra.Text))
            {
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(newAdmin));
                this.Hide();
                bienvenido bv = new bienvenido();
                newSession(t,bv);
                txtUsuario.Text = "Usuario";
                txtContra.Text = "Contraseña";
                txtContra.PasswordChar = '\0';
                return;
            }
            errorMessage("* Usuario y/o contraseña incorrectos.");
            txtUsuario.Text = "Usuario";
            txtContra.Text = "Contraseña";
            txtContra.PasswordChar = '\0';
           
        }

        public void errorMessage(string msg)
        {
            lblErrorMessage.Text = msg;
            lblErrorMessage.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUusuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
            }

            lblErrorMessage.Visible = false;

        }

        private void txtContra_Enter(object sender, EventArgs e)
        {

            txtContra.PasswordChar = '●';

            if (txtContra.Text == "Contraseña")
            {
                txtContra.Text = "";

            }

            lblErrorMessage.Visible = false;

        }

        private void txtUusuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == String.Empty)
            {

                txtUsuario.Text = "Usuario";
            }
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {


            if (txtContra.Text == String.Empty)
            {
                txtContra.Text = "Contraseña";
                txtContra.PasswordChar = '\0';

            }
        }

        private void picVer_Click(object sender, EventArgs e)
        {
            if (txtContra.Text != "Contraseña")
            {
                txtContra.PasswordChar = '\0';
                picOcultar.BringToFront();
            }
        }

        private void picOcultar_Click(object sender, EventArgs e)
        {
            txtContra.PasswordChar = '●';
            pictVer.BringToFront();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showRegisterForm(sender, e);
        }
        private void showRegisterForm(object sender, EventArgs e)
        {
            FormularioRegistro formularioRegistro = new FormularioRegistro();
            formularioRegistro.ShowDialog();
        }

        private void logout(string sender, FormClosedEventArgs e)
        {
            // alumnoMainScreen ams = new alumnoMainScreen();
            txtUsuario.Text = "Usuario";
            txtUsuario.Text = "Contraseña";
            lblErrorMessage.Visible = false;
            this.Show();
            txtUsuario.Focus();
        }

        //nuevos metodos

        private void clearfields(){
            this.txtContra.Clear();
            this.txtUsuario.Clear();
        }

        private void newSession(System.Threading.Thread t, bienvenido bv) {
            bv.ShowDialog();
            t.Start();
            bv.Dispose();
            this.txtContra.Clear();
            this.txtUsuario.Clear();
            AlumnoControlador.actualizarEstadoPersona(true);
            while (t.IsAlive)
            {
                //donothing
            }
            this.Show();
        }

        //esto tiene que estar asi, no puedo llamar los constructores cuando le asigno valor al thread nuevo
        private void newAdmin() => Application.Run(new adminMainScreen());

        private void newDoc() => Application.Run(new docenteMainScreen());

        private void newAlu()=> Application.Run(new alumnoMainScreen());

       

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                validarUsuario();
                txtUsuario.Focus();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                validarUsuario();
                txtUsuario.Focus();
            }
        }
    }
}
