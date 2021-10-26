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
    public partial class misAsignaturas : Form
    {
        public delegate void CustomFormClosedHandler(object sender, FormClosedEventArgs e, string text);
        public event CustomFormClosedHandler CustomFormClosed;
        public misAsignaturas()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e) => this.Dispose();
        private void misAsignaturas_FormClosed(object sender, FormClosedEventArgs e) => CustomFormClosed(sender, e, "Hello World!");

        private void misAsignaturas_Load(object sender, EventArgs e)
        {
            DataTable dgvSource = new DataTable();
            dgvSource.Columns.Add("idGrupo");
            dgvSource.Columns.Add("Grupo");
            dgvSource.Columns.Add("idMateria");
            dgvSource.Columns.Add("Materia");
            dgvSource.Columns.Add("Esta archivada?");

            foreach (List<string> entry in Session.grupoMaterias)
                if (entry[4] == "True")
                    dgvSource.Rows.Add(entry[0],entry[1],entry[2],entry[3],"SI");
                else
                    dgvSource.Rows.Add(entry[0], entry[1], entry[2], entry[3], " ");

            dgvAsignaturas.DataSource = dgvSource;
            dgvAsignaturas.Columns["idGrupo"].Visible = false;
            dgvAsignaturas.Columns["idMateria"].Visible = false;

        }

        private void dgvAsignaturas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) => dgvAsignaturas.ClearSelection();
        
    }
}
