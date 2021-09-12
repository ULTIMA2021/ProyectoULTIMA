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
    public partial class listarDocentes : Form
    {
        public listarDocentes()
        {
            InitializeComponent();
        }

        private void listarAlumnos_Load(object sender, EventArgs e)
        {
            dgvListarAlumnos.DataSource = Controlador.obtenerDocentes();
        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
