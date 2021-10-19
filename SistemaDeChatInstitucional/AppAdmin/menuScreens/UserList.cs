﻿using System;
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
        List<List<string>> personas = new List<List<string>>();   //[x][]=indice de alumnoTemp en app  [0]=ci  [1]=nombre  [2]=apellido  [3]=clave  grupos=[4]= type    [5]=apodo (if alumno)

        List<List<List<string>>> gruposMateriasDePersonas = new List<List<List<string>>>();
        //[x][][]=indice de alumnoTemp en app      [][x][]=indice de grupo de alumno   [][][0]=idGrupo  [][][1]=nombreGrupo   [][][2]=idMateria   [][][3]=nombreMateria

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
                //Label apodo = new Label();
                Label groups = new Label();

                Button btnActividad = new Button();
                Button btnModificar = new Button();
                Button btnBorrar = new Button();
                //Button btnConsultas = new Button();
                //Button btnSalas = new Button();

                loadToLists(x);
                Console.WriteLine("THIS PERSON HAS THE FOLLOWING GROUPS");

                ci = defineLabels(ci, $"lblCi_{x}", $"Ci:\n{personas[x][0]}");
                nombre = defineLabels(nombre, $"lblName_{x}", $"Nombre:\n{personas[x][1]}");
                apellido = defineLabels(apellido, $"lblApellido_{x}", $"Apellido:\n{personas[x][2]}");

                foto = definePictureBox(foto, $"pb_{x}", Controlador.obtenerFotoPersona(personas[x][0]));

                btnActividad = defineButton(btnActividad, $"btnActividad_{x}", "Activid");
                btnModificar = defineButton(btnModificar, $"btnModificar_{x}", "Modificar");
                btnBorrar = defineButton(btnBorrar, $"btnBorrar_{x}", "Borrar");
                //btnConsultas = defineButton(btnConsultas, $"btnConsultas_{x}","Consultas");
                //btnSalas = defineButton(btnSalas, $"btnSalas_{x}","Salas");

                switch (personas[x][4])
                {
                    case "S":
                        //apodo = defineLabels(apodo, $"lblApodo_{x}", $"Apodo:\n{personas[x][5]}");
                        groups = defineLabels(groups, $"g_{x}", prepareAlumnoGroupLabelText(x));
                        hori = defineFlowPanel(hori, $"flpHori_{x}", FlowDirection.LeftToRight,Color.LawnGreen);
                        vert = defineFlowPanel(vert, $"flpVert{x}", FlowDirection.TopDown, Color.LawnGreen);
                        break;
                    case "A":
                        
                        //apodo = defineLabels(apodo, $"lblApodo_{x}", $"Apodo:\n{personas[x][5]}");
                        groups = defineLabels(groups, $"g_{x}", "    ");
                        hori = defineFlowPanel(hori, $"flpHori_{x}", FlowDirection.LeftToRight, Color.Lavender);
                        vert = defineFlowPanel(vert, $"flpVert{x}", FlowDirection.TopDown, Color.Lavender);
                        break;
                    case "D":
                        //apodo = defineLabels(apodo, $"lblApodo_{x}", $"Apodo:\n{personas[x][5]}");
                        groups = defineLabels(groups, $"g_{x}", prepareDocenteGroupLabelText(x));
                        hori = defineFlowPanel(hori, $"flpHori_{x}", FlowDirection.LeftToRight, Color.PeachPuff);
                        vert = defineFlowPanel(vert, $"flpVert{x}", FlowDirection.TopDown, Color.PeachPuff);
                        break;
                }
                vert.Controls.Add(btnActividad);
                vert.Controls.Add(btnModificar);
                vert.Controls.Add(btnBorrar);
                //vert.Controls.Add(btnConsultas);
                //vert.Controls.Add(btnSalas);

                hori.Controls.Add(foto);
                hori.Controls.Add(ci);
                hori.Controls.Add(nombre);
                hori.Controls.Add(apellido);
                hori.Controls.Add(groups);
                hori.Controls.Add(vert);

                flowLayoutPanel1.Controls.Add(hori);
            }
        }
        private string prepareAlumnoGroupLabelText(int indexOfpersonInApp)
        {
            string target = "Grupos: ";
            for (int i = 0; i < gruposMateriasDePersonas[indexOfpersonInApp].Count; i++)
            {
                target = $"{target}\n{gruposMateriasDePersonas[indexOfpersonInApp][i][1]}";
                Console.WriteLine(gruposMateriasDePersonas[indexOfpersonInApp][i][1]);
            }
            return target;
        }
        private string prepareDocenteGroupLabelText(int indexOfpersonInApp)
        {
            string target = "Grupo/Materias: ";
            for (int i = 0; i < gruposMateriasDePersonas[indexOfpersonInApp].Count; i++)
            {
                target = $"{target}\n{gruposMateriasDePersonas[indexOfpersonInApp][i][1]}--{gruposMateriasDePersonas[indexOfpersonInApp][i][3]}";
                //Console.WriteLine(gruposMateriasDePersonas[indexOfpersonInApp][i][1]);
            }
            return target;
        }
        private void loadToLists(int indexOFAlumnoInApp)
        {
            foreach (List<string> persona in personas)
            {
                List<List <string>> grupoOrGrupoMateria = new List<List<string>>();
                if (persona[4] == "D")
                {
                    grupoOrGrupoMateria = Controlador.obtenerGrupoMaterias(persona[0]);
                }
                else if (persona[4] == "S")
                {
                    grupoOrGrupoMateria = Controlador.obtenerGrupos(int.Parse(persona[0]));
                }

                gruposMateriasDePersonas.Add(grupoOrGrupoMateria);
            }
        }
        private void preparelists()
        {
            gruposMateriasDePersonas.Clear();
            personas.Clear();
            personas = Controlador.obtenerPersona();
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
        private FlowLayoutPanel defineFlowPanel(FlowLayoutPanel flp, string flpName, FlowDirection dir, Color color)
        {
            flp.BackColor = color;
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
