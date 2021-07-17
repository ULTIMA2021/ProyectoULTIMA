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

        private void validarUsuario()
        {
            //FormClosedEventArgs e;//make the main screen spit a formclosed event, pass it to a method that return true if cerrar session button was clicked
            if (AlumnoControlador.isAlumno(txtUsuario.Text, txtContra.Text)){
                bienvenido bv = new bienvenido();
                bv.ShowDialog();
                alumnoMainScreen ams = new alumnoMainScreen();
                ams.Show();
               // ams.FormClosed += logout;
                this.Hide();
                AlumnoControlador.actualizarEstadoPersona(true);
                return ;
            }
           if (AlumnoControlador.isDocente(txtUsuario.Text, txtContra.Text)){
                this.Hide();
                bienvenido bv = new bienvenido();
                bv.ShowDialog();
                docenteMainScreen dms = new docenteMainScreen();
                dms.Show();
                AlumnoControlador.actualizarEstadoPersona(true);
                return;
            }
            if (AlumnoControlador.isAdmin(txtUsuario.Text, txtContra.Text)){
                this.Hide();
                bienvenido bv = new bienvenido();
                bv.ShowDialog();
                adminMainScreen ams = new adminMainScreen();
                ams.Show();
                AlumnoControlador.actualizarEstadoPersona(true);
                return;
            } 
                errorMessage("* Usuario y/o contraseña incorrectos.");
                txtUsuario.Text = "Usuario";
                txtContra.PasswordChar = '\0';
                txtContra.Text = "Contraseña";
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
                txtContra.PasswordChar = '\0';
                txtContra.Text = "Contraseña";

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
            showRegisterForm(sender,e);
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

    }
}
