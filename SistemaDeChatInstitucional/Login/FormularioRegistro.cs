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
            this.CenterToScreen();
            load();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            if (txtClave.Text == txtClaveVerificacion.Text && txtCedula.Text.Length==8)
            {
                if (AlumnoControlador.existePersona(txtCedula.Text))
                {
                    AlumnoControlador.AltaPersona(txtCedula.Text, txtNombre.Text, txtApellido.Text, txtClave.Text);

                    if (this.comboBoxUser.SelectedIndex == 0) {
                        //    AlumnoControlador.AltaAlumno(txtCedula.Text, txtApodo.Text,List<int> indexesOfSelectedBoxes);
                        getIndexesChecklist();

                        if (checkedListBox1.CheckedItems.Count != 0)
                        { 
                            
                        }

                    } else if (this.comboBoxUser.SelectedIndex == 0)
                    {
                     //  AlumnoControlador.AltaDocente(txtCedula.Text, );

                    
                    } else
                    {
                        AlumnoControlador.AltaAdmin(txtCedula.Text);

                        
                    }
                    //MessageBox.Show(" Ingresado! espere que lo confirme un administrador");

                }
                else MessageBox.Show("Una persona con esa cedula ya existe");

            }
            else MessageBox.Show("Las contraseñas no coinciden");
            
        }

        private void load() {
            this.comboBoxUser.SelectedIndex = 0;
        }
        private List<int> getIndexesChecklist() {
            List<int> selectedIndexes = new List<int>();
            //selectedIndexes = (checkedListBox1.CheckedIndices);
            int index;
            foreach (Object item in checkedListBox1.SelectedItems)
            {
                 index= checkedListBox1.Items.IndexOf(item);
                Console.WriteLine("{0}:{1}", item, index);
            }


          //  for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
          

            return selectedIndexes;
        }
        private void comboBoxUser_SelectedValueChanged(object sender, EventArgs e)
        {

           // this.lblGrupo.Location= Point.;
            this.label14.Visible = true;
            this.lblAsterix.Visible = true;
            this.pbFoto.Enabled = true;
            this.pbFoto.Enabled = true;
            this.checkedListBox1.Enabled = true;
            this.txtApodo.Enabled = true;
            if (this.comboBoxUser.SelectedIndex == 0)
            {
                this.lblAsterix.Visible = false;
                //this.txtApodo.Enabled = false;
                this.lblGrupo.Text = "Grupo/s";
                this.checkedListBox1.DataSource = AlumnoControlador.gruposToListForRegister();
            }
            else if (this.comboBoxUser.SelectedIndex == 1)
            {
                this.lblAsterix.Visible = false;
                this.txtApodo.Enabled = false;
                this.lblGrupo.Text = "Grupo-materia";
                this.checkedListBox1.DataSource = AlumnoControlador.grupoMateriaToListForRegister();
            }
            else if (this.comboBoxUser.SelectedIndex == 2)
            {
                this.label14.Visible = false;
                this.lblAsterix.Visible = false;
                this.pbFoto.Enabled = false;
                this.pbFoto.Enabled = false;
                this.checkedListBox1.Enabled = false;
                this.txtApodo.Enabled = false;
                this.checkedListBox1.DataSource = null;

            }
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
    }
}
