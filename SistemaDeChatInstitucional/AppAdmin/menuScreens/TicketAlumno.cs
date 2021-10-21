using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CapaLogica;

namespace AppAdmin.menuScreens
{
    public partial class TicketAlumno : Form
    {
        //List<List<string>> alumnos = Controlador.obtenerAlumnoTemp();
        List<List<string>> alumnos = new List<List<string>>();   //[x][]=indice de alumnoTemp en app     [0]=ci    nombre=[1]  apellido=[2]    apodo=[3]   grupos=[4]    clave=[5]
        List<List<List<string>>> gruposDeAlumnos = new List<List<List<string>>>();   //[x][][]=indice de alumnoTemp en app      [][x][]=indice de grupo de alumno   [][][0]=idGrupo  [][][1]=nombreGrupo
        List<byte[]> fotoDePersona = new List<byte[]>(); 
        Size pbSize = new Size(100, 100);
        Padding padHori = new Padding(3, 3, 3, 10);
        Padding padRestofControls = new Padding(3, 3, 3, 3);
        Padding padPicture = new Padding(10, 10, 3, 10);
        Font buttonFont = new Font("Cambria", 8, FontStyle.Bold);

        public TicketAlumno()
        {
            InitializeComponent();
            createControls();
        }

        private void createControls()
        {
            preparelists();
            for (int x = 0; x < alumnos.Count; x++)
            {
                FlowLayoutPanel hori = new FlowLayoutPanel();
                FlowLayoutPanel vert = new FlowLayoutPanel();
                PictureBox foto = new PictureBox();
                Label nombre = new Label();
                Label apellido = new Label();
                Label ci = new Label();
                Label apodo = new Label();
                Label groups = new Label();

                Button ingreso = new Button();
                Button modificar = new Button();
                Button delete = new Button();

                //ordeno los grupos de cada alumno en List<List<List<string>>> gruposDeAlumnos
                loadToLists(x);
                Console.WriteLine("THIS PERSON HAS THE FOLLOWING GROUPS");
                string groupnameText = prepareGroupLabelText(x);

                ci = defineLabels(ci, $"lblCi_{x}", $"Ci:\n{alumnos[x][0]}");
                nombre = defineLabels(nombre, $"lblName_{x}", $"Nombre:\n{alumnos[x][1]}");
                apellido = defineLabels(apellido, $"lblApellido_{x}", $"Apellido:\n{alumnos[x][2]}");
                apodo = defineLabels(apodo, $"lblApodo_{x}", $"Apodo:\n{alumnos[x][3]}");
                groups = defineLabels(groups, $"g_{x}", groupnameText);

                foto = definePictureBox(foto, $"pb_{x}", Controlador.obtenerFotoAlumnoTemp(alumnos[x][0]));

                hori = defineFlowPanel(hori, $"flpHori_{x}",FlowDirection.LeftToRight);
                vert = defineFlowPanel(vert,$"flpVert{x}",FlowDirection.TopDown);

                ingreso = defineButton(ingreso, $"btnIngreso_{x}");
                modificar = defineButton(modificar, $"btnModificar_{x}");
                delete = defineButton(delete, $"btnDelete_{x}");

                vert.Controls.Add(ingreso);
                vert.Controls.Add(modificar);
                vert.Controls.Add(delete);

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
        private string prepareGroupLabelText(int indexOFAlumnoInApp)
        {
            string target = "Grupos: ";
            for (int i = 0; i < gruposDeAlumnos[indexOFAlumnoInApp].Count; i++)
            {
                target = $"{target}\n{gruposDeAlumnos[indexOFAlumnoInApp][i][1]}";
                Console.WriteLine(gruposDeAlumnos[indexOFAlumnoInApp][i][1]);
            }
            return target;
        }
        private void loadToLists(int indexOFAlumnoInApp)
        {
            List<List<string>> grupos = new List<List<string>>();
            string[] idGrupo = System.Text.RegularExpressions.Regex.Split(alumnos[indexOFAlumnoInApp][4], @"\D+");
            foreach (string id in idGrupo)
            {
                List<string> grupo = new List<string>();
                grupo = Controlador.obtenerGrupo(id);
                grupos.Add(grupo);
            }
            gruposDeAlumnos.Add(grupos);
        }
        private void preparelists()
        {
            gruposDeAlumnos.Clear();
            alumnos.Clear();
            alumnos = Controlador.obtenerAlumnoTemp();
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
            fotoDePersona.Add(imgByte);
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
        private Button defineButton(Button b, string bName)
        {
            b.Dock = DockStyle.Fill;
            b.Name = bName;
            b.Font = buttonFont;
            b.Enabled = true;
            b.AccessibleName = bName;
            
            //aca se podria poner algun icon
            // b.Image = System.
            b.Anchor = AnchorStyles.None;

            if (bName.Contains("Ingreso"))
            {
                b.Click += new EventHandler(mybutton_Click_Ingreso);
                b.Text = "Ingresar";
            }
            else if (bName.Contains("Modificar"))
            {
                b.Click += new EventHandler(mybutton_Click_Modificacion);
                b.Text = "Modificar";
            }
            else
            {
                b.Click += new EventHandler(mybutton_Click_Delete);
                b.Text = "Borrar";
            }
            return b;
        }

        private List<int> GroupsToInt(int indexFromButton)
        {
            List<int> groupsToInt = new List<int>();
            for (int i = 0; i < gruposDeAlumnos[indexFromButton].Count; i++)
                groupsToInt.Add(int.Parse(gruposDeAlumnos[indexFromButton][i][0]));
            return groupsToInt;
        }

        private void mybutton_Click_Ingreso(object sender, EventArgs e)
        {
            Enabled = false;
            Button b = (Button)sender;
            int indexFromButton = int.Parse(b.AccessibleName.Substring(11));
            string ci = alumnos[indexFromButton][0];
            string nombre = alumnos[indexFromButton][1];
            string apellido = alumnos[indexFromButton][2];
            string apodo = alumnos[indexFromButton][3];
            string clave = alumnos[indexFromButton][5];
            List<int> groupsToInt = GroupsToInt(indexFromButton);
            //Console.WriteLine($"selected:\n{alumnos[indexFromButton][0]}\n{alumnos[indexFromButton][1]}\n{alumnos[indexFromButton][2]}\n{alumnos[indexFromButton][3]}\n{alumnos[indexFromButton][4]}");
            try
            {
                Controlador.AltaPersona(ci, nombre, apellido, clave,fotoDePersona[indexFromButton]);
                Controlador.AltaAlumno(ci,apodo,groupsToInt);
                Console.WriteLine($"PERSON IS NOW IN SYSTEM");
            }
            catch (Exception ex)
            {
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
            string ci = alumnos[indexFromButton][0];
            string nombre = alumnos[indexFromButton][1];
            string apellido = alumnos[indexFromButton][2];
            string apodo = alumnos[indexFromButton][3];
            string clave = alumnos[indexFromButton][5];
            List<int> groupsToInt = GroupsToInt(indexFromButton);
            new UsuarioRegistro(
                ci, 
                nombre, 
                apellido, 
                apodo, 
                clave, 
                gruposDeAlumnos[indexFromButton] ,
                4,
                fotoDePersona[indexFromButton]).ShowDialog();
            flowLayoutPanel1.Controls.Clear();
            createControls();
            Enabled = true;
        }
        private void mybutton_Click_Delete(object sender, EventArgs e)
        {

            Enabled = false;
            Button b = (Button)sender;
            int indexFromButton = int.Parse(b.AccessibleName.Substring(10));
            string ci = alumnos[indexFromButton][0];
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
        private void btnExit_Click(object sender, EventArgs e) => Dispose();
    }
}
