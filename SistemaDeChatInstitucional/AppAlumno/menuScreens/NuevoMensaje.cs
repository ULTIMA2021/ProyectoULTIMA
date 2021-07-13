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
            enviarMensaje();

        }

        private void enviarMensaje()
        {
            Console.WriteLine($"selected row: " + dgvListaDocentes.CurrentRow.Index);
            string ciDocente = AlumnoControlador.getCiFromDataGrid(dgvListaDocentes.CurrentRow.Index);

            string titulo = txtAsunto.Text;
            DateTime fecha = DateTime.Today;
            int idConsultaPrivada = AlumnoControlador.idConsultaPrivada(Int32.Parse(ciDocente), Int32.Parse(Session.cedula));

            if (txtAsunto.Text == "")
            {
                MessageBox.Show("Debe ingresar un asunto.", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                AlumnoControlador.prepararMensaje(idConsultaPrivada, ciDocente, Session.cedula, titulo, "pendiente", fecha);
                AlumnoControlador.enviarMensaje(idConsultaPrivada, Int32.Parse(ciDocente), Int32.Parse(Session.cedula),
                    txtMensaje.Text, "archivo", fecha, "recibido");
                MessageBox.Show("Mensaje enviado.", "Mensaje!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAsunto.Text = "";
                txtMensaje.Text = "";
                txtBuscarDocente.Text = "";

            }
        }

        private void NuevoMensaje_Load(object sender, EventArgs e)
        {

            dgvListaDocentes.DataSource = AlumnoControlador.obtenerDocentes(6);

        }
    }
}