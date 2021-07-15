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

        public void columnaStatus()
        {
            /* string status;
             for(int i = 0; i < dgvMisMensajes.RowCount - 1; i++)
             {
                 string estado = dgvMisMensajes.Rows[i].Cells[4].Value.ToString();

                 if (estado.Contains("pendiente"))
                 {

                 }
             } */

            
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            replyScreen reply = new replyScreen();

            int idconsultaPrivada = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[0].Value.ToString());
            string indexDestinatario = dgvMisMensajes.CurrentRow.Cells[7].Value.ToString();
            string ciDocente;
            string ciAlumno;
            if (Session.type == 0)
            {
                ciAlumno = Session.cedula;
                ciDocente = dgvMisMensajes.CurrentRow.Cells[2].Value.ToString();
                //int idConsultaPrivada, string ciAlumno, string ciDocente
                AlumnoControlador.getMsgsFromConsulta(idconsultaPrivada,ciAlumno,ciDocente);
                

                //Cargo varlores de los campos en replyScreen y muestro la ventana
                reply.lblNombreAlumno.Text = AlumnoControlador.obtenerRemitente(ciAlumno);
                reply.txtMensajeAlumno.Text = AlumnoControlador.obtenerMensaje(idconsultaPrivada, ciAlumno, indexDestinatario);
                reply.ShowDialog();

                MessageBox.Show("El destinatario es: " + AlumnoControlador.obtenerDestinatario(indexDestinatario));
            }
             /*   else if (Session.type == 1)
            {
                ciDocente = Session.cedula;
                ciAlumno = dgvMisMensajes.CurrentRow.Cells[2].Value.ToString();
                AlumnoControlador.getMsgsFromConsulta(idconsultaPrivada, ciAlumno, ciDocente);
            }  */
        }
    }
}
