using System;
using System.Windows.Forms;
using CapaLogica;
using AppAdmin;
using System.Runtime.InteropServices;

namespace Login

{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            CenterToScreen();
            Session.type = 5;
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
                        MessageBox.Show(Controlador.errorHandler(ex));
                    }

                }
                else errorMessage("* Ingrese contraseña.");
            }
            else errorMessage("* Ingrese un usuario.");
        }

        private void validarUsuario()
        {
            if (Controlador.isAdmin(txtUsuario.Text, txtContra.Text))
            {
                Hide();
                bienvenido bv = new bienvenido();
                bv.ShowDialog();
                adminMainScreen ams = new adminMainScreen();
                ams.Show();
                Controlador.actualizarEstadoPersona(true);
                
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

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
