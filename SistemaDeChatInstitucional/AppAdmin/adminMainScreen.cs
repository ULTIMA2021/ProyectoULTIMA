using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AppAdmin
{
    public partial class adminMainScreen : Form
    {

        public adminMainScreen() => InitializeComponent();


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public void esconderSubMenu()
        {
            if (subMenuAlumnos.Visible == true)
                subMenuAlumnos.Visible = false;

            //if (subMenuDocentes.Visible == true)
            //    subMenuDocentes.Visible = false;

            //if (subMenuAdmin.Visible == true)
            //    subMenuAdmin.Visible = false;

            if (subMenuCursos.Visible == true)
                subMenuCursos.Visible = false;
        }

        public void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                esconderSubMenu();
                subMenu.Visible = true;

            }
            else
                subMenu.Visible = false;

        }

        private Form ventanaActiva = null;
        public void openScreen(Form ventana)
        {
            if (ventanaActiva != null)
                ventanaActiva.Close();

            ventanaActiva = ventana;
            ventana.TopLevel = false;
            ventana.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(ventana);
            panelContenedor.Tag = ventana;
            ventana.BringToFront();
            ventana.Show();
            subMenuAlumnos.BringToFront();
            //subMenuDocentes.BringToFront();
            //subMenuAdmin.BringToFront();
            subMenuCursos.BringToFront();
            esconderSubMenu();
        }

        //private void btnAlumno_Click(object sender, EventArgs e)
        //{
        //    mostrarSubMenu(subMenuAlumnos);
        //}

        //private void btnDocente_Click(object sender, EventArgs e)
        //{
        //   // mostrarSubMenu(subMenuDocentes);
        //}

        //private void btnAdministradores_Click(object sender, EventArgs e)
        //{
        //    //mostrarSubMenu(subMenuAdmin);
        //}

        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCursos_Click(object sender, EventArgs e) => mostrarSubMenu(subMenuCursos);

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Enabled = false;
            openScreen(new menuScreens.listarMaterias());
            Enabled = true;
            Cursor.Current = Cursors.Default;

        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Enabled = false;
            openScreen(new menuScreens.listarGrupos());
            Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void btnOrientaciones_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Enabled = false;
            openScreen(new menuScreens.listarOrientaciones());
            Enabled = true;
            Cursor.Current = Cursors.Default;

        }

        private void btnUsuarios_Click(object sender, EventArgs e) => mostrarSubMenu(subMenuAlumnos);

        private void adminMainScreen_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void btnNuevosAlumnos_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Enabled = false;
            openScreen(new menuScreens.TicketAlumno());
            Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void btnRegi_Click(object sender, EventArgs e)
        {
            Enabled = false;
            openScreen(new menuScreens.UsuarioRegistro());
            Enabled = true;
        }

        private void btnUsuariosDelSistema_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Enabled = false;
            openScreen(new menuScreens.UserList());
            Enabled = true;
            Cursor.Current = Cursors.Default;

        }
    }
}
