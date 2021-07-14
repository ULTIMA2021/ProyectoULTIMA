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
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            int idconsultaPrivada = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[0].Value.ToString());
            string ciDocente;
            string ciAlumno;
            if (Session.type == 0)
            {
                ciAlumno = Session.cedula;
                ciDocente = dgvMisMensajes.CurrentRow.Cells[1].Value.ToString();
                //int idConsultaPrivada, string ciAlumno, string ciDocente
                AlumnoControlador.getMsgsFromConsulta(idconsultaPrivada,ciAlumno,ciDocente);
            }
                else if (Session.type == 1)
            {
                ciDocente = Session.cedula;
                ciAlumno = dgvMisMensajes.CurrentRow.Cells[2].Value.ToString();
                AlumnoControlador.getMsgsFromConsulta(idconsultaPrivada, ciAlumno, ciDocente);
            }
        }
    }
}
