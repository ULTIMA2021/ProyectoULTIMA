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

namespace AppAlumno.menuScreens
{
    public partial class misMensajes : Form
    {
        public misMensajes()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void misMensajes_Load(object sender, EventArgs e)
        {
            dgvMisMensajes.DataSource = AlumnoControlador.ConsultasPrivada();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            int consultaInDgv = dgvMisMensajes.CurrentRow.Index;

            if (Session.type == 0)
            {
                //AlumnoControlador.
            }
                else if (Session.type == 1)
            {

            }
                    else if (Session.type == 2)
            {

            }

        }
    }
}
