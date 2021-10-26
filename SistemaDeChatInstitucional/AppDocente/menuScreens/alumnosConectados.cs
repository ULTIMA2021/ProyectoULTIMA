using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaLogica;

namespace AppDocente.menuScreens
{
    public partial class alumnosConectados : Form
    {
        List<List<string>> members;
        string idSala;
        Timer timer;
        int membersOn;

        public alumnosConectados(string idSala, int membersOn)
        {
            this.idSala = idSala;
            this.membersOn = membersOn;
            InitializeComponent();
            myLoad();
            Show();
        }
        private void timer_Tick(Object sender, EventArgs e)
        {
            Console.WriteLine($"ALUMNO TIMER IS CHECKING: {DateTime.Now}");
            try
            {
                int newOnline = Controlador.getPersonasEnSalaCount(idSala.ToString(), true);
                if (newOnline != membersOn)
                {
                    timer.Stop();
                    membersOn = newOnline;
                    myLoad();
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
            members = Controlador.getPersonasEnSala(idSala);
            flowPanelOnline.Controls.Clear();
            setFormName();
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i][0].ToString() != Session.cedula)
                {
                    FlowLayoutPanel hori = new FlowLayoutPanel();
                    Label ciValor = new Label();
                    Label nombrePersonaValor = new Label();
                    //Label foto;
                    setHorizontalPanelProperties(hori, i);
                    setNombreLabelProperties(nombrePersonaValor, i);
                    setCiLabelProperties(ciValor, i);

                    hori.Controls.Add(nombrePersonaValor);
                    hori.Controls.Add(ciValor);

                    setHorizontalPanelColor(bool.Parse(members[i][1]), hori);
                }
            }
            flowPanelOnline.Visible = true;
            setTimer();
            timer.Start();
        }
        private void setFormName()=> this.Text = $"Alumnos en linea: {membersOn-1} de {members.Count-1}";
        private void setNombreLabelProperties(Label nombrePersonaValor, int i)
        {
            nombrePersonaValor.Font = new Font("Arial", 11, FontStyle.Bold);
            nombrePersonaValor.Dock = DockStyle.Left;
            nombrePersonaValor.AutoSize = true;
            nombrePersonaValor.Name = "labelNombre_" + i;
            nombrePersonaValor.Text = $"Alumno: {members[i][2].ToString()}";
            Padding marginLabel = new Padding();
            marginLabel.Left = 10;
            marginLabel.Right = 10;
            nombrePersonaValor.Margin = marginLabel;
        }
        private void setCiLabelProperties(Label ciValor, int i)
        {
            ciValor.Font = new Font("Arial", 11, FontStyle.Bold);
            ciValor.Dock = DockStyle.Left;
            ciValor.AutoSize = true;
            ciValor.Name = "labelCi_" + i;
            ciValor.Text = $"Cedula: {members[i][0].ToString()}";
            Padding marginLabel = new Padding();
            marginLabel.Left = 10;
            marginLabel.Right = 10;
            ciValor.Margin = marginLabel;
        }
        private void setHorizontalPanelProperties(FlowLayoutPanel hori, int i)
        {
            hori.FlowDirection = FlowDirection.LeftToRight;
            hori.Dock = DockStyle.Fill;
            hori.Width = flowPanelOnline.Width -10;

            hori.Visible = true;
            hori.Name = "hori_" + i;
            hori.Anchor = AnchorStyles.Top & AnchorStyles.Left;
        }
        private void setHorizontalPanelColor(bool isConnected, FlowLayoutPanel hori)
        {
            if (isConnected)
            {
                hori.BackColor = Color.FromArgb(191, 255, 200);
                this.flowPanelOnline.Controls.Add(hori);
            }
            else
            {
                hori.BackColor = Color.FromArgb(255, 200, 200);
                this.flowPanelOnline.Controls.Add(hori);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Dispose();
        }

        private void replyScreen_Resize(object sender, EventArgs e)
        {
            timer.Stop();
            myLoad();
        }
        private void alumnosConectados_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            Dispose();
        }
    }
}
