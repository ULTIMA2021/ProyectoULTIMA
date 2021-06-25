using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlumnoApp.Login_Alumno_y_Docente

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
                    if (txtContra.Text != "")
                    {
                        // Aca validamos cada usuario, si existen acceden y sino tira un error

                        MessageBox.Show("Existe en la base de datos");
                    }
                    else
                    {
                        errorMessage("* Usuario y/o contraseña incorrectos.");
                    }
                        
                }
                
                else errorMessage("* Ingrese contraseña.");

               
            }
            else errorMessage("* Ingrese un usuario.");




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
            
        }
    }
}
