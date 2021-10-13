using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace AppAdmin.menuScreens
{
    public partial class TicketAlumno : Form
    {
        //List<List<string>> alumnos = Controlador.obtenerAlumnoTemp();
        List<List<string>> alumnos = Controlador.obtenerAlumnoTemp();   //[x][]=indice de alumnoTemp en app     [0]=ci    nombre=[1]  apellido=[2]    apodo=[3]   grupos=[4]
        List<List<List<string>>> gruposDeAlumnos = new List<List<List<string>>>();   //[x][][]=indice de alumnoTemp en app      [][x][]=indice de grupo de alumno   [][][0]=id  [][][1]=name
        Size pbSize = new Size(111, 107);
        Padding padHori = new Padding(3, 3, 3, 10);
        Padding padRestofControls = new Padding(3, 3, 3, 3);
        Padding padPicture = new Padding(10, 10, 3, 10);

        Font buttonFont = new Font("Cambria", 9, FontStyle.Bold);

        public TicketAlumno()
        {
            InitializeComponent();
            createControls();
        }

        private void listarAlumnos_Load(object sender, EventArgs e)
        {

        }
        private void createControls()
        {
            //get alumnos temp

            for (int x = 0; x < alumnos.Count; x++)
            {
                FlowLayoutPanel hori = new FlowLayoutPanel();
                PictureBox foto = new PictureBox();
                Label nombre = new Label();
                Label apellido = new Label();
                Label ci = new Label();
                Label apodo = new Label();
                Label grupo = new Label();

                Button ingreso = new Button();
                Button modificar = new Button();
                Button delete = new Button();

                FlowLayoutPanel vert = new FlowLayoutPanel();

                vert = defineFlowPanel(vert, $"flpVert_{x}");
                vert.FlowDirection = FlowDirection.TopDown;
                //vert.Dock = DockStyle.Fill;
                vert.Size = pbSize;

                //labels for grupos y materias
                List<List<string>> grupos = new List<List<string>>();
                string[] idGrupo = System.Text.RegularExpressions.Regex.Split(alumnos[x][4], @"\D+");
                foreach (string id in idGrupo)
                {
                    List<string> test = new List<string>();
                    test = Controlador.obtenerGrupo(id);
                    grupos.Add(test);
                }
                gruposDeAlumnos.Add(grupos);
                Console.WriteLine("THIS PERSON HAS THE FOLLOWING GROUPS");

                for (int i = 0; i < gruposDeAlumnos[x].Count; i++)
                {
                    Label groupName = new Label();
                    groupName = defineLabels(groupName,$"g_{x}_{i}", gruposDeAlumnos[x][i][1]);
                    Console.WriteLine(gruposDeAlumnos[x][i][1]);
                    vert.Controls.Add(groupName);
                }

                //add values for the alumnos actual data from the list of objects alumno
                ci = defineLabels(ci, $"lblCi_{x}", $"Ci: {alumnos[x][0]}");
                nombre = defineLabels(nombre, $"lblName_{x}", $"Nombre: {alumnos[x][1]}");
                apellido = defineLabels(apellido, $"lblApellido_{x}", $"Apellido: {alumnos[x][2]}");
                apodo = defineLabels(apodo, $"lblApodo_{x}", $"Apodo: {alumnos[x][3]}");
                grupo = defineLabels(grupo, $"lblGrupo_{x}","Grupos:");

                foto = definePictureBox(foto, $"pb_{x}", Controlador.obtenerFotoAlumnoTemp(alumnos[x][0]));

                hori = defineFlowPanel(hori, $"flpHori_{x}");

                ingreso = defineButton(ingreso, $"btnIngreso_{x}");
                modificar = defineButton(modificar, $"btnModificar_{x}");
                delete = defineButton(delete, $"btnDelete_{x}");


                hori.Controls.Add(foto);
                hori.Controls.Add(ci);
                hori.Controls.Add(nombre);
                hori.Controls.Add(apellido);
                hori.Controls.Add(apodo);
                hori.Controls.Add(vert);

                hori.Controls.Add(ingreso);
               // hori.Controls.Add(modificar);
                hori.Controls.Add(delete);

                flowLayoutPanel1.Controls.Add(hori);
                //hori.BringToFront();
            }
        }

        private Label defineLabels(Label lbl, string lblName, string lblText)
        {
            lbl.Font = new Font("Cambria", 11, FontStyle.Bold);
            lbl.ForeColor = Color.Black;
            lbl.Dock = DockStyle.Fill;
            lbl.AutoSize = true;
            lbl.Name = lblName;
            lbl.AutoSize = true;
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
            catch (ArgumentNullException ex)
            {
                //Load the default image
            }
            pb.Dock = DockStyle.Top;
            //pb.AutoSize = true;
            pb.Name = pbName;
            return pb;
        }
        private FlowLayoutPanel defineFlowPanel(FlowLayoutPanel flp, string flpName)
        {
            flp.BackColor = Color.White;
            flp.BorderStyle = BorderStyle.FixedSingle;
            flp.FlowDirection = FlowDirection.LeftToRight;
            flp.Name = flpName;
            flp.WrapContents = false;
            flp.AutoSize = true;
            return flp;
        }
        private Button defineButton(Button b, string bName)
        {
            b.Dock = DockStyle.Fill;
            b.Name = bName;
            b.Font = buttonFont;
            b.Enabled = true;
            //aca se podria poner algun icon
            // b.Image = System.
            b.Anchor = AnchorStyles.None;
            //add events for modificar, delete, or ingreso
            if (bName.Contains("Ingreso"))
            {
                b.Text = "Ingreso";
            }
            else if (bName.Contains("Modificar"))
            {
                b.Text = "Modificar";
            }
            else
            {
                b.Text = "Delete";
            }
            return b;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TicketAlumno_Load(object sender, EventArgs e)
        {

        }
    }
}
