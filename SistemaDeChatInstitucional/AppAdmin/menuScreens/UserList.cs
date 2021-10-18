using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CapaLogica;

namespace AppAdmin.menuScreens
{
    public partial class UserList : Form
    {
        //List<List<string>> alumnos = Controlador.obtenerAlumnoTemp();
        List<List<string>> personas = new List<List<string>>();   //[x][]=indice de alumnoTemp en app     [0]=ci    nombre=[1]  apellido=[2]    apodo=[3]   grupos=[4]    clave=[5]
        List<List<List<string>>> gruposMateriasDePersonas = new List<List<List<string>>>();   //[x][][]=indice de alumnoTemp en app      [][x][]=indice de grupo de alumno   [][][0]=idGrupo  [][][1]=nombreGrupo
        Size pbSize = new Size(100,100);
        Padding padHori = new Padding(3, 3, 3, 10);
        Padding padRestofControls = new Padding(3, 3, 3, 3);
        Padding padPicture = new Padding(10, 10, 3, 10);
        Font buttonFont = new Font("Cambria", 8, FontStyle.Bold);

        public UserList()
        {
            InitializeComponent();
            createControls();
        }

        private void createControls()
        {
            preparelists();
            for (int x = 0; x < personas.Count; x++)
            {
                FlowLayoutPanel hori = new FlowLayoutPanel();
                FlowLayoutPanel vert = new FlowLayoutPanel();
                PictureBox foto = new PictureBox();
                Label nombre = new Label();
                Label apellido = new Label();
                Label ci = new Label();
                Label apodo = new Label();
                Label groups = new Label();

                Button btnActividad = new Button();
                Button btnModificar = new Button();
                Button btnBorrar = new Button();
                //Button btnConsultas = new Button();
                //Button btnSalas = new Button();

                loadToLists(x);
                Console.WriteLine("THIS PERSON HAS THE FOLLOWING GROUPS");
                string groupnameText = prepareGroupLabelText(x);

                ci = defineLabels(ci, $"lblCi_{x}", $"Ci:\n{personas[x][0]}");
                nombre = defineLabels(nombre, $"lblName_{x}", $"Nombre:\n{personas[x][1]}");
                apellido = defineLabels(apellido, $"lblApellido_{x}", $"Apellido:\n{personas[x][2]}");
                apodo = defineLabels(apodo, $"lblApodo_{x}", $"Apodo:\n{personas[x][3]}");
                groups = defineLabels(groups, $"g_{x}", groupnameText);

                foto = definePictureBox(foto, $"pb_{x}", Controlador.obtenerFotoAlumnoTemp(personas[x][0]));

                hori = defineFlowPanel(hori, $"flpHori_{x}",FlowDirection.LeftToRight);
                vert = defineFlowPanel(vert,$"flpVert{x}",FlowDirection.TopDown);

                btnActividad = defineButton(btnActividad, $"btnActividad_{x}","Actividad");
                btnModificar = defineButton(btnModificar, $"btnModificar_{x}","Modificar");
                btnBorrar = defineButton(btnBorrar, $"btnBorrar_{x}","Borrar");
                //btnConsultas = defineButton(btnConsultas, $"btnConsultas_{x}","Consultas");
                //btnSalas = defineButton(btnSalas, $"btnSalas_{x}","Salas");

                vert.Controls.Add(btnActividad);
                vert.Controls.Add(btnModificar);
                vert.Controls.Add(btnBorrar);
                //vert.Controls.Add(btnConsultas);
                //vert.Controls.Add(btnSalas);

                hori.Controls.Add(foto);
                hori.Controls.Add(ci);
                hori.Controls.Add(nombre);
                hori.Controls.Add(apellido);
                hori.Controls.Add(apodo);
                hori.Controls.Add(groups);
                hori.Controls.Add(vert);

                flowLayoutPanel1.Controls.Add(hori);
            }
        }
        private string prepareGroupLabelText(int indexOfpersonInApp)
        {
            string target = "Grupos: ";
            for (int i = 0; i < gruposMateriasDePersonas[indexOfpersonInApp].Count; i++)
            {
                target = $"{target}\n{gruposMateriasDePersonas[indexOfpersonInApp][i][1]}";
                Console.WriteLine(gruposMateriasDePersonas[indexOfpersonInApp][i][1]);
            }
            return target;
        }
        private void loadToLists(int indexOFAlumnoInApp)
        {
            List<List<string>> grupos = new List<List<string>>();
            string[] idGrupo = System.Text.RegularExpressions.Regex.Split(personas[indexOFAlumnoInApp][4], @"\D+");
            foreach (string id in idGrupo)
            {
                List<string> grupo = new List<string>();
                grupo = Controlador.obtenerGrupo(id);
                grupos.Add(grupo);
            }
            gruposMateriasDePersonas.Add(grupos);
        }
        private void preparelists()
        {
            gruposMateriasDePersonas.Clear();
            personas.Clear();
            personas = Controlador.perso();
        }

