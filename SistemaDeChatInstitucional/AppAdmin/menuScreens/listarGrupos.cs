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
    public partial class listarGrupos : Form
    {
        public listarGrupos()
        {
            InitializeComponent();
        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listarGrupos_Load(object sender, EventArgs e)
        {
            
            clbMaterias.DataSource = Controlador.MateriasToListForRegister();
            dgvListarGrupos.DataSource = Controlador.obtenerGrupos();
        }
    }
}
