using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppAdmin
{
    public partial class adminMainScreen : Form
    {
        public adminMainScreen()
        {
            InitializeComponent();
        }


        public void esconderSubMenu()
        {
            if (subMenuAlumnos.Visible == true)
            {
                subMenuAlumnos.Visible = false;
            }

            if (subMenuDocentes.Visible == true)
            {
                subMenuDocentes.Visible = false;
            }

            if (subMenuAdmin.Visible == true)
            {
                subMenuAdmin.Visible = false;
            }

        }


        public void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
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
            subMenuAlumnos.BringToFront();
            subMenuDocentes.BringToFront();
            subMenuAdmin.BringToFront();
            esconderSubMenu();
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuAlumnos);
        }

        private void btnDocente_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuDocentes);
        }

        private void btnAdministradores_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuAdmin);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void btnListarAlumnos_Click(object sender, EventArgs e)
        {
            openScreen(new menuScreens.listarAlumnos());
        }

        private void btnRequerimientoAlumnos_Click(object sender, EventArgs e)
        {
            menuScreens.FormularioRegistro form = new menuScreens.FormularioRegistro();
            form.Show();
            openScreen(new menuScreens.FormularioRegistro());
        }

        private void btnListarDocentes_Click(object sender, EventArgs e)
        {
            openScreen(new menuScreens.listarDocentes());
        }
    }
}
