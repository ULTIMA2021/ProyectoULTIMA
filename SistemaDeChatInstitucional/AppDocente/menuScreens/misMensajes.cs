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

namespace AppDocente.menuScreens
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
            try
            {
                InitializeComponent();
                string processName = Process.GetCurrentProcess().ProcessName;
                Process[] instances = Process.GetProcessesByName(processName);
                if (instances.Length<=1)
                    Loadd();
            }
            catch (Exception e)
            {
                MessageBox.Show(Controlador.errorHandler(e));
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            asunto = dgvMisMensajes.CurrentRow.Cells["titulo de consulta"].Value.ToString();
            idConsultaPrivada = Int32.Parse(dgvMisMensajes.CurrentRow.Cells["idConsultaPrivada"].Value.ToString());
            ciAlumno = dgvMisMensajes.CurrentRow.Cells["ciAlumno"].Value.ToString();
            ciDocente = Session.cedula;
            status = dgvMisMensajes.CurrentRow.Cells["Status de consulta"].Value.ToString();
            List<List<string>> mensajes = Controlador.getMsgsFromConsulta(idConsultaPrivada, ciAlumno, ciDocente);
            replyScreen r = new replyScreen(mensajes,asunto,status);
        }

        //little demo with html. its fucking horrendous
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
