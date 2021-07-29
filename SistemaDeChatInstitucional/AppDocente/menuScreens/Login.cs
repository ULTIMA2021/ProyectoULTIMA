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
using AppDocente;
using System.Runtime.InteropServices;

namespace Login

{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        // Metodos para desplazar ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


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
            if (AlumnoControlador.isDocente(txtUsuario.Text, txtContra.Text))
            {
                this.Hide();
                bienvenido bv = new bienvenido();
                bv.ShowDialog();
                docenteMainScreen dms = new docenteMainScreen();
                dms.Show();
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
                txtUsuario.Text = "";
            lblErrorMessage.Visible = false;
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            txtContra.PasswordChar = '●';
            if (txtContra.Text == "Contraseña")
                txtContra.Text = "";
            lblErrorMessage.Visible = false;
        }

        private void txtUusuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == String.Empty)
                txtUsuario.Text = "Usuario";
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
    }
}
