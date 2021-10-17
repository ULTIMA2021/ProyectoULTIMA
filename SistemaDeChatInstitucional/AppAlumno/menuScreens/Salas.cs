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
        Timer timer;
        bool loadFinishedSalas = false;
        int checker = 0;
        public delegate void CustomFormClosedHandler(object semder, FormClosedEventArgs e, string text);
        public event CustomFormClosedHandler CustomFormClosed;

        public Salas() => InitializeComponent();            
        

        private void timer_Tick(Object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine($"SALA TIMER IS CHECKING {DateTime.Now} COUNT OF SALAS: {Controlador.getSalaCount(loadFinishedSalas)}  LOADED COUNT: {dgvSalas.RowCount}");

                if (Controlador.getSalaCount(loadFinishedSalas) > dgvSalas.RowCount)
                {
                    timer.Stop();
                    dgvSalas.DataSource = Controlador.loadSalasDePersona(loadFinishedSalas);
                    dgvSalas.Update();
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
            dgvSalas.DataSource = Controlador.loadSalasDePersona(loadFinishedSalas);
            dgvSalas.Columns["idSala"].Visible = false;
            dgvSalas.Columns["idGrupo"].Visible = false;
            dgvSalas.Columns["idMateria"].Visible = false;
            dgvSalas.Columns["docenteCi"].Visible = false;
            dgvSalas.Columns["anfitrion"].Visible = false;

            dgvSalas.Columns["Grupo"].Visible = true;
            dgvSalas.Columns["Materia"].Visible = true;
            dgvSalas.Columns["Docente"].Visible = false;
            dgvSalas.Columns["Anfitrion de chat"].Visible = true;
            dgvSalas.Columns["resumen"].Visible = false;
            dgvSalas.Columns["isDone"].Visible = false;
            dgvSalas.Columns["creacion"].Visible = false;
        }
        private void loadGM() {
            DataTable dataGM = new DataTable();
            dataGM.Columns.Add("idGrupo");
            dataGM.Columns.Add("Grupo");
            dataGM.Columns.Add("idMateria");
            dataGM.Columns.Add("Materia");
            for (int i = 0; i < Session.grupoMaterias.Count; i++)
            {
                Console.WriteLine(Session.grupoMaterias[i][4].ToString());
                if (Session.grupoMaterias[i][4].ToString() == "False")
                    dataGM.Rows.Add(Session.grupoMaterias[i][0], Session.grupoMaterias[i][1], Session.grupoMaterias[i][2], Session.grupoMaterias[i][3]);
            }
            dgvGrupoMaterias.DataSource = dataGM;
            dgvGrupoMaterias.Columns["idGrupo"].Visible = false;
            dgvGrupoMaterias.Columns["Grupo"].Visible = true;
            dgvGrupoMaterias.Columns["idMateria"].Visible = false;
            dgvGrupoMaterias.Columns["Materia"].Visible = true;
            dgvGrupoMaterias.ClearSelection();
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
            string anfitrion = Convert.ToString(dgvSalas.CurrentRow.Cells["anfitrion"].Value);
            bool isDone = Convert.ToBoolean(dgvSalas.CurrentRow.Cells["isDone"].Value);
            string docente = Convert.ToString(dgvSalas.CurrentRow.Cells["docenteCi"].Value);

            timer.Stop();
            Controlador.updateSalaConnection(idSala.ToString(),true);

            new chatScreen(idSala, asunto, nombreAnfitrion, anfitrion,isDone,docente).ShowDialog();

            dgvSalas.DataSource = Controlador.loadSalasDePersona(loadFinishedSalas);
            dgvSalas.Update();
            timer.Start();
        }

        private void Salas_Load(object sender, EventArgs e)
        {
            Enabled = false;
            try
            {
                timer = setTimer();
                timer.Start();
                loadGM();
                myLoad();
               
            }
            catch (Exception ex)
            {
                timer.Stop();
                timer.Dispose();
                dgvGrupoMaterias.Enabled = false;
                dgvSalas.Enabled = false;
                txtAsuntoSala.Enabled = false;
                btnCrear.Enabled = false;
                btnUnirse.Enabled = false;
                MessageBox.Show(Controlador.errorHandler(ex));
            }


            lblCrear.Text = Resources.lblCrear;
            lblSalas.Text = Resources.lblSalas;
            btnCrear.Text = Resources.btnCrear;
            btnUnirse.Text = Resources.btnUnirse;
            btnExit.Text = Resources.btnExit;

            //headers de columnas
            dgvGrupoMaterias.Columns[1].HeaderText = Resources.colGrupo;
            dgvGrupoMaterias.Columns[3].HeaderText = Resources.colMateria;
            dgvSalas.Columns[5].HeaderText = Resources.colGrupo;
            dgvSalas.Columns[6].HeaderText = Resources.colMateria;
            dgvSalas.Columns[8].HeaderText = Resources.colAnfitrion;
            Enabled = true;
        }

        private void Salas_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            Dispose();
        }

        private void dgvSalas_ColumnAdded(object sender, DataGridViewColumnEventArgs e)=> dgvSalas.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Enabled = false;
            string idGrupo;
            string idMateria;
            string docente;
            string anfitrion;
            string resumen;
            DateTime fechaHora;
            try
            {
                idGrupo = Convert.ToString(dgvGrupoMaterias.CurrentRow.Cells["idGrupo"].Value);
                idMateria = Convert.ToString(dgvGrupoMaterias.CurrentRow.Cells["idMateria"].Value);
                docente = null;
                anfitrion = Session.cedula;
                resumen = txtAsuntoSala.Text.Trim();
                fechaHora = DateTime.Now;

                Controlador.nuevaSala(idGrupo, idMateria, docente, anfitrion, resumen, fechaHora);
                txtAsuntoSala.Clear();
                dgvSalas.DataSource = Controlador.loadSalasDePersona(loadFinishedSalas);
                dgvSalas.Update();
                timer.Start();
            }
            catch (Exception ex)
            {
               MessageBox.Show(Controlador.errorHandler(ex));
            }
            Enabled = true;
        }

        private void txtAsuntoSala_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAsuntoSala.Text))
                btnCrear.Enabled = true;
            else
                btnCrear.Enabled = false;
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            Enabled = false;
            checker++;
            if (checker % 2 == 0)
            {
                btnHistorial.Text = "Historial";
                loadFinishedSalas = false;
            }
            else
            {
                loadFinishedSalas = true;
                btnHistorial.Text = "Nuevas salas";
            }
            timer.Stop();
            dgvSalas.DataSource = Controlador.loadSalasDePersona(loadFinishedSalas);
            dgvSalas.Update();
            timer.Start();
            Enabled = true;
        }

        private void Salas_FormClosed(object sender, FormClosedEventArgs e) => CustomFormClosed(sender, e, "Hello World!");
    }
}
