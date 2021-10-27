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
        public delegate void CustomFormClosedHandler(object semder, FormClosedEventArgs e, string text);
        public event CustomFormClosedHandler CustomFormClosed;

        public NuevoMensaje() => InitializeComponent();


        private void btnExit_Click(object sender, EventArgs e) => this.Dispose();

        private void btnEnviar_Click(object sender, EventArgs e) => enviarMensaje();

        private void enviarMensaje()
        {
            string ciDocente = dgvListaDocentes.CurrentRow.Cells[0].Value.ToString();
            string titulo = txtAsunto.Text;
            DateTime fecha = DateTime.Now;
            int idConsultaPrivada = Controlador.GetidConsultaPrivada(int.Parse(ciDocente), int.Parse(Session.cedula));
            if (txtAsunto.Text == "")
            {
                MessageBox.Show("Debe ingresar un asunto.", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Controlador.prepararMensaje(idConsultaPrivada, ciDocente, Session.cedula, titulo, "pendiente", fecha);
                Controlador.enviarMensaje(1 ,idConsultaPrivada, int.Parse(ciDocente), int.Parse(Session.cedula),
                                                txtMensaje.Text, null, fecha, "recibido", int.Parse(ciDocente));
                MessageBox.Show("Mensaje enviado.", "Mensaje!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAsunto.Text = "";
                txtMensaje.Text = "";
                txtBuscarDocente.Text = "";
            }
        }

        private void NuevoMensaje_Load(object sender, EventArgs e)
        {
            dgvListaDocentes.DataSource = Controlador.obtenerDocentes();
            dgvListaDocentes.Columns["Cedula"].Visible = false;
            dgvListaDocentes.ClearSelection();

            lblBuscar.Text = Resources.lblBuscar;
            lblAsunto.Text = Resources.lblAsunto;
            lblObligatorio.Text = Resources.lblObligatorio;
            lblCaracteres.Text = Resources.lblCaracteres;
            btnEnviar.Text = Resources.btnEnviar;
        }

        private void NuevoMensaje_FormClosed(object sender, FormClosedEventArgs e) => CustomFormClosed(sender, e, "Hello World!");

    }
}