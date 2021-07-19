﻿
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
            if (AlumnoControlador.obtenerAlumno(Session.cedula))
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
        }

        private void btnGuardarContraseña_Click(object sender, EventArgs e)
        {
            //AlumnoControlador.actualizarClavePersona(txtContraseñaAnterior.Text, txtNuevaContraseña.Text);
            //verificar que clave nueva no sea white spaces
            if (AlumnoControlador.actualizarClavePersona(txtContraseñaAnterior.Text, txtNuevaContraseña.Text))
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
            DialogResult confirmDelete = MessageBox.Show("Realmente desea borrar su cuenta?", "", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == confirmDelete){
                AlumnoControlador.bajaPersona();
                Application.Restart();
            }
        }
    }
}
