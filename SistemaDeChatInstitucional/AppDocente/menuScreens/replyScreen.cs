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
        int idMensaje;
        int ciAlumno;
        int ciDocente;
        
        public replyScreen()
        {
            InitializeComponent();
            
        }  

        public replyScreen(int idConsultaPrivada, int idMensaje, int ciDocente, int ciAlumno)
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
            idMensaje++;
            Controlador.enviarMensaje(idMensaje, idConsultaPrivada, ciDocente, ciAlumno,
                                            txtRespuesta.Text, null, fecha, "recibido", ciAlumno);
            
            Console.Write("ENVIADO!");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
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
                
                

               // this.Refresh();
                MessageBox.Show("Mensaje enviado.");
                txtRespuesta.Text = "";
                this.Close();
                
            }
        }
    }
}
