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
    public partial class replyScreen : Form
    {
        DateTime fecha = DateTime.Today;
        int idConsultaPrivada;
        int ciAlumno;
        int ciDocente;
        
        public replyScreen()
        {
            InitializeComponent();
        }

        public replyScreen(int idConsultaPrivada, int ciDocente, int ciAlumno)
        {
            this.idConsultaPrivada = idConsultaPrivada;
            this.ciAlumno = ciAlumno;
            this.ciDocente = ciDocente;

            InitializeComponent();
        }

        private void enviarMensaje()
        {
            misMensajes m = new misMensajes();

            AlumnoControlador.enviarMensaje(2, idConsultaPrivada, Int32.Parse(Session.cedula), ciAlumno,
                   txtRespuesta.Text, null, fecha, "recibido", ciAlumno);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtRespuesta.Text == "")
            {
                MessageBox.Show("Debe ingresar una respuesta.", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                enviarMensaje();
                MessageBox.Show("Mensaje enviado.", "Mensaje!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRespuesta.Text = string.Empty;
                

            }

             
        }
    }
}
