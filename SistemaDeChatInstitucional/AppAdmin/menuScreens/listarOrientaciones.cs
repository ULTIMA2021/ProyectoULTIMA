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

namespace AppAdmin.menuScreens
{
    public partial class listarOrientaciones : Form
    {
        public listarOrientaciones()
        {
            InitializeComponent();
        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void listarOrientaciones_Load_1(object sender, EventArgs e)
        {
            clbGrupos.DataSource = Controlador.gruposToListForRegister();
            dgvListarOrientaciones.DataSource = Controlador.obtenerOrientaciones();

        }

        private void listarOrientaciones_Shown(object sender, EventArgs e)
        {
            dgvListarOrientaciones.ClearSelection();

        }
    }
}
