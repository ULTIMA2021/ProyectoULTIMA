using System;
using System.Windows.Forms;

namespace AppDocente.menuScreens
{
    public partial class agendaDocente : Form
    {
        public agendaDocente()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agendaDocente_Load(object sender, EventArgs e)
        {
            
            lblDia.Text = Resources.lblDia;
            lblHoraEntrada.Text = Resources.lblHoraEntrada;
            lblHoraSalida.Text = Resources.lblHoraSalida;
            btnGuardar.Text = Resources.btnGuardar;
            btnModificar.Text = Resources.btnModificar;
            btnExit.Text = Resources.btnExit;

            cbDia.Text = Resources.SeleccionarDia;            
            cbDia.Items[0] = Resources.Lunes;
            cbDia.Items[1] = Resources.Martes;
            cbDia.Items[2] = Resources.Miercoles;
            cbDia.Items[3] = Resources.Jueves;
            cbDia.Items[4] = Resources.Viernes;

        }

    }
}
