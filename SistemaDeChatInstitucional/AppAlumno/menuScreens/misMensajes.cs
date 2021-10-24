﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        int idConsultaPrivada;
        string ciDocente;
        string ciAlumno;
        string asunto;
        string status;
        public delegate void CustomFormClosedHandler(object semder, FormClosedEventArgs e, string text);
        public event CustomFormClosedHandler CustomFormClosed;

        public misMensajes()
        {
            InitializeComponent();
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] instances = Process.GetProcessesByName(processName);
            if (instances.Length <= 1)
                Loadd();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            idConsultaPrivada = int.Parse(dgvMisMensajes.CurrentRow.Cells[0].Value.ToString());
            ciAlumno = Session.cedula;
            ciDocente = dgvMisMensajes.CurrentRow.Cells[2].Value.ToString();
            asunto = dgvMisMensajes.CurrentRow.Cells[4].Value.ToString();
            status = dgvMisMensajes.CurrentRow.Cells["Status"].Value.ToString();
            List<List<string>> mensajes = Controlador.getMsgsFromConsulta(idConsultaPrivada, ciAlumno, ciDocente);
            replyScreen r = new replyScreen(mensajes,asunto,status);
        }

        private void dgvMisMensajes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgvMisMensajes.Rows)
            {
                if ((String)Myrow.Cells["Status"].Value == "pendiente")
                {
                   Myrow.Cells[5].Style.BackColor = Color.FromArgb(250, 182, 37);
                                 
                }
                else if ((String)Myrow.Cells["Status"].Value == "resuelta")
                    Myrow.Cells[5].Style.BackColor = Color.FromArgb(113, 230, 72);
            }
        }
        private void Loadd()
        {
            dgvMisMensajes.DataSource = Controlador.ConsultasPrivada(Session.cedula, Session.type);
            dgvMisMensajes.Columns["idConsultaPrivada"].Visible = false;
            dgvMisMensajes.Columns["Alumno"].Visible = false;
            dgvMisMensajes.Columns["ciDocente"].Visible = false;
            dgvMisMensajes.Columns["Destinatario"].Visible = false;
            dgvMisMensajes.Columns["idMensaje"].Visible = false;
        }

        private void misMensajes_Load(object sender, EventArgs e)
        {
            lblBuscar.Text = Resources.lblBuscar;
            btnAbrir.Text = Resources.btnAbrir;
            btnEliminar.Text = Resources.btnEliminar;
            btnExit.Text = Resources.btnExit;

            dgvMisMensajes.Columns[4].HeaderText = Resources.lblAsunto;
            dgvMisMensajes.Columns[5].HeaderText = Resources.colStatus;
            dgvMisMensajes.Columns[6].HeaderText = Resources.colFecha;
            
            dgvMisMensajes.ClearSelection();
        }

        private void misMensajes_FormClosed(object sender, FormClosedEventArgs e)=> CustomFormClosed(sender, e, "Hello World!");
    }
}
