using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CapaLogica;

namespace AppAdmin.menuScreens
{
    public partial class UsuarioRegistro : Form
    {

        char[] seperator = { ' ', ' ', ' ' };
        public UsuarioRegistro()
        {
            InitializeComponent();
            load();
        }
        public UsuarioRegistro(string ci, string nombre, string apellido, string apodo, string clave, List<int> checkedItems, int type)
        {
            InitializeComponent();
            load();
            CenterToScreen();
            loadDatos(ci, nombre, apellido, apodo, clave, checkedItems, type);
        }
        private void loadDatos(string ci, string nombre, string apellido, string apodo, string clave, List<int> checkedItems, int type)
        {
            setFields(ci, nombre, apellido, type);
            switch (type)
            {
                case 1: //alumno
                    //todosMisGrupos = Controlador.gruposToListForRegister();
                    comboBoxUser.SelectedIndex = 1;
                    txtApodo.Text = apodo;
                    checkTheseBoxes(checkedItems);
                    break;

                case 2: //docente
                        //todosMisGrupos = Controlador.grupoMateriaToListForRegister();
                    comboBoxUser.SelectedIndex = 2;

                    checkTheseBoxes(checkedItems);
                    break;

                case 4: //alumnotemp
                    comboBoxUser.SelectedIndex = 1;
                    txtClave.Text = clave;
                    txtClaveVerificacion.Text = clave;
                    txtClave.Enabled = false;
                    txtClaveVerificacion.Enabled = false;
                    txtApodo.Text = apodo;
                    checkTheseBoxes(checkedItems);


                    break;
            }
        }
        private void setFields(string ci, string nombre, string apellido, int type)
        {
            changeFieldsForUser(type);
            txtCedula.Enabled = false;
            comboBoxUser.Enabled = false;

            txtCedula.Text = ci;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            try
            {
                var ms = new MemoryStream(Controlador.obtenerFotoAlumnoTemp(ci));
                pbFoto.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                //Load the default image
            }
        }
        private void checkTheseBoxes(List<int> checkedItems)
        {
            for (int x = 0; x < checkedItems.Count; x++)
                for (int y = 0; y < clbOpciones.Items.Count; y++)
                    if (clbOpciones.Items[y].ToString().Split(seperator)[0] == checkedItems[x].ToString())
                        clbOpciones.SetItemCheckState(y, CheckState.Checked);
        }

        private void load()
        {
            comboBoxUser.SelectedIndex = 0;
            label14.Visible = true;
            pbFoto.Enabled = true;
            txtApodo.Enabled = true;
            lblApodoAst.Visible = false;
            clbOpciones.DataSource = null;
            clbOpciones.DataSource = Controlador.gruposToListForRegister();
        }

        private void btnExit_Click(object sender, EventArgs e) => Dispose();

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //-If persona does exist ask if they want to reactivate acc
            Enabled = false;
            if (txtClave.Text == txtClaveVerificacion.Text && txtCedula.Text.Length == 8)
            {
                try
                {
                    Console.WriteLine("this person is getting registered");
                    string safePW = txtClave.Text;
                    if (txtClave.Enabled == true)
                        safePW = CryptographyUtils.doEncryption(@txtClaveVerificacion.Text, null, null);
                    byte[] foto = { };
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
                        foto = ms.ToArray();
                    }
                    catch (Exception er)
                    { }
                    Controlador.AltaPersona(
                        txtCedula.Text.Trim(' '),
                        txtNombre.Text.Trim(' '),
                        txtApellido.Text.Trim(' '),
                        safePW, foto);
                    if (comboBoxUser.SelectedIndex == 1)
                    {
                        Controlador.AltaAlumno(txtCedula.Text, txtApodo.Text, getIndexesChecklist());
                        clbOpciones.DataSource = Controlador.gruposToListForRegister();
                    }
                    else if (comboBoxUser.SelectedIndex == 2)
                    {
                        Controlador.AltaDocente(txtCedula.Text, getIndexesChecklist());
                        clbOpciones.DataSource = Controlador.grupoMateriaToListForRegister();
                    }
                    else if (comboBoxUser.SelectedIndex == 3)
                        Controlador.AltaAdmin(txtCedula.Text);
                    if (txtClave.Enabled == false)
                        Dispose();
                    resetFields();
                }
                catch (Exception ex)
                { Controlador.errorHandler(ex); }
            }
            else MessageBox.Show("Las contraseñas no coinciden");

