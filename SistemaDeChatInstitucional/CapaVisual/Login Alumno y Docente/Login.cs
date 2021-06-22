using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVisual.Login_Alumno_y_Docente
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




        }





        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUusuario_Enter(object sender, EventArgs e)
        {
            if (txtUusuario.Text == "Usuario")
            {
                txtUusuario.Text = "";
            }






        }

        private void txtContra_Enter(object sender, EventArgs e)
        {

            txtContra.PasswordChar = '●';

            if (txtContra.Text == "Contraseña")
            {
                txtContra.Text = "";

            }



        }

        private void txtUusuario_Leave(object sender, EventArgs e)
        {
            if (txtUusuario.Text == String.Empty)
            {

                txtUusuario.Text = "Usuario";
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
    }
}
