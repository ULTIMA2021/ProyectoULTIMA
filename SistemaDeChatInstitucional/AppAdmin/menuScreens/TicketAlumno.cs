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
        List<List<List<string>>> gruposDeAlumnos = new List<List<List<string>>>();   //[x][][]=indice de alumnoTemp en app      [][x][]=indice de grupo de alumno   [][][0]=idGrupo  [][][1]=nombreGrupo
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

                hori = defineFlowPanel(hori, $"flpHori_{x}");

                ingreso = defineButton(ingreso, $"btnIngreso_{x}");
                modificar = defineButton(modificar, $"btnModificar_{x}");
                delete = defineButton(delete, $"btnDelete_{x}");

                hori.Controls.Add(foto);
                hori.Controls.Add(ci);
                hori.Controls.Add(nombre);
                hori.Controls.Add(apellido);
                hori.Controls.Add(apodo);
                hori.Controls.Add(groups);
                hori.Controls.Add(ingreso);
               // hori.Controls.Add(modificar);
                hori.Controls.Add(delete);

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
                List<string> test = new List<string>();
                test = Controlador.obtenerGrupo(id);
                grupos.Add(test);
            }
            gruposDeAlumnos.Add(grupos);
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
            catch (Exception ex)
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

        private void btnExit_Click(object sender, EventArgs e) => Dispose();

        private void TicketAlumno_Load(object sender, EventArgs e)
        {

        }
    }
}