            Enabled = true;
        }
        private void resetFields()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtCedula.Clear();
            txtApodo.Clear();
            txtClave.Clear();
            txtClaveVerificacion.Clear();
            clbOpciones.DataSource = null;
            comboBoxUser.SelectedIndex = 0;
            pbFoto.Image = null;
        }
        private List<int> getIndexesChecklist()
        {
            List<int> checkedIndexes = new List<int>();
            int index;
            if (comboBoxUser.SelectedIndex == 1)
            {
                foreach (Object item in clbOpciones.CheckedItems)
                {
                    index = clbOpciones.Items.IndexOf(item) + 1;
                    checkedIndexes.Add(index);
                    Console.WriteLine($" item: {item}   index of item in database:{ index}");
                }
            }
            else if (comboBoxUser.SelectedIndex == 2)
            {
                foreach (Object item in clbOpciones.CheckedItems)
                {
                    index = clbOpciones.Items.IndexOf(item);
                    checkedIndexes.Add(index);
                    Console.WriteLine($" item: {item}   index of item in database:{ index + 1}");
                }
            }

            return checkedIndexes;
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirFoto = new OpenFileDialog();
            abrirFoto.Filter = "Imagenes|*.jpg; *.png; *.jpeg";
            abrirFoto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            abrirFoto.Title = "Seleccionar imagen";

            if (abrirFoto.ShowDialog() == DialogResult.OK)
                pbFoto.Image = Image.FromFile(abrirFoto.FileName);
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enabled = false;
            // this.lblGrupo.Location= Point.;
            lblApodoAst.Visible = true;
            pbFoto.Enabled = true;
            clbOpciones.Enabled = true;
            txtApodo.Enabled = true;
            changeFieldsForUser(comboBoxUser.SelectedIndex);
            Enabled = true;
        }
        private void changeFieldsForUser(int type)
        {
            switch (type)
            {
                case 0:
                    foreach (TextBox txt in GetAll(this, typeof(TextBox)))
                    {
                        txt.Enabled = false;
                    }
                    btnIngresar.Enabled = false;
                    btnFoto.Enabled = false;
                    clbOpciones.Enabled = false;
                    break;
                case 1:
                    foreach (TextBox txt in GetAll(this, typeof(TextBox)))
                    {
                        txt.Enabled = true;
                    }
                    btnIngresar.Enabled = true;
                    btnFoto.Enabled = true;
                    clbOpciones.Enabled = true;

                    lblApodoAst.Visible = true;
                    clbOpciones.DataSource = null;
                    clbOpciones.DataSource = Controlador.gruposToListForRegister();
                    clbOpciones.ClearSelected();
                    //lblOptions.Location = new Point(441, 32);
                    break;
                case 2:
                    foreach (TextBox txt in GetAll(this, typeof(TextBox)))
                    {
                        txt.Enabled = true;
                    }
                    btnIngresar.Enabled = true;
                    btnFoto.Enabled = true;
                    clbOpciones.Enabled = true;

                    lblApodoAst.Visible = false;
                    txtApodo.Enabled = false;
                    clbOpciones.DataSource = null;
                    clbOpciones.DataSource = Controlador.grupoMateriaToListForRegister();
                    clbOpciones.ClearSelected();
                    //lblOptions.Location = new Point(389, 32);
                    break;
                case 3:
                    foreach (TextBox txt in GetAll(this, typeof(TextBox)))
                    {
                        txt.Enabled = true;
                    }
                    btnIngresar.Enabled = true;
                    btnFoto.Enabled = true;

                    lblApodoAst.Visible = false;
                    pbFoto.Enabled = false;
                    clbOpciones.Enabled = false;
                    txtApodo.Enabled = false;
                    clbOpciones.DataSource = null;
                    break;
            }
        }

        private IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
    }
}
