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
            load();
            
        }

        private void txtAsuntoSala_Leave(object sender, EventArgs e)
        {
            if (txtAsuntoSala.Text.Trim() == String.Empty)
                btnCrear.Enabled = false;

        }

        private void txtAsuntoSala_Enter(object sender, EventArgs e)
        {
            btnCrear.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void load()
        {
            /* 
            hidden
            table.Columns.Add("idSala");
            table.Columns.Add("idGrupo");
            table.Columns.Add("idMateria");
            table.Columns.Add("docenteCi");
            table.Columns.Add("anfitrion");
            visible
            table.Columns.Add("Grupo");
            table.Columns.Add("Materia");
            table.Columns.Add("Docente");
            table.Columns.Add("Anfitrion de chat");
            table.Columns.Add("resumen");
            table.Columns.Add("isDone");
            table.Columns.Add("creacion");
            */


            dgvSalas.DataSource = Controlador.loadSalasDePersona();
            dgvSalas.Columns["idSala"].Visible = false;
            dgvSalas.Columns["idGrupo"].Visible = false;
            dgvSalas.Columns["idMateria"].Visible = false;
            dgvSalas.Columns["docenteCi"].Visible = false;
            dgvSalas.Columns["anfitrion"].Visible = false;

            dgvSalas.Columns["Grupo"].Visible = true;
            dgvSalas.Columns["Materia"].Visible = true;
            dgvSalas.Columns["Docente"].Visible = true;
            dgvSalas.Columns["Anfitrion de chat"].Visible = true;
            dgvSalas.Columns["resumen"].Visible = true;
            dgvSalas.Columns["isDone"].Visible = false;
            dgvSalas.Columns["creacion"].Visible = true;
        }

        private void dgvSalas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgvSalas.Rows)
            {
                if (Convert.ToBoolean(Myrow.Cells["isDone"].Value) == false)
                    Myrow.DefaultCellStyle.BackColor = Color.FromArgb(113, 230, 72);
                else
                    Myrow.DefaultCellStyle.BackColor = Color.FromArgb(227, 97, 68);// cambiar a otro color para las salas ya terminadas
            }
        }
    }
}
