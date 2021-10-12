using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace Login
{
    public partial class FormularioRegistro : Form
    {
        
        public FormularioRegistro()
        {
            InitializeComponent();
            CenterToScreen();
            load();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {

            string clave = @txtClave.Text;
            byte[] foto = { };
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
                foto = ms.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            if (txtClave.Text == txtClaveVerificacion.Text)
                try
                {
                    if (Controlador.existePersona(txtCedula.Text))
                    {
                        clave = CryptographyUtils.doEncryption(clave, null, null);
                        Console.WriteLine($"original password: {txtClave.Text}\nencrypted is {clave}");
                        Controlador.AltaAlumno(
                                                  txtCedula.Text,
                                                  txtNombre.Text,
                                                  txtApellido.Text,
                                                  clave,
                                                  txtApodo.Text,
                                                  foto,
                                                  getIndexesChecklist());

                        MessageBox.Show($"Ingresado! {txtNombre.Text} {txtApellido.Text}, espere que lo confirme un administrador");
                        resetFields();
                    }
                }catch (Exception ex) { MessageBox.Show(Controlador.errorHandler(ex)); }
            else
                MessageBox.Show("Las claves no son iguales");

            checkedListBox1.DataSource = Controlador.gruposToListForRegister();
        }

        private void load() {
            comboBoxUser.SelectedIndex = 0;
            label14.Visible = true;
            pbFoto.Enabled = true;
            txtApodo.Enabled = true;
            lblAsterix.Visible = false;
            lblGrupo.Text = "Grupo/s";
            checkedListBox1.DataSource = null;
            checkedListBox1.DataSource = Controlador.gruposToListForRegister();
        }

        private List<int> getIndexesChecklist() {
            List<int> checkedIndexes = new List<int>();
            int index;
            if (comboBoxUser.SelectedIndex == 0)
            {
                foreach (Object item in checkedListBox1.CheckedItems)
                {
                    index = checkedListBox1.Items.IndexOf(item) + 1;
                    checkedIndexes.Add(index);
                    //Console.WriteLine($" item: {item}   index of item in database:{ index}");
                }
            }
            return checkedIndexes;
        }

        private void comboBoxUser_SelectedValueChanged(object sender, EventArgs e)
        {
           // this.lblGrupo.Location= Point.;
        }

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

        private void resetFields() {
            txtApellido.Clear();
            txtNombre.Clear();
            txtCedula.Clear();
            txtApodo.Clear();
            txtClave.Clear();
            txtClaveVerificacion.Clear();
            pbFoto.Image = null;
            checkedListBox1.DataSource = null; 
        }

    }
}
