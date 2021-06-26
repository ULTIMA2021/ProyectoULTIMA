using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        
        private void btnMiPerfil_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuMiPerfil);
          //  this.btnMiPerfil.BackColor = Color.Blue;
          //  this.button1.BackColor = Color.FromArgb(26, 32, 40);
        }

        private void btnDocentes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuDocentes);
           // this.button1.BackColor = Color.Blue;
           // this.btnMiPerfil.BackColor = Color.FromArgb(26, 32, 40);
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
        }

        private void btnMensajes_Click(object sender, EventArgs e)
        {
            
        }
    }
}
