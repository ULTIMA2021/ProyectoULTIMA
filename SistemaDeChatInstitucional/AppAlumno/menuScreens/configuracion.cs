
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
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

            if (abrirFoto.ShowDialog() == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(abrirFoto.FileName);
            }
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            byte[] foto = { };
            try
            {
                MemoryStream ms = new MemoryStream();
                pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
                foto = ms.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Controlador.actualizarPersona(Session.cedula, txtNombre.Text, txtApellido.Text, Session.clave, foto);
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
            try
            {
                MemoryStream ms = new MemoryStream(Session.foto);
                pbFoto.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            { }

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
            try
            {

                MatchCollection numbers = Regex.Matches(txtNuevaContraseña.Text.Trim(), @"\d");
                foreach (Match m in numbers)
                {
                    Console.WriteLine(m);
                }
                MatchCollection symbols = Regex.Matches(txtNuevaContraseña.Text.Trim(), @"\W");
                foreach (Match m in symbols)
                {
                    Console.WriteLine(m);
                }
                MatchCollection smallletters = Regex.Matches(txtNuevaContraseña.Text.Trim(), @"[a-z]");
                foreach (Match m in smallletters)
                {
                    Console.WriteLine(m);
                }
                MatchCollection bigLetters = Regex.Matches(txtNuevaContraseña.Text.Trim(), @"[A-Z]");
                foreach (Match m in bigLetters)
                {
                    Console.WriteLine(m);
                }

                if (txtNuevaContraseña.Text.Trim().Length > 10 && symbols.Count > 0 && smallletters.Count > 0 && numbers.Count > 0 && bigLetters.Count > 0)
                    if (Controlador.actualizarClavePersona(txtContraseñaAnterior.Text, txtNuevaContraseña.Text, Session.cedula))
                    {
                        txtContraseñaAnterior.Clear();
                        txtNuevaContraseña.Clear();
                        MessageBox.Show("Nueva contraseña guardada!");
                    }
                    else
                        MessageBox.Show("La contraseña antigua fue ingresada mal");
                else
                    MessageBox.Show("La contraseña debe ser 10 caracteres de largo y debe contener por lo menos:\n\tun numero\n\tuna mayuscula\n\tuna minuscula\n\tun simbolo"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            DialogResult confirmDelete = MessageBox.Show("Realmente desea borrar su cuenta?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == confirmDelete)
            {
                try
                {
                    Controlador.bajaPersona(Session.cedula);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Controlador.deactivatePerson(Session.cedula, true);
                }
                //Controlador.bajaPersona();
                Application.Restart();
            }
        }

        private void configuracion_FormClosed(object sender, FormClosedEventArgs e) => CustomFormClosed(sender, e, "Hello World!");

    }
}
