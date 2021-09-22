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
    public partial class misAsignaturas : Form
    {
        public delegate void CustomFormClosedHandler(object semder, FormClosedEventArgs e, string text);
        public event CustomFormClosedHandler CustomFormClosed;
        public misAsignaturas()
        {
            InitializeComponent();
          //  dgvAsignaturas.DataSource = AlumnoControlador.listarMaterias();
        }
        private void btnExit_Click(object sender, EventArgs e) => this.Dispose();
        private void misAsignaturas_FormClosed(object sender, FormClosedEventArgs e) => CustomFormClosed(sender, e, "Hello World!");
    }
}
