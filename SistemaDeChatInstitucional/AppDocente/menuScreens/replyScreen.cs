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
    public partial class replyScreen : Form
    {
        int idConsultaPrivada;
        int idMensaje;
        string ciAlumno;
        string ciDocente;
        List<List<string>> mensajes;

        public replyScreen()
        {
            InitializeComponent();       
        }

        public replyScreen(List<List<string>> mensajes)
        {
            this.mensajes = mensajes;
            idConsultaPrivada = Int32.Parse(mensajes[0][0]);
            idMensaje = mensajes.Count;
            ciAlumno = mensajes[0][1];
            ciDocente = Session.cedula;

            InitializeComponent();
            Load();
            ShowDialog();
        }

        private void enviarMensaje()
        {
            DateTime fecha = DateTime.Today;
            List<string> newMsg = new List<string>();
            idMensaje++;
            Controlador.enviarMensaje(idMensaje, idConsultaPrivada, Int32.Parse(ciDocente), Int32.Parse(ciAlumno),
                                            txtRespuesta.Text, null, fecha, "recibido", Int32.Parse(ciDocente));
            newMsg.Add(idMensaje.ToString());
            newMsg.Add(idConsultaPrivada.ToString());
            newMsg.Add(ciDocente);
            newMsg.Add(ciAlumno);
            newMsg.Add(txtRespuesta.Text);
            newMsg.Add(null);
            newMsg.Add(fecha.ToString());
            newMsg.Add("recibido");
            newMsg.Add(ciAlumno);

            this.mensajes.Add(newMsg);

            txtRespuesta.Text = string.Empty;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }


        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtRespuesta.Text != "")
            {

                enviarMensaje();
                Load();
            }
        }

        private void Load()
        {
            flowLayoutPanel1.Controls.Clear();
            string alumnoNombre = Controlador.traemeEstaPersona(ciAlumno);
            for (int i = 0; i < mensajes.Count; i++)
            {
                Label br = new Label();
                Label nombrePersona = new Label();
                TextBox t = new TextBox();

                t.Enabled = false;
                t.Multiline = true;
                t.WordWrap = true;
                t.ReadOnly = true;
                t.BackColor = Color.PowderBlue;
                t.Visible = true;
                t.Dock = DockStyle.Right;
                t.Width = this.flowLayoutPanel1.Width - 40;
                t.Name = "t_" + i;
                t.BorderStyle = BorderStyle.None;

                nombrePersona.Font = new Font("Arial", 11, FontStyle.Bold);
                nombrePersona.Dock = DockStyle.Right;
                nombrePersona.AutoSize = true;
                nombrePersona.Name = "label_" + i;

                if (mensajes[i][7] != Session.cedula)
                    nombrePersona.Text = $"{Session.nombre} {Session.apellido}";
                else
                {
                    t.BackColor = Color.PeachPuff;
                    t.Dock = DockStyle.Left;
                    nombrePersona.Text = alumnoNombre;
                    nombrePersona.Dock = DockStyle.Left;
                }
                t.Text = mensajes[i][4];

                int padding = 3;
                int numLines = t.GetLineFromCharIndex(t.TextLength) + 1;
                int border = t.Height - t.ClientSize.Height;
                t.Height = t.Font.Height * numLines + padding + border;

                this.flowLayoutPanel1.Controls.Add(nombrePersona);
                this.flowLayoutPanel1.Controls.Add(t);
            }
            flowLayoutPanel1.AutoScrollPosition = new Point(0, flowLayoutPanel1.DisplayRectangle.Height);
        }
    }
}
