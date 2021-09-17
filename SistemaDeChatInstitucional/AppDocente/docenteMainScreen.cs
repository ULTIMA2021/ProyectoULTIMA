using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace AppDocente
{
    public partial class docenteMainScreen : Form
    {
        public docenteMainScreen()
        {
            InitializeComponent();
            
        }
        // Metodos para desplazar ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public void esconderSubMenu()
        {
            if(subMenuMiPerfil.Visible == true)
            {
                subMenuMiPerfil.Visible = false;
            }

            if (subMenuDocentes.Visible == true)
            {
                subMenuDocentes.Visible = false;
            }

            if (subMenuMensajes.Visible == true)
            {
                subMenuMensajes.Visible = false;
            }

        }


        public void mostrarSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                esconderSubMenu();
                subMenu.Visible = true;
                
            }
            else
            {
                subMenu.Visible = false;
            }
            
        }


        private Form ventanaActiva = null;
        public void openScreen(Form ventana)
        {

            if (ventanaActiva != null)
            {
                ventanaActiva.Close();
            }
            ventanaActiva = ventana;
            ventana.TopLevel = false;
            ventana.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(ventana);
            panelContenedor.Tag = ventana;
            ventana.BringToFront();
            ventana.Show();
           
        }

        
        private void btnMiPerfil_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuMiPerfil);
        }


        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuDocentes);
        }


        private void btnAgenda_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            openScreen(new menuScreens.agenda());
        }


        private void btnMensajes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuMensajes);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
            Application.Exit(); 
        }


        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btnNormal.BringToFront();
        }

        
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void btnNormal_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            btnMaximizar.BringToFront();
        }


        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            openScreen(new menuScreens.configuracion());
        }


        private void btnAsignaturas_Click(object sender, EventArgs e)
        {
          //  openScreen(new menuScreens.misAsignaturas());
        }

        private void btnMisAlumnos_Click(object sender, EventArgs e)
        {
          //  openScreen(new menuScreens.misDocentes());

            
        }

        private void btnNuevoMensaje_Click(object sender, EventArgs e)
        {
         //   openScreen(new menuScreens.NuevoMensaje());
        }

        private void btnMisMensajes_Click(object sender, EventArgs e)
        {
            openScreen(new menuScreens.misMensajes());
        }

        private void alumnoMainScreen_Load(object sender, EventArgs e)
        {
            lblNombre.Text = $"{Session.nombre} {Session.apellido}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirmLogout = MessageBox.Show("Realmente desea cerrar sesion?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == confirmLogout)
            {
                Dispose();
                Application.Restart();
            }
        }

        private void panelOpciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSala_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            openScreen(new menuScreens.Salas());

        }

       
        private void getTextFromComponents()
        {
            menuScreens.configuracion conf = new menuScreens.configuracion();

            //botones del menu
            btnMiPerfil.Text = Resources.btnMiPerfil;
            btnMensajes.Text = Resources.btnMensajes;
            btnAgenda.Text = Resources.btnAgenda;
            btnAlumnos.Text = Resources.btnAlumnos;
            btnSala.Text = Resources.btnSala;
            btnLogout.Text = Resources.btnLogout;

            //botones de submenu
            btnConfiguracion.Text = Resources.btnConfiguracion;
            btnAsignaturas.Text = Resources.btnMisAsignaturas;
            btnInstitucion.Text = Resources.btnInstitucion;
            btnMisMensajes.Text = Resources.btnMisMensajes;
            btnMisAlumnos.Text = Resources.btnMisAlumnos;

           
          



        }

        private void selectIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = selectIdioma.SelectedIndex;

            if (selectIdioma.Items[index].ToString() == "Ingles/English")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                getTextFromComponents();
            }

            if (selectIdioma.Items[index].ToString() == "Español/Spanish")
            {

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                getTextFromComponents();


            }
        }
    }
}
