﻿using System;
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
        public int idConsultaPrivada;
        public string ciAlumno;
        List<List<string>> mensajes;
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

            idConsultaPrivada = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[0].Value.ToString());
            string indexDestinatario = dgvMisMensajes.CurrentRow.Cells[7].Value.ToString();
            string ciDocente;
            
            ciAlumno = dgvMisMensajes.CurrentRow.Cells[3].Value.ToString();
            ciDocente = Session.cedula;
            replyScreen reply = new replyScreen(idConsultaPrivada, Int32.Parse(Session.cedula), Int32.Parse(ciAlumno));
            
                mensajes = AlumnoControlador.getMsgsFromConsulta(idConsultaPrivada, ciAlumno, ciDocente);
                reply.lblNombreAlumno.Text = AlumnoControlador.traemeEstaPersona(ciAlumno);
                reply.txtMensajeAlumno.Text = mensajes[0][4];
                if (mensajes.Count >= 2)
                {
                    reply.txtMensajeDocente.Visible = true;
                    reply.lblNombreDocente.Visible = true;
                    reply.lblNombreDocente.Text = AlumnoControlador.traemeEstaPersona(ciDocente);
                    reply.txtMensajeDocente.Text = mensajes[1][4];
                    reply.btnEnviar.Enabled = false;
                    reply.txtRespuesta.Enabled = false;
                }
                reply.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            idConsultaPrivada = Int32.Parse(dgvMisMensajes.CurrentRow.Cells[0].Value.ToString());
            string indexDestinatario = dgvMisMensajes.CurrentRow.Cells[7].Value.ToString();
            string ciDocente;

            ciAlumno = dgvMisMensajes.CurrentRow.Cells[3].Value.ToString();
            ciDocente = Session.cedula;
            mensajes = AlumnoControlador.getMsgsFromConsulta(idConsultaPrivada, ciAlumno, ciDocente);
            new Form1(mensajes);
        }
    }
}
