using System;
using System.Windows.Forms;

namespace AppAlumno.menuScreens
{
    public partial class misDocentes : Form
    {
        public delegate void CustomFormClosedHandler(object sender, FormClosedEventArgs e, string text);
        public event CustomFormClosedHandler CustomFormClosed;
        public misDocentes() => InitializeComponent();
        private void btnExit_Click(object sender, EventArgs e) => this.Dispose();
        private void misDocentes_FormClosed(object sender, FormClosedEventArgs e) => CustomFormClosed(sender, e, "Hello World!");
    }
}
