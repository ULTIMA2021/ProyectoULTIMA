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
        bool fromUserList = false;
        bool hasEdited = false;
        char[] seperator = { ' ', ' ', ' ' };
        public UsuarioRegistro()
        {
            InitializeComponent();
            load();
        }
        public UsuarioRegistro(string ci, string nombre, string apellido, string apodo, string clave, List<int> checkedItems, int type, byte [] foto)
        {
            InitializeComponent();
            load();
            CenterToScreen();
            //loadDatos(ci, nombre, apellido, apodo, clave, checkedItems, type, foto);
        }
        public UsuarioRegistro(string ci, string nombre, string apellido, string apodo, string clave, List<List<string>> checkedItems, int type, byte[] foto)
        {
            InitializeComponent();
            load();
            CenterToScreen();
            NEWWWloadDatos(ci, nombre, apellido, apodo, clave, checkedItems, type, foto);
        }

        private void NEWWWloadDatos(string ci, string nombre, string apellido, string apodo, string clave, List<List<string>> checkedItems, int type, byte[]foto)
        {
            // [x][0]=idGrupo   [x][1]=nombreGrupo  [x][2]=idMateria   [x][3]=nombreMateria
            setFields(ci, nombre, apellido, type);
            switch (type)
            {
                case 1: //alumno
                    //todosMisGrupos = Controlador.gruposToListForRegister();
                    fromUserList = true;
                    lblApodo.Visible = true;
                    comboBoxUser.SelectedIndex = 1;
                    txtApodo.Text = apodo;
                    //checkTheseBoxes(checkedItems);
                    for (int x = 0; x < checkedItems.Count; x++)
                        for (int y = 0; y < clbOpciones.Items.Count; y++)
                            if (clbOpciones.Items[y].ToString().Split(seperator)[0] == checkedItems[x][0])
                                clbOpciones.SetItemCheckState(y, CheckState.Checked);
                    break;

                case 2: //docente
                        //todosMisGrupos = Controlador.grupoMateriaToListForRegister();
                    fromUserList = true;
                    lblApodo.Visible = false;
                    comboBoxUser.SelectedIndex = 2;
                    clbOpciones.DataSource = Controlador.grupoMateriaToListForModification();
                    clbOpciones.ClearSelected();

                    for (int x = 0; x < checkedItems.Count; x++)
                        for (int y = 0; y < clbOpciones.Items.Count; y++)
                            if (clbOpciones.Items[y].ToString().Split(seperator)[0] == checkedItems[x][1] && clbOpciones.Items[y].ToString().Split(seperator, 2)[1].Trim() == checkedItems[x][3])
                                clbOpciones.SetItemCheckState(y, CheckState.Checked);
                    break;

                case 3: //admin
                        //todosMisGrupos = Controlador.grupoMateriaToListForRegister();
                    fromUserList = true;
                    comboBoxUser.SelectedIndex = 3;
                    lblApodo.Visible = false;

                    break;
                case 4: //alumnotemp this is working dont fucking touch it
                    try
                    {
                        var ms = new MemoryStream(Controlador.obtenerFotoAlumnoTemp(ci));
                        pbFoto.Image = Image.FromStream(ms);
                    }
                    catch (Exception ex)
                    {
                        //Load the default image
                    }
                    lblApodo.Visible = true;
                    comboBoxUser.SelectedIndex = 1;
                    txtClaveVerificacion.Text = clave;
                    txtApodo.Text = apodo;
                    for (int x = 0; x < checkedItems.Count; x++)
                        for (int y = 0; y < clbOpciones.Items.Count; y++)
                            if (clbOpciones.Items[y].ToString().Split(seperator)[0] == checkedItems[x][0])
                                clbOpciones.SetItemCheckState(y, CheckState.Checked);
                    //checkTheseBoxes(checkedItems);
                    break;
            }
            txtClave.Enabled = false;
            txtClave.Visible = false;
            txtClaveVerificacion.Enabled = false;
            txtClaveVerificacion.Visible = false;
            lblClave.Visible = false;
            lblClaveVeri.Visible = false;
            label11.Visible = false;
            label17.Visible = false;
            txtApodo.Enabled = false;
            btnReset.Visible = true;
            groupBox1.Text = "Modificar usuario";
            txtClave.Text = clave;
            try
            {
                var ms = new MemoryStream(foto);
                pbFoto.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                //Load the default image
            }
        }

        private void setFields(string ci, string nombre, string apellido, int type)
        {
            comboBoxUser.SelectedIndex = type;
            txtCedula.Enabled = false;
            comboBoxUser.Enabled = false;

            txtCedula.Text = ci;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
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
            pbFoto.Enabled = false;
            txtApodo.Enabled = false;
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
                    if (!fromUserList)
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
                    if (fromUserList )
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
            lblApodoAst.Visible = true;
            pbFoto.Enabled = true;
            clbOpciones.Enabled = true;
            txtApodo.Enabled = true;
            changeFieldsForUser(comboBoxUser.SelectedIndex);
            Enabled = true;
        }
        private void changeFieldsForUser(int type)
        {
            lblApodoAst.Visible = true;
            txtApodo.Visible = true;
            lblApodo.Visible = true;
            clbOpciones.Visible = true;
            lblOptions.Visible = true;
            switch (type)
            {
                case 0:
                    foreach (TextBox txt in GetAll(this, typeof(TextBox)))
                        txt.Enabled = false;
                    btnIngresar.Enabled = false;
                    btnFoto.Enabled = false;
                    clbOpciones.Enabled = false;
                    break;
                case 1:
                    foreach (TextBox txt in GetAll(this, typeof(TextBox)))
                        txt.Enabled = true;
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
                        txt.Enabled = true;
                    btnIngresar.Enabled = true;
                    btnFoto.Enabled = true;
                    clbOpciones.Enabled = true;

                    lblApodoAst.Visible = false;
                    txtApodo.Visible = false;
                    lblApodo.Visible = false;
                    txtApodo.Enabled = false;
                    clbOpciones.DataSource = null;
                    clbOpciones.DataSource = Controlador.grupoMateriaToListForRegister();
                    clbOpciones.ClearSelected();
                    //lblOptions.Location = new Point(389, 32);
                    break;
                case 3:
                    foreach (TextBox txt in GetAll(this, typeof(TextBox)))
                        txt.Enabled = true;
                    btnIngresar.Enabled = true;
                    btnFoto.Enabled = true;

                    lblOptions.Visible = false;
                    lblApodoAst.Visible = false;
                    txtApodo.Visible = false;
                    lblApodo.Visible = false;
                    clbOpciones.Visible = false;
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult confirmLogout =
               MessageBox.Show("Esta accion le asignara a este usuario la cedula como clave.\nRealmente quiere hacer este cambio?"
               , "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == confirmLogout)
            {
                string encryptedPw = CryptographyUtils.doEncryption(txtCedula.Text,null, null);
                Controlador.actualizarClavePersona(int.Parse(txtCedula.Text),encryptedPw);
            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            if (txtCedula.ContainsFocus)
            {
                txtClave.Text = txtCedula.Text;
                txtClaveVerificacion.Text = txtCedula.Text;

            }
        }
    }
}