        private Label defineLabels(Label lbl, string lblName, string lblText)
        {
            lbl.Font = new Font("Cambria", 10, FontStyle.Bold);
            lbl.ForeColor = Color.Black;
            lbl.Dock = DockStyle.Fill;
            lbl.Name = lblName;
            lbl.Text = lblText;
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            return lbl;
        }
        private PictureBox definePictureBox(PictureBox pb, string pbName, byte[] imgByte)
        {
            pb.Padding = padPicture;
            pb.Size = pbSize;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                var ms = new MemoryStream(imgByte);
                pb.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                //Load the default image
            }
            pb.Dock = DockStyle.Top;
            //pb.AutoSize = true;
            pb.Name = pbName;
            return pb;
        }
        private FlowLayoutPanel defineFlowPanel(FlowLayoutPanel flp, string flpName, FlowDirection dir)
        {
            flp.BackColor = Color.White;
            flp.BorderStyle = BorderStyle.FixedSingle;
            flp.FlowDirection = dir;
            flp.Name = flpName;
            flp.WrapContents = false;
            flp.AutoSize = true;
            flp.BorderStyle = BorderStyle.None;
            return flp;
        }
        private Button defineButton(Button b, string bName, string type)
        {
            b.Dock = DockStyle.Fill;
            b.Name = bName;
            b.Font = buttonFont;
            b.Enabled = true;
            b.AccessibleName = bName;
            
            //aca se podria poner algun icon
            // b.Image = System.
            b.Anchor = AnchorStyles.None;
            switch (type)
            {
                case "Modificar":
                    b.Click += new EventHandler(mybutton_Click_Modificacion);
                    b.Text = "Modificar";
                    break;
                case "Borrar":
                    b.Click += new EventHandler(mybutton_Click_btnBorrar);
                    b.Text = "Borrar";
                    break;
                case "Actividad":
                    b.Click += new EventHandler(mybutton_Click_Actividad);
                    break;
                //case "Consultas":
                //    b.Click += new EventHandler(mybutton_Click_btnConsultas);
                //    b.Text = "Consultas";
                //    break;
                //case "Salas":
                //    b.Click += new EventHandler(mybutton_Click_btnSalas);
                //    b.Text = "Salas";
                //    break;
            }
            return b;
        }

        private List<int> GroupsToInt(int indexFromButton)
        {
            List<int> groupsToInt = new List<int>();
            for (int i = 0; i < gruposMateriasDePersonas[indexFromButton].Count; i++)
                groupsToInt.Add(int.Parse(gruposMateriasDePersonas[indexFromButton][i][0]));
            return groupsToInt;
        }

        private void mybutton_Click_Actividad(object sender, EventArgs e)
        {
            Enabled = false;
            Button b = (Button)sender;
            int indexFromButton = int.Parse(b.AccessibleName.Substring(11));
            string ci = personas[indexFromButton][0];
            string nombre = personas[indexFromButton][1];
            string apellido = personas[indexFromButton][2];
            string apodo = personas[indexFromButton][3];
            string clave = personas[indexFromButton][5];
            List<int> groupsToInt = GroupsToInt(indexFromButton);
            Console.WriteLine($"selected:\n{personas[indexFromButton][0]}\n{personas[indexFromButton][1]}\n{personas[indexFromButton][2]}\n{personas[indexFromButton][3]}\n{personas[indexFromButton][4]}");

            try
            {
                Controlador.AltaPersona(ci, nombre, apellido, clave,null);
                Controlador.AltaAlumno(ci,apodo,groupsToInt);
                Console.WriteLine($"PERSON IS NOW IN SYSTEM");
            }
            catch (Exception ex)
            {
                //btnBorrar FROM PERSONA JUST INCASE SHIT FAILS
                Controlador.bajaPersona(ci);
                MessageBox.Show(Controlador.errorHandler(ex));
            }
            flowLayoutPanel1.Controls.Clear();
            createControls();
            Enabled = true;
        }
        private void mybutton_Click_Modificacion(object sender, EventArgs e)
        {
            Enabled = false;
            Button b = (Button)sender;
            int indexFromButton = int.Parse(b.AccessibleName.Substring(13));
            string ci = personas[indexFromButton][0];
            string nombre = personas[indexFromButton][1];
            string apellido = personas[indexFromButton][2];
            string apodo = personas[indexFromButton][3];
            string clave = personas[indexFromButton][5];
            List<int> groupsToInt = GroupsToInt(indexFromButton);
            new UsuarioRegistro(ci, nombre, apellido, apodo, clave, groupsToInt,4).ShowDialog();
            flowLayoutPanel1.Controls.Clear();
            createControls();
            Enabled = true;
        }
        private void mybutton_Click_btnBorrar(object sender, EventArgs e)
        {

            Enabled = false;
            Button b = (Button)sender;
            int indexFromButton = int.Parse(b.AccessibleName.Substring(10));
            string ci = personas[indexFromButton][0];
            try
            {
                Controlador.bajaAlumnoTemp(ci);
                flowLayoutPanel1.Controls.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
            flowLayoutPanel1.Controls.Clear();
            createControls();
            Enabled = true;
        }
        private void mybutton_Click_btnConsultas(object sender, EventArgs e)
        {

            Enabled = false;

            Enabled = true;
        }
        private void mybutton_Click_btnSalas(object sender, EventArgs e)
        {

            Enabled = false;
            
            Enabled = true;
        }
        private void btnExit_Click(object sender, EventArgs e) => Dispose();
    }
}
