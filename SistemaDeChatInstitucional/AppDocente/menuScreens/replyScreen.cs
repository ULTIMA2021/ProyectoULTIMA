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
        public replyScreen()
        {
            InitializeComponent();
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
            //    int idConsultaPrivada = id
               // AlumnoControlador.prepararMensaje(idConsultaPrivada, ciDocente, Session.cedula, titulo, "pendiente", fecha);
           //     AlumnoControlador.enviarMensaje(1, idConsultaPrivada, Int32.Parse(ciDocente), Int32.Parse(Session.cedula),
            //        txtMensaje.Text, null, fecha, "recibido", Int32.Parse(ciDocente));
          //      MessageBox.Show("Mensaje enviado.", "Mensaje!", MessageBoxButtons.OK, MessageBoxIcon.Information);
           //     txtAsunto.Text = "";
           //     txtMensaje.Text = "";
           //     txtBuscarDocente.Text = "";

            }
        }
    }
}
