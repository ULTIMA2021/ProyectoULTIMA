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
        int msgCount = 0;
        Padding statP = new Padding(0, -1, 0, 10);
        Padding dateP = new Padding(0, -1, 0, -1);
        Padding TextP = new Padding(0, -1, 0, -1);
        Padding namesP = new Padding(0, 10, 0, -1);

        public replyScreen()=>InitializeComponent();
        

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
            idConsultaPrivada = int.Parse(mensajes[0][0]);
            idMensaje = mensajes.Count;
            ciAlumno = Session.cedula;
            ciDocente = mensajes[0][2];
            docenteNombre = Controlador.traemeEstaPersona(ciDocente);
            this.Text = $"{asunto} - @{docenteNombre}";
            msgCount = mensajes.Count;
        }

        private void enviarMensaje()
        {
            DateTime fecha = DateTime.Now;
            List<string> newMsg = new List<string>();
            idMensaje++;
            Controlador.enviarMensaje(idMensaje, idConsultaPrivada, int.Parse(ciDocente), int.Parse(ciAlumno),
                                            txtRespuesta.Text, null, fecha, "recibido", int.Parse(ciDocente));
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

            msgCount = mensajes.Count;
        }

        private void button1_Click(object sender, EventArgs e) => Dispose();

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Enabled = false;
            if (txtRespuesta.Text != "")
            {
                enviarMensaje();
                Label statuss = new Label();
                Label fecha = new Label();
                Label nombrePersona = new Label();
                TextBox t = new TextBox();
                setMyLabels(msgCount - 1, nombrePersona, t, fecha, statuss);
                //myLoad(status);
            }
            Enabled = true;
        }

        private void myLoad(string status)
        {
            for (int i = 0; i < mensajes.Count; i++)
            {
                Label statuss = new Label();
                Label fecha = new Label();
                Label nombrePersona = new Label();
                TextBox t = new TextBox();

                setMyLabels(i, nombrePersona, t, fecha, statuss);
            }
            if (status == "resuelta")
            {
                this.Controls.Remove(txtRespuesta);
                this.Controls.Remove(btnFinalizarConsulta);
                this.Controls.Remove(btnEnviar);
                this.Controls.Remove(panel1);
                this.Text = $"{this.Text}-FINALIZADA";
            }
            btnEnviar.Text = Resources.btnEnviar;
        }
        private void setMyLabels(int i, Label nombrePersona, TextBox t, Label fecha, Label statuss)
        {
            if (mensajes[i][7] != Session.cedula)
            {
                setMsgtxtBox(t, mensajes[i][4], DockStyle.Right, Color.PowderBlue, AnchorStyles.Right, HorizontalAlignment.Right);
                setNombrePersonaLabel(nombrePersona, $"{Session.nombre} {Session.apellido}", DockStyle.Right, AnchorStyles.Right);
                setFechaLabel(fecha, mensajes[i][5], DockStyle.Right, AnchorStyles.Right);
                setStatusLabel(statuss, mensajes[i][6], DockStyle.Right, AnchorStyles.Right);
            }
            else
            {
                setMsgtxtBox(t, mensajes[i][4], DockStyle.Left, Color.PeachPuff, AnchorStyles.Left, HorizontalAlignment.Left);
                setNombrePersonaLabel(nombrePersona, docenteNombre, DockStyle.Left, AnchorStyles.Left);
                setFechaLabel(fecha, mensajes[i][5], DockStyle.Left, AnchorStyles.Left);
                setStatusLabel(statuss, mensajes[i][6], DockStyle.Left, AnchorStyles.Left);
            }
            this.flowLayoutPanel1.Controls.Add(nombrePersona);
            this.flowLayoutPanel1.Controls.Add(t);
            this.flowLayoutPanel1.Controls.Add(fecha);
            this.flowLayoutPanel1.Controls.Add(statuss);
            flowLayoutPanel1.AutoScrollPosition = new Point(0, flowLayoutPanel1.DisplayRectangle.Height);
        }
        private void setFechaLabel(Label fecha, string dateToDisplay, DockStyle dockStyle, AnchorStyles anchor)
        {
            fecha.Font = new Font("Arial", 8.25f);
            fecha.Dock = dockStyle;
            fecha.AutoSize = true;
            //fecha.Name = "labelFecha_" + i;
            //fecha.BackColor = Color.PowderBlue;
            fecha.Text = dateToDisplay;
            fecha.Margin = dateP;
            fecha.Anchor = anchor;
        }
        private void setStatusLabel(Label statuss, string statusToDisplay, DockStyle dockStyle, AnchorStyles anchor)
        {
            statuss.Font = new Font("Arial", 6.25f);
            statuss.ForeColor = Color.Red;
            statuss.Dock = dockStyle;
            statuss.AutoSize = true;
            //statuss.Name = "labelFecha_" + i;
            //fecha.BackColor = Color.PowderBlue;
            statuss.Text = statusToDisplay;
            statuss.Margin = statP;
            statuss.Anchor = anchor;
            if (statusToDisplay == "leido")
                statuss.ForeColor = Color.Green;
        }
        private void setNombrePersonaLabel(Label nombrePersona, string nameOfPerson, DockStyle dockStyle, AnchorStyles anchor)
        {
            nombrePersona.Font = new Font("Arial", 11, FontStyle.Bold);
            nombrePersona.Dock = dockStyle;
            nombrePersona.AutoSize = true;
            //nombrePersona.Name = "label_" + i;
            nombrePersona.Margin = namesP;
            nombrePersona.Text = nameOfPerson;
            nombrePersona.Anchor = anchor;
        }
        private void setMsgtxtBox(TextBox t, string textOfMsg, DockStyle dockStyle, Color color, AnchorStyles anchor, HorizontalAlignment txtAlignment)
        {
            t.Multiline = true;
            t.WordWrap = true;
            t.ReadOnly = true;
            t.BackColor = color;
            t.Visible = true;
            t.Dock = dockStyle;
            t.Width = this.flowLayoutPanel1.Width - 25;
            //t.Name = "t_" + i;
            t.BorderStyle = BorderStyle.None;
            t.Font = new Font("Arial", 8.25f);
            t.ForeColor = SystemColors.ControlText;
            t.Margin = TextP;
            t.Text = textOfMsg;
            t.Anchor = anchor;
            t.TextAlign = txtAlignment;

            int padding = 10;
            int numLines = t.GetLineFromCharIndex(t.TextLength) + 1;
            int border = t.Height - t.ClientSize.Height;
            t.Height = t.Font.Height * numLines + padding + border;
        }

        private void replyScreen_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            myLoad(status);
        }

        private void btnFinalizarConsulta_Click(object sender, EventArgs e)
        {
            Enabled = false;
            this.Controls.Remove(txtRespuesta);
            this.Controls.Remove(btnFinalizarConsulta);
            this.Controls.Remove(btnEnviar);
            this.Controls.Remove(panel1);
            Controlador.finalizarConsulta(idConsultaPrivada, int.Parse(ciDocente) ,int.Parse(Session.cedula));
            Enabled = true;

        }
    }
}
