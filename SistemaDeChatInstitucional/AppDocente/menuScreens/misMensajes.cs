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

       // public int idConsultaPrivada;
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
            replyScreen reply = new replyScreen();

            int idConsultaPrivada = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[0].Value.ToString());
            int idMensaje = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[1].Value.ToString());
            string destinatario = dgvMisMensajes.CurrentRow.Cells[7].Value.ToString();
            string ciDocente;
            string ciAlumno;
            
                ciDocente = Session.cedula;
                ciAlumno = dgvMisMensajes.CurrentRow.Cells[3].Value.ToString();
              //  AlumnoControlador.getMsgsFromConsulta(idConsultaPrivada, ciAlumno, ciDocente);

                AlumnoControlador.getMsgsFromConsulta(idConsultaPrivada, ciAlumno, ciDocente);

              /*  if (destinatario == ciAlumno)
                {
                    reply.txtMensajeDocente.Visible = true;
                    reply.lblNombreDocente.Visible = true;
                    reply.lblNombreDocente.Text = ciDocente;
                    reply.txtMensajeDocente.Text = AlumnoControlador.obtenerMensaje(idConsultaPrivada, ciDocente, destinatario);
                    reply.ShowDialog();
                }*/
                

                    //Cargo varlores de los campos en replyScreen y muestro la ventana
                    reply.lblNombreAlumno.Text = AlumnoControlador.obtenerRemitente(ciAlumno);
                    reply.txtMensajeAlumno.Text = AlumnoControlador.obtenerMensaje(idConsultaPrivada, ciAlumno, ciDocente);
                    reply.ShowDialog();

                
                
                MessageBox.Show("El destinatario es: " + AlumnoControlador.obtenerDestinatario(ciDocente));
            
        
    }
    }
}
