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
        public int idConsultaPrivada;
        string indexDestinatario;
        public int idMensaje;
        public string ciAlumno;
        public string ciDocente;
        
        public misMensajes()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void misMensajes_Load(object sender, EventArgs e)
        {
            dgvMisMensajes.DataSource = AlumnoControlador.ConsultasPrivada();
            dgvMisMensajes.Columns["idConsultaPrivada"].Visible = false;
            dgvMisMensajes.Columns["ciAlumno"].Visible = false;
            dgvMisMensajes.Columns["ciDocente"].Visible = false;
            dgvMisMensajes.Columns["Destinatario"].Visible = false;
            dgvMisMensajes.Columns["idMensaje"].Visible = false;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {

            idConsultaPrivada = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[0].Value.ToString());
            ciDocente = Session.cedula;
            indexDestinatario = dgvMisMensajes.CurrentRow.Cells[7].Value.ToString();
            ciAlumno = dgvMisMensajes.CurrentRow.Cells[3].Value.ToString();
            idMensaje = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[1].Value.ToString());

            List<List<string>> mensajes = AlumnoControlador.getMsgsFromConsulta(idConsultaPrivada, ciAlumno, ciDocente);
           
            replyScreen reply = new replyScreen(idConsultaPrivada, mensajes.Count, Int32.Parse(ciDocente), Int32.Parse(ciAlumno));
           // replyScreen reply2 = new replyScreen();

            // parte de prueba
            for (int i = 0; i < mensajes.Count; i++)
            {
                 cuadroMensaje conversacion = new cuadroMensaje(mensajes[i][4]);
                 reply.openScreen(conversacion);
            }
                reply.ShowDialog();
        }
    }
}
