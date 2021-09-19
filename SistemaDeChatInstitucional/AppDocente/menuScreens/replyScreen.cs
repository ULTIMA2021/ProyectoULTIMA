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
        int idConsultaPrivada;
        int idMensaje;
        string ciAlumno;
        string ciDocente;
        List<List<string>> mensajes;
        string alumnoNombre;
        string status;

        public replyScreen(List<List<string>> mensajes, string asunto,string status)
        {
            cargarMensajesPrivados(mensajes,asunto);
            InitializeComponent();
            this.status = status;
            myLoad(this.status);
            ShowDialog();
            
        }
        private void cargarMensajesPrivados(List<List<string>> mensajes, string asunto)
        {
            this.mensajes = mensajes;
            idConsultaPrivada = Int32.Parse(mensajes[0][0]);
            idMensaje = mensajes.Count;
            ciDocente = Session.cedula;
            ciAlumno = mensajes[0][1];
            alumnoNombre = Controlador.traemeEstaPersona(ciAlumno);
            this.Text = $"{asunto} - @{alumnoNombre}";
        }
        private void myLoad(string status)
        {
            Padding dateP = new Padding(0, -1, 0, 10);
            Padding TextP = new Padding(0, -1, 0, -1);
            Padding namesP = new Padding(0, 10, 0, -1);

            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < mensajes.Count; i++)
            {
                Label fecha = new Label();
                Label nombrePersona = new Label();
                TextBox t = new TextBox();

                t.Multiline = true;
                t.WordWrap = true;
                t.ReadOnly = true;
                t.BackColor = Color.PowderBlue;
                t.Visible = true;
                t.Dock = DockStyle.Right;
                t.Width = this.flowLayoutPanel1.Width -25;
                t.Name = "t_" + i;
                t.BorderStyle = BorderStyle.None;
                t.Font = new Font("Arial", 8.25f);
                t.ForeColor = SystemColors.ControlText;

                nombrePersona.Font = new Font("Arial", 11, FontStyle.Bold);
                nombrePersona.Dock = DockStyle.Right;
                nombrePersona.AutoSize = true;
                nombrePersona.Name = "label_" + i;


                fecha.Font = new Font("Arial", 8.25f);
                fecha.Dock = DockStyle.Right;
                fecha.AutoSize = true;
                fecha.Name = "labelFecha_" + i;
                //fecha.BackColor = Color.PowderBlue;
                fecha.Text = mensajes[i][5];

                fecha.Margin = dateP;
                nombrePersona.Margin = namesP;
                t.Margin = TextP;

                if (mensajes[i][7] != Session.cedula)
                    nombrePersona.Text = $"{Session.nombre} {Session.apellido}";
                else
                {
                    t.BackColor = Color.PeachPuff;
                    t.Dock = DockStyle.Left;
                    nombrePersona.Text = alumnoNombre;
                    nombrePersona.Dock = DockStyle.Left;
                    fecha.Dock = DockStyle.Left;
                }
                t.Text = mensajes[i][4];

                int padding = 10;
                int numLines = t.GetLineFromCharIndex(t.TextLength) + 1;
                int border = t.Height - t.ClientSize.Height;
                t.Height = t.Font.Height * numLines + padding + border;

                this.flowLayoutPanel1.Controls.Add(nombrePersona);
                this.flowLayoutPanel1.Controls.Add(t);
                this.flowLayoutPanel1.Controls.Add(fecha);

            }
            if (status == "resuelta")
            {
                this.Controls.Remove(txtRespuesta);
                this.Controls.Remove(btnFinalizarConsulta);
                this.Controls.Remove(btnEnviar);
                this.Controls.Remove(panel1);
                this.Text = $"{this.Text}-FINALIZADA";
            }
            this.Select();

            flowLayoutPanel1.AutoScrollPosition = new Point(0, flowLayoutPanel1.DisplayRectangle.Height);
        }

        private void enviarMensaje()
        {
            DateTime fecha = DateTime.Now;
            List<string> newMsg = new List<string>();
            idMensaje++;
            Controlador.enviarMensaje(idMensaje, idConsultaPrivada, Int32.Parse(ciDocente), Int32.Parse(ciAlumno),
                                            txtRespuesta.Text, null, fecha, "recibido", Int32.Parse(ciAlumno));
            newMsg.Add(idMensaje.ToString());
            newMsg.Add(idConsultaPrivada.ToString());
            newMsg.Add(ciDocente);
            newMsg.Add(ciAlumno);
            newMsg.Add(txtRespuesta.Text);
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
                myLoad(status);
            }
        }

        private void replyScreen_Resize(object sender, EventArgs e)
        {
            myLoad(status);
        }

        private void replyScreen_Load(object sender, EventArgs e)
        {
            btnEnviar.Text = Resources.btnEnviar;
        }

        private void btnFinalizarConsulta_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(txtRespuesta);
            this.Controls.Remove(btnFinalizarConsulta);
            this.Controls.Remove(btnEnviar);
            this.Controls.Remove(panel1);
            Controlador.finalizarConsulta(idConsultaPrivada, int.Parse(ciDocente), int.Parse(ciAlumno));

        }
    }
}
