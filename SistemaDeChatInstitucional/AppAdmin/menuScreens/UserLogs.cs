using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CapaLogica;


namespace AppAdmin.menuScreens
{
    public partial class UserLogs : Form
    {
        string ci = "";
        string nombre = "";
        string apellido = "";


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        public UserLogs(string ci, string nombre, string apellido)
        {
            this.ci = ci;
            this.nombre = nombre;
            this.apellido = apellido;
            InitializeComponent();
        }

        private void dgvListarOrientaciones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) => dgvLogs.ClearSelection();
        

        private void userLogs_Load(object sender, EventArgs e)
        {
            DataTable t = new DataTable();
            t.Columns.Add("Login");
            t.Columns.Add("Logout");
            foreach (List<string>session  in Controlador.getUserLogs(ci))
                t.Rows.Add(session[0],session[1]);
            dgvLogs.DataSource = t;
            label1.Text = $"{ci}     {nombre} {apellido}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
