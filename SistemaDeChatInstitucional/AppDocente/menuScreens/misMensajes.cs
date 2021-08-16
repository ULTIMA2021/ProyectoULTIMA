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
    public partial class misMensajes : Form
    {
        int idConsultaPrivada;
        string ciDocente;
        string ciAlumno;

        public misMensajes()
        {
            InitializeComponent();
            //esto no anda
            Loadd();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            idConsultaPrivada = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[0].Value.ToString());
            ciAlumno = dgvMisMensajes.CurrentRow.Cells[3].Value.ToString();
            ciDocente = Session.cedula;  
            List<List<string>> mensajes = Controlador.getMsgsFromConsulta(idConsultaPrivada, ciAlumno, ciDocente);
            replyScreen r = new replyScreen(mensajes);
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
        private async Task Loadd()
        {
            dgvMisMensajes.DataSource = Controlador.ConsultasPrivada();
            dgvMisMensajes.Columns["idConsultaPrivada"].Visible = false;
            dgvMisMensajes.Columns["ciAlumno"].Visible = false;
            dgvMisMensajes.Columns["ciDocente"].Visible = false;
            dgvMisMensajes.Columns["Destinatario"].Visible = false;
            dgvMisMensajes.Columns["idMensaje"].Visible = false;
            await Task.Delay(1000);
        }
    }
}
