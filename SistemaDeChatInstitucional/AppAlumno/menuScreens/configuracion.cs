
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

namespace AppAlumno.menuScreens
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
        }
    }
}
