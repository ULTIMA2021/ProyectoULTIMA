
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace AppDocente.menuScreens
{
    public partial class configuracion : Form
    {

        public configuracion()
        {
            InitializeComponent();

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                /*
                   txtNombre.Text = Session.nombre;
                   txtApellido.Text = Session.apellido;
                   txtUsuario.Text = Session.cedula;
                   */
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
            //verificar que clave nueva no sea white spaces y que no sea la misma que la vieja
            if (Controlador.actualizarClavePersona(txtContraseñaAnterior.Text, txtNuevaContraseña.Text))
                MessageBox.Show("Nueva contraseña guardada!");
            else
                MessageBox.Show("La contraseña antigua fue ingresada mal");
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            DialogResult confirmDelete = MessageBox.Show("Realmente desea borrar su cuenta?", "", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == confirmDelete)
            {
                Controlador.bajaPersona();
                Application.Restart();
            }
        }
    }
}
