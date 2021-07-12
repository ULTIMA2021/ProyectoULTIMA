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
    public partial class NuevoMensaje : Form
    {
        public NuevoMensaje()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string ciDocente = dgvListaDocentes.CurrentRow.Cells[0].Value.ToString();
            string titulo = txtAsunto.Text;
            DateTime fecha = DateTime.Today;
            int idConsultaPrivada = AlumnoControlador.idConsultaPrivada(Int32.Parse(ciDocente), Int32.Parse(Session.cedula));
         //   int idConsultaPrivada = AlumnoControlador.idConsultaPrivada(ciDocente, Session.cedula);
            
            
            AlumnoControlador.prepararMensaje(ciDocente, Session.cedula, titulo, "pendiente", fecha);
            AlumnoControlador.enviarMensaje(idConsultaPrivada, txtMensaje.Text, "archivo", fecha, "recibido");
        }

        private void NuevoMensaje_Load(object sender, EventArgs e)
        {
            dgvListaDocentes.DataSource = AlumnoControlador.obtenerDocentes();
        }
    }
}
