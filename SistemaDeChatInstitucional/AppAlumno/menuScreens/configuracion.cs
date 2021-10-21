
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using CapaLogica;

namespace AppAlumno.menuScreens
{
    public partial class configuracion : Form
    {
        public delegate void CustomFormClosedHandler(object semder, FormClosedEventArgs e, string text);
        public event CustomFormClosedHandler CustomFormClosed;

        public configuracion() => InitializeComponent();
        private void btnExit_Click(object sender, EventArgs e) => this.Dispose();

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirFoto = new OpenFileDialog();
            abrirFoto.Filter = "Imagenes|*.jpg; *.png; *.jpeg";
            abrirFoto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            abrirFoto.Title = "Seleccionar imagen";

            if(abrirFoto.ShowDialog() == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(abrirFoto.FileName);
            }
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            // guardarFoto();
            if (Controlador.obtenerAlumno(Session.cedula))
            {
                   txtNombre.Text = Session.nombre;
                   txtApellido.Text = Session.apellido;
                   txtUsuario.Text = Session.cedula;
            }
        }

        private void guardarFoto()
        {
            MemoryStream ms = new MemoryStream();
            pbFoto.Image.Save(ms, ImageFormat.Jpeg);
            byte[] aByte = ms.ToArray();
            // aca se pone el metodo para la conexion con la BD
        }

        private void configuracion_Load(object sender, EventArgs e)
        {
            txtNombre.Text = Session.nombre;
            txtApellido.Text = Session.apellido;
            txtUsuario.Text = Session.cedula;

            //configuracionScreen
            lblNombre.Text = Resources.lblNombre;
            lblApellido.Text = Resources.lblApellido;
            lblUsuario.Text = Resources.lblUsuario;
            lblFoto.Text = Resources.lblFoto;
            lblCambiarPass.Text = Resources.lblCambiarPass;
            lblPassVieja.Text = Resources.lblPassVieja;
            lblPassNueva.Text = Resources.lblPassNueva;
            btnExaminar.Text = Resources.btnExaminar;
            btnGuardarContraseña.Text = Resources.btnGuardar;
            btnEliminarCuenta.Text = Resources.btnEliminarCuenta;
            btnExit.Text = Resources.btnExit;

        }

        private void btnGuardarContraseña_Click(object sender, EventArgs e)
        {
            //AlumnoControlador.actualizarClavePersona(txtContraseñaAnterior.Text, txtNuevaContraseña.Text);
            //verificar que clave nueva no sea white spaces
            if (Controlador.actualizarClavePersona(txtContraseñaAnterior.Text, txtNuevaContraseña.Text))
            {
                txtContraseñaAnterior.Clear();
                txtNuevaContraseña.Clear();
                MessageBox.Show("Nueva contraseña guardada!");
            }
            else
                MessageBox.Show("La contraseña antigua fue ingresada mal");
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            DialogResult confirmDelete = MessageBox.Show("Realmente desea borrar su cuenta?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == confirmDelete){
                try
                {
                    Controlador.bajaPersona(Session.cedula);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Controlador.bajaPersona();
                }
                //Controlador.bajaPersona();
                Application.Restart();
            }
        }

        private void configuracion_FormClosed(object sender, FormClosedEventArgs e) => CustomFormClosed(sender, e, "Hello World!");
        
    }
}
