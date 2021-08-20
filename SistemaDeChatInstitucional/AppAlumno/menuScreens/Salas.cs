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
    public partial class Salas : Form
    {
        //hacer metodo que haga dispose cuando se cambia de mainScreen
        Timer timer;
        public Salas()
        {
            InitializeComponent();            
        }

        private void timer_Tick(Object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine($"SALA TIMER IS CHECKING {DateTime.Now} COUNT OF SALAS: {Controlador.getSalaCount()}  LOADED COUNT: {dgvSalas.RowCount-1}");

                if (Controlador.getSalaCount() > dgvSalas.RowCount-1)
                {
                    timer.Stop();
                    dgvSalas.DataSource = Controlador.loadSalasDePersona();
                    dgvSalas.Update();
                   // myLoad();
                    timer.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }

        }
        private Timer setTimer()
        {
            timer = new Timer();
            timer.Interval = (1000 * 20);
            timer.Tick += new EventHandler(timer_Tick);
            return timer;
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
            timer.Dispose();
            this.Close();
        }

        private void myLoad()
        {
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
                    Myrow.DefaultCellStyle.BackColor = Color.FromArgb(113, 230, 72);    //chat abierto
                else
                    Myrow.DefaultCellStyle.BackColor = Color.FromArgb(227, 97, 68);     //chat terminado
            }
        }

        private void btnUnirse_Click(object sender, EventArgs e)
        {
            int idSala = Convert.ToInt32(dgvSalas.CurrentRow.Cells["idSala"].Value);
            string asunto = Convert.ToString(dgvSalas.CurrentRow.Cells["resumen"].Value);
            string nombreGrupo = Convert.ToString(dgvSalas.CurrentRow.Cells["Grupo"].Value);
            string nombreMateria = Convert.ToString(dgvSalas.CurrentRow.Cells["Materia"].Value);
            string nombreAnfitrion = Convert.ToString(dgvSalas.CurrentRow.Cells["Anfitrion de chat"].Value);


            new chatScreen(idSala,asunto,nombreAnfitrion);
        }

        private void Salas_Load(object sender, EventArgs e)
        {
            myLoad();
            timer = setTimer();
            timer.Start();
        }

        private void Salas_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            Dispose();
        }

        private void dgvSalas_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dgvSalas.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
