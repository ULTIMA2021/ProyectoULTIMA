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
    public partial class misMensajes : Form
    {
        replyScreen reply;
        int idConsultaPrivada;
        string indexDestinatario;
        string ciDocente;
        string ciAlumno;
        int idMensaje;

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
            dgvMisMensajes.DataSource = Controlador.ConsultasPrivada();
            dgvMisMensajes.Columns["idConsultaPrivada"].Visible = false;
            dgvMisMensajes.Columns["ciAlumno"].Visible = false;
            dgvMisMensajes.Columns["ciDocente"].Visible = false;
            dgvMisMensajes.Columns["Destinatario"].Visible = false;
            dgvMisMensajes.Columns["idMensaje"].Visible = false;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            idConsultaPrivada = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[0].Value.ToString());
            indexDestinatario = dgvMisMensajes.CurrentRow.Cells[7].Value.ToString();
            ciAlumno = Session.cedula;
            ciDocente = dgvMisMensajes.CurrentRow.Cells[2].Value.ToString();
            idMensaje = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[1].Value.ToString());
            List<List<string>> mensajes = Controlador.getMsgsFromConsulta(idConsultaPrivada, ciAlumno, ciDocente);
            replyScreen reply = new replyScreen(idConsultaPrivada, mensajes.Count, ciDocente, ciAlumno);

            string docenteNombre = Controlador.traemeEstaPersona(mensajes[0][2]);
            for (int i = 0; i < mensajes.Count; i++)
            {
                cuadroMensaje conversacion;
                if (mensajes[i][7] != Session.cedula)
                    conversacion = new cuadroMensaje(mensajes[i][4], Session.nombre+" "+Session.apellido);
                else
                    conversacion = new cuadroMensaje(mensajes[i][4], docenteNombre);
                reply.openScreen(conversacion);

            }
                reply.ShowDialog();
        }

        private void dgvMisMensajes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMisMensajes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /* foreach (DataGridViewRow row in dgvMisMensajes.Rows)
             {
                 for (int i = 0; i < dgvMisMensajes.RowCount; i++)
                 {
                     if (Convert.ToString(row.Cells[i].Value) == "pendiente")
                     {
                         row.Cells[i].Style.BackColor = Color.Orange;
                     }
                 }

             } */

            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
