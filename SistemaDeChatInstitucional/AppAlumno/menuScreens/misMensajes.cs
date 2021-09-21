using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace AppAlumno.menuScreens
{
    public partial class misMensajes : Form
    {
        int idConsultaPrivada;
        string ciDocente;
        string ciAlumno;
        string asunto;
        string status;
        public misMensajes()
        {
            InitializeComponent();
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] instances = Process.GetProcessesByName(processName);
            if (instances.Length <= 1)
                Loadd();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            idConsultaPrivada = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[0].Value.ToString());
            ciAlumno = Session.cedula;
            ciDocente = dgvMisMensajes.CurrentRow.Cells[2].Value.ToString();
            asunto = dgvMisMensajes.CurrentRow.Cells[4].Value.ToString();
            status = dgvMisMensajes.CurrentRow.Cells["Status de consulta"].Value.ToString();
            List<List<string>> mensajes = Controlador.getMsgsFromConsulta(idConsultaPrivada, ciAlumno, ciDocente);
            replyScreen r = new replyScreen(mensajes,asunto,status);
        }



        private void dgvMisMensajes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMisMensajes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgvMisMensajes.Rows)
            {
                if ((String)Myrow.Cells["Status de consulta"].Value == "pendiente")
                {
                   Myrow.Cells[5].Style.BackColor = Color.FromArgb(250, 182, 37);
                                 
                }
                else if ((String)Myrow.Cells["Status de consulta"].Value == "resuelta")
                    Myrow.Cells[5].Style.BackColor = Color.FromArgb(113, 230, 72);
                    
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            idConsultaPrivada = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[0].Value.ToString());
            string indexDestinatario = dgvMisMensajes.CurrentRow.Cells[7].Value.ToString();
            string ciDocente;

            ciAlumno = dgvMisMensajes.CurrentRow.Cells[3].Value.ToString();
            ciDocente = Session.cedula;
            List<List<string>> mensajes = Controlador.getMsgsFromConsulta(idConsultaPrivada, ciAlumno, ciDocente);

            new UglyHTMLmensajes(mensajes);
        }
        private void Loadd()
        {
            dgvMisMensajes.DataSource = Controlador.ConsultasPrivada();
            dgvMisMensajes.Columns["idConsultaPrivada"].Visible = false;
            dgvMisMensajes.Columns["ciAlumno"].Visible = false;
            dgvMisMensajes.Columns["ciDocente"].Visible = false;
            dgvMisMensajes.Columns["Destinatario"].Visible = false;
            dgvMisMensajes.Columns["idMensaje"].Visible = false;
        }

        private void misMensajes_Load(object sender, EventArgs e)
        {
            lblBuscar.Text = Resources.lblBuscar;
            btnAbrir.Text = Resources.btnAbrir;
            btnEliminar.Text = Resources.btnEliminar;
            btnExit.Text = Resources.btnExit;
        }
    }
}
