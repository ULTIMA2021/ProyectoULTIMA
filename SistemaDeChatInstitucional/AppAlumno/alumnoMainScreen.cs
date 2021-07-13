using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
namespace AppAlumno
{
    public partial class alumnoMainScreen : Form
    {
        public alumnoMainScreen()
        {
            InitializeComponent();
            
        }

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


        private void btnDocentes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuDocentes);
        }


        private void btnAgenda_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
        }


        private void btnMensajes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuMensajes);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }


        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
            btnNormal.BringToFront();
        }

        
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.BringToFront();
        }


        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            openScreen(new menuScreens.configuracion());
        }


        private void btnAsignaturas_Click(object sender, EventArgs e)
        {
            openScreen(new menuScreens.misAsignaturas());
        }

        private void btnMisDocentes_Click(object sender, EventArgs e)
        {
            openScreen(new menuScreens.misDocentes());

            
        }

        private void btnNuevoMensaje_Click(object sender, EventArgs e)
        {
            openScreen(new menuScreens.NuevoMensaje());
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
            this.Close();
            
        }
    }
}
