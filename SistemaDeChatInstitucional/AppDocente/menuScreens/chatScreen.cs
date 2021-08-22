using System;
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

namespace AppDocente.menuScreens
{
    public partial class chatScreen : Form
    {
        int idSala;
        string autorCi;
        List<List<string>> mensajes;
        List<List<string>> members;
        Timer timer;
        int membersOn;

        public chatScreen(int idSala, string asunto, string nombreAnfitrion,string anfitrion, bool isDone)
        {
            InitializeComponent();
            this.Text = $"{asunto} - @{nombreAnfitrion}";
            this.idSala = idSala;
            bool x = true;
            if (isDone)
            {
                btnFinalizar.Visible = false;
                txtRespuesta.Enabled = false;
                btnEnviar.Enabled = false;
                btnConectados.Visible = false;
                x = false;
            }
            if (anfitrion == Session.cedula && x)
                btnFinalizar.Visible = true;
        }
        private void timer_Tick(Object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("TIMER IS CHECKING " + DateTime.Now);
                if (Controlador.getMensajesDeSalaCount(idSala) > mensajes.Count)
                {
                    timer.Stop();
                    myLoad();
                }

                if (!Application.OpenForms.OfType<alumnosConectados>().Any())
                    if (Controlador.getPersonasEnSalaCount(idSala.ToString(), true) != membersOn)
                    {
                        timer.Stop();
                        setBtnText();
                        timer.Start();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }

        }
        private Timer setTimer()
        {
            timer = new Timer();
            timer.Interval = (1000 * 10);
            timer.Tick += new EventHandler(timer_Tick);
            return timer;
        }

        private void myLoad()
        {
            try
            {
                members = Controlador.getPersonasEnSala(idSala.ToString());
                mensajes = Controlador.getMensajesDeSala(idSala);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
            Padding dateP = new Padding(0,-1,0,10);
            Padding TextP = new Padding(0,-1,0,-1);
            Padding namesP = new Padding(0,10,0,-1);

            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < mensajes.Count; i++)
            {
                autorCi = mensajes[i][2];

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
                t.Width = this.flowLayoutPanel1.Width - 25;
                t.Name = "t_" + i;
                t.BorderStyle = BorderStyle.None;
                t.Font = new Font("Arial", 8.25f);

                nombrePersona.Font = new Font("Arial", 11, FontStyle.Bold);
                nombrePersona.Dock = DockStyle.Right;
                nombrePersona.AutoSize = true;
                nombrePersona.Name = "label_" + i;

                fecha.Font = new Font("Arial", 8.25f );
                fecha.Dock = DockStyle.Right;
                fecha.AutoSize = true;
                fecha.Name = "labelFecha_" + i;
                fecha.BackColor = Color.PowderBlue;
                fecha.Text = mensajes[i][4];

                fecha.Margin = dateP;
                nombrePersona.Margin = namesP;
                t.Margin = TextP;

                if (autorCi == Session.cedula){
                    nombrePersona.Text = $"{Session.nombre} {Session.apellido}";
                    nombrePersona.BackColor = Color.PowderBlue;
                }
                else
                {
                    t.BackColor = Color.PeachPuff;
                    t.Dock = DockStyle.Left;
                    nombrePersona.Text = mensajes[i][5];
                    nombrePersona.Dock = DockStyle.Left;
                    nombrePersona.BackColor = Color.PeachPuff;

                    fecha.BackColor = Color.PeachPuff;
                    fecha.Dock = DockStyle.Left;

                }
                t.Text = mensajes[i][3];

                int padding = 10;
                int numLines = t.GetLineFromCharIndex(t.TextLength) + 1;
                int border = t.Height - t.ClientSize.Height;
                t.Height = t.Font.Height * numLines + padding + border;

                this.flowLayoutPanel1.Controls.Add(nombrePersona);
                this.flowLayoutPanel1.Controls.Add(t);
                this.flowLayoutPanel1.Controls.Add(fecha);
            }
            timer.Start();
        }

        private void loadMembers() => members = Controlador.getPersonasEnSala(idSala.ToString());
        private void setBtnText()
        {
            loadMembers();
            List<List<string>> online = new List<List<string>>();
            List<List<string>> offline = new List<List<string>>();
            string tooltipOnline = "***PRESENTES\n__________";
            string tooltipOff = "***NO-PRESENTES\n__________";
            foreach (List<string> member in members)
            {
                if (Convert.ToBoolean(member[1]))
                {
                    if (member[0] == Session.cedula)
                        tooltipOnline = $"{tooltipOnline}\n  {member[2].ToString()} => *Docente*";
                    else
                        tooltipOnline = $"{tooltipOnline}\n  {member[2].ToString()}";
                    online.Add(member);
                }
                else
                {
                    if (member[0] == Session.cedula)
                        tooltipOff = $"{tooltipOff}\n  {member[2].ToString()}  => *Docente*";
                    else
                        tooltipOff = $"{tooltipOff}\n  {member[2].ToString()}";
                    offline.Add(member);
                }
                Console.WriteLine($"ci: {member[0].ToString()}\tstatus: {member[1].ToString()}\tnombrePersona:{member[2].ToString()}");
            }
            membersOn = online.Count;
            string btnText = $"{online.Count-1} / {members.Count-1}";
            btnConectados.Text = btnText;
            ToolTip tt = new ToolTip();
            tt.UseAnimation = true;

            tt.SetToolTip(this.btnConectados, $"{tooltipOnline}\n\n{tooltipOff}");
        }

        private void enviarMensaje()
        {
            autorCi = Session.cedula;

            DateTime fecha = DateTime.Now;
            List<string> newMsg = new List<string>();
            try
            {
                Controlador.enviarMensajeChat(idSala, int.Parse(autorCi), txtRespuesta.Text, fecha);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }

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
            timer.Dispose();
            Dispose();
            Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtRespuesta.Text != "")
            {
                timer.Stop();
                enviarMensaje();
                myLoad();
                flowLayoutPanel1.AutoScrollPosition = new Point(0, flowLayoutPanel1.DisplayRectangle.Height);
            }
        }

        private void replyScreen_Resize(object sender, EventArgs e)
        {
            timer.Stop();
            myLoad();
        }

        private void chatScreen_Load(object sender, EventArgs e)
        {
            timer = setTimer();
            myLoad();
            setBtnText();
            flowLayoutPanel1.AutoScrollPosition = new Point(0, flowLayoutPanel1.DisplayRectangle.Height);
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            string message = "Realmente quiere finalizar el chat grupal?\n\n\nNadie podra mandar mas mensajes a esta sala";
            string caption = "Porfavor confirme cerrada de sala";
            DialogResult result;
            result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Controlador.finalizarSala(idSala);
                this.Dispose();
                this.Close();
            }
        }

        private void chatScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Controlador.updateSalaConnection(idSala.ToString(), false);

            
            if (Application.OpenForms.OfType<alumnosConectados>().Any())
                
            timer.Stop();
            timer.Dispose();
            Dispose();
        }

        private void btnConectados_Click(object sender, EventArgs e)=> new alumnosConectados(idSala.ToString(),membersOn);
        
    }
}
