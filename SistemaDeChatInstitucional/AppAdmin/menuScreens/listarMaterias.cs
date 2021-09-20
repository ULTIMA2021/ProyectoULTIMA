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
    public partial class listarMaterias : Form
    {
        public listarMaterias()
        {
            InitializeComponent();
        }

       

        private void listarMaterias_Load(object sender, EventArgs e)
        {
            clbGrupos.DataSource = Controlador.gruposToListForRegister();
            dgvListarMaterias.DataSource = Controlador.obtenerMaterias();
        }

        

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
