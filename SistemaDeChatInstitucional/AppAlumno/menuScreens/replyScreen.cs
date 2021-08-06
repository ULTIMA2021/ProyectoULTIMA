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
    public partial class replyScreen : Form
    {
        DateTime fecha = DateTime.Today;
        int idConsultaPrivada;
        int idMensaje;
        public string ciAlumno;
        public string ciDocente;


        public replyScreen()
        {
            InitializeComponent();
           
        }

        public replyScreen(int idConsultaPrivada, int idMensaje, string ciDocente, string ciAlumno)
        {
            this.idConsultaPrivada = idConsultaPrivada;
            this.idMensaje = idMensaje;
            this.ciAlumno = ciAlumno;
            this.ciDocente = ciDocente;
            InitializeComponent();

        }



        public void openScreen(Form ventana)
        {

        
            ventana.TopLevel = false;
            ventana.Dock = DockStyle.Top;
            panelContenedor.Controls.Add(ventana);
            panelContenedor.Tag = ventana;
            ventana.BringToFront();
            ventana.Show();

        }

        private void enviarMensaje()
        {
            // idMensaje ++;
            // misMensajes m = new misMensajes();
            idMensaje++;
            Controlador.enviarMensaje(idMensaje, idConsultaPrivada, Int32.Parse(ciDocente), Int32.Parse(ciAlumno),
                                            txtRespuesta.Text, null, fecha, "recibido", Int32.Parse(ciDocente));

         //   txtMensajeDocente.Text = txtRespuesta.Text;
         //   lblNombreDocente.Text = AlumnoControlador.traemeEstaPersona(ciDocente.ToString());
         //   txtMensajeDocente.Visible = true;
         //   lblNombreDocente.Visible = true;
         //   txtRespuesta.Enabled = false;
            txtRespuesta.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if(txtRespuesta.Text != "")
            {
                enviarMensaje();

                MessageBox.Show("Mensaje enviado!");
                txtRespuesta.Text = "";
                this.Close();
            }

        }
    }
}
