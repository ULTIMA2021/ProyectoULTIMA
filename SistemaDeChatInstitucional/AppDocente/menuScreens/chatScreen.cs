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
    public partial class chatScreen : Form
    {
        int idSala;
        string autorCi;
        bool newMsgs=true;

        List<List<string>> mensajes;

        public chatScreen(int idSala, string asunto, string nombreAnfitrion)
        {
            InitializeComponent();
            this.Text = $"{asunto} - @{nombreAnfitrion}";
            this.idSala = idSala;
            mensajes = Controlador.getMensajesDeSala(idSala);
            Load();
            ShowDialog();
        }

        private void Load()
        {

            if (newMsgs)
            {
                mensajes = Controlador.getMensajesDeSala(idSala);
                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < mensajes.Count; i++)
                {
                    autorCi = mensajes[i][2];


                    Label br = new Label();
                    Label nombrePersona = new Label();
                    TextBox t = new TextBox();

                    t.Enabled = true;
                    t.Multiline = true;
                    t.WordWrap = true;
                    t.ReadOnly = true;
                    t.BackColor = Color.PowderBlue;
                    t.Visible = true;
                    t.Dock = DockStyle.Right;
                    t.Width = this.flowLayoutPanel1.Width - 25;
                    t.Name = "t_" + i;
                    t.BorderStyle = BorderStyle.None;
                    t.Font = new Font("Arial", 8.25f);


                    nombrePersona.Font = new Font("Arial", 11, FontStyle.Bold);
                    nombrePersona.Dock = DockStyle.Right;
                    nombrePersona.AutoSize = true;
                    nombrePersona.Name = "label_" + i;

                    if (autorCi == Session.cedula)
                        nombrePersona.Text = $"{Session.nombre} {Session.apellido}";
                    else
                    {
                        t.BackColor = Color.PeachPuff;
                        t.Dock = DockStyle.Left;
                        nombrePersona.Text = mensajes[i][5];
                        nombrePersona.Dock = DockStyle.Left;
                    }
                    t.Text = mensajes[i][3];

                    int padding = 10;
                    int numLines = t.GetLineFromCharIndex(t.TextLength) + 1;
                    int border = t.Height - t.ClientSize.Height;
                    t.Height = t.Font.Height * numLines + padding + border;

                    this.flowLayoutPanel1.Controls.Add(nombrePersona);
                    this.flowLayoutPanel1.Controls.Add(t);
                }
                flowLayoutPanel1.AutoScrollPosition = new Point(0, flowLayoutPanel1.DisplayRectangle.Height);
            }
        }

        private void enviarMensaje()
        {
            autorCi = Session.cedula;

            DateTime fecha = DateTime.Today;
            List<string> newMsg = new List<string>();

            Controlador.enviarMensajeChat(idSala, int.Parse(autorCi), txtRespuesta.Text, fecha);

            newMsg.Add(idSala.ToString());
            newMsg.Add(null);
            newMsg.Add(autorCi);
            newMsg.Add(txtRespuesta.Text);
            newMsg.Add(fecha.ToString());
            newMsg.Add($"{Session.nombre} {Session.apellido}");
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


        private void replyScreen_Resize(object sender, EventArgs e)
        {
            Load();
        }
    }
}
