using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlumnoApp.Formulario_Alumno
{
    public partial class FormularioAlumno : Form
    {
        public FormularioAlumno()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            /*  abrirArchivo.Filter = "Archivo de Imagen|*.jpg|Archivo PNG|*.png|Todos los archivos|*.*";
              DialogResult resultado = abrirArchivo.ShowDialog();

              if(resultado == DialogResult.OK)
              {
                  fotoAlumno.Image = Image.FromFile(abrirArchivo.FileName);
              } */
            OpenFileDialog abrirArchivo = new OpenFileDialog();
            abrirArchivo.Filter = "Imagenes|*.jpg; *.png";
            abrirArchivo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            abrirArchivo.Title = "Seleccionar archivo";

            if(abrirArchivo.ShowDialog() == DialogResult.OK)
            {
                fotoAlumno.Image = Image.FromFile(abrirArchivo.FileName);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Login_Alumno_y_Docente.Login login = new Login_Alumno_y_Docente.Login();
            login.Show();
            this.Hide();
        }
    }
}
