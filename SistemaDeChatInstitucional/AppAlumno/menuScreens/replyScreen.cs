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
    public partial class replyScreen : Form
    {
        int idConsultaPrivada;
        int idMensaje;
        string ciAlumno;
        string ciDocente;
        List<List<string>> mensajes;
        string docenteNombre;
        string status;


        public replyScreen()
        {
            InitializeComponent();
        }

        public replyScreen(List<List<string>> mensajes, string asunto, string status)
        {
            cargarVariables(mensajes,asunto);
            InitializeComponent();
            this.status = status;
            myLoad(this.status);
            ShowDialog();
        }

        private void cargarVariables(List<List<string>> mensajes, string asunto) {
            this.mensajes = mensajes;
            idConsultaPrivada = Int32.Parse(mensajes[0][0]);
            idMensaje = mensajes.Count;
            ciAlumno = Session.cedula;
            ciDocente = mensajes[0][2];
            docenteNombre = Controlador.traemeEstaPersona(ciDocente);
            this.Text = $"{asunto} - @{docenteNombre}";
        }

        private void enviarMensaje()
        {
            DateTime fecha = DateTime.Now;
            List<string> newMsg = new List<string>();
            idMensaje++;
            Controlador.enviarMensaje(idMensaje, idConsultaPrivada, Int32.Parse(ciDocente), Int32.Parse(ciAlumno),
                                            txtRespuesta.Text, null, fecha, "recibido", Int32.Parse(ciDocente));
            newMsg.Add(idMensaje.ToString());
            newMsg.Add(idConsultaPrivada.ToString());
            newMsg.Add(ciDocente);
            newMsg.Add(ciAlumno);
            newMsg.Add(txtRespuesta.Text);
            newMsg.Add(fecha.ToString());
            newMsg.Add("recibido");
            newMsg.Add(ciDocente);

            this.mensajes.Add(newMsg);

            txtRespuesta.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtRespuesta.Text != "")
            {
                enviarMensaje();
                myLoad(status);
            }
        }

        private void myLoad(string status)
        {
            Padding statP = new Padding(0, -1, 0, 10);
            Padding dateP = new Padding(0, -1, 0, -1);
            Padding TextP = new Padding(0, -1, 0, -1);
            Padding namesP = new Padding(0, 10, 0, -1);

            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < mensajes.Count; i++)
            {
                Label statuss = new Label();
                Label fecha = new Label();
                Label nombrePersona = new Label();
                TextBox t = new TextBox();

                t.Enabled = true;
                t.Multiline = true;
                t.WordWrap = true;
                t.ReadOnly = true;
                t.BackColor = Color.PowderBlue;
                t.Visible = true;
                t.Dock = DockStyle.Right;
                t.Width= this.flowLayoutPanel1.Width-40;
                t.Name = "t_" +i;
                t.BorderStyle = BorderStyle.None;
                t.Font = new Font("Arial", 8.25f);

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

                statuss.Font = new Font("Arial", 6.25f);
                statuss.ForeColor = Color.Red;
                statuss.Dock = DockStyle.Right;
                statuss.AutoSize = true;
                statuss.Name = "labelFecha_" + i;
                //fecha.BackColor = Color.PowderBlue;
                statuss.Text = mensajes[i][6];

                statuss.Margin = statP;
                fecha.Margin = dateP;
                nombrePersona.Margin = namesP;
                t.Margin = TextP;

                if(mensajes[i][6] == "leido")
                    statuss.ForeColor = Color.Green;

                if (mensajes[i][7] != Session.cedula)
                    nombrePersona.Text = $"{Session.nombre} {Session.apellido}";
                else{
                    t.BackColor = Color.PeachPuff;
                    t.Dock = DockStyle.Right;
                    nombrePersona.Text = docenteNombre;
                    nombrePersona.Dock = DockStyle.Left;
                    fecha.Dock = DockStyle.Left;
                    statuss.Dock = DockStyle.Left;
                }
                t.Text = mensajes[i][4];

                int padding = 10;
                int numLines = t.GetLineFromCharIndex(t.TextLength) + 1;
                int border = t.Height - t.ClientSize.Height;
                t.Height = t.Font.Height * numLines + padding + border;

                this.flowLayoutPanel1.Controls.Add(nombrePersona);
                this.flowLayoutPanel1.Controls.Add(t);
                this.flowLayoutPanel1.Controls.Add(fecha);
                this.flowLayoutPanel1.Controls.Add(statuss);

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

        private void replyScreen_SizeChanged(object sender, EventArgs e)
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
            Controlador.finalizarConsulta(idConsultaPrivada, int.Parse(ciDocente) ,int.Parse(Session.cedula));

        }
    }
}
