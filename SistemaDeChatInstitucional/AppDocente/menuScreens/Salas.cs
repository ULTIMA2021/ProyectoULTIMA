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

namespace AppDocente.menuScreens
{
    public partial class Salas : Form
    {
        public Salas()
        {
            InitializeComponent();
            Controlador.loadSalasDePersona();

        }

        

        private void txtAsuntoSala_Leave(object sender, EventArgs e)
        {
            if (txtAsuntoSala.Text == String.Empty)
            {
                btnCrear.Enabled = false;
            }
        }

        private void txtAsuntoSala_Enter(object sender, EventArgs e)
        {
            btnCrear.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
