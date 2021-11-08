using System;
using System.Windows.Forms;

namespace AppDocente.menuScreens
{
    public partial class agenda : Form
    {
        public delegate void CustomFormClosedHandler(object sender, FormClosedEventArgs e, string text);
        public event CustomFormClosedHandler CustomFormClosed;

        public agenda() => InitializeComponent();

        private void btnExit_Click(object sender, EventArgs e) => this.Dispose();

        private void agenda_Load(object sender, EventArgs e)
        {
            lblAsunto.Text = Resources.lblAsunto;
            lblGrupos.Text = Resources.lblGrupos;
        }

        private void agenda_FormClosed(object sender, FormClosedEventArgs e) => CustomFormClosed(sender, e, "Hello World!");
    }
}
