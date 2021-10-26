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


namespace AppAdmin.menuScreens
{
    public partial class chatScreen : Form
    {
        int idSala;
        string autorCi;
        List<List<string>> mensajes;
        string selectedUser;
        string nombre;
        string apellido;

        public chatScreen(int idSala, string asunto, string nombreAnfitrion,string anfitrion, bool isDone, string selectedUser, string nombre, string apellido)
        {
            InitializeComponent();
            this.Text = $"{asunto} - @{nombreAnfitrion}";
            this.idSala = idSala;
            this.selectedUser = selectedUser;
            this.nombre = nombre;
            this.apellido = apellido;
            myLoad();
            //flowLayoutPanel1.AutoScrollPosition = new Point(0, flowLayoutPanel1.DisplayRectangle.Height);
            
        }
        
        private void myLoad()
        {
            try
            {
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
               // fecha.BackColor = Color.PowderBlue;
                fecha.Text = mensajes[i][4];

                fecha.Margin = dateP;
                nombrePersona.Margin = namesP;
                t.Margin = TextP;

                if (autorCi == selectedUser ){
                    nombrePersona.Text = $"{nombre} {apellido}";
                   // nombrePersona.BackColor = Color.PowderBlue;
                }
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
                this.flowLayoutPanel1.Controls.Add(fecha);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void replyScreen_Resize(object sender, EventArgs e) => myLoad();

        private void chatScreen_FormClosing(object sender, FormClosingEventArgs e) => Dispose();
        
    }
}
