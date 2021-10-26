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
        List<List<string>> personas = new List<List<string>>();   //[x][]=indice de alumnoTemp en app  [0]=ci  [1]=nombre  [2]=apellido  [3]=clave  [4]= type    [5]=apodo (if alumno)

        List<List<List<string>>> gruposMateriasDePersonas = new List<List<List<string>>>();
        //[x][][]=indice de alumnoTemp en app      [][x][]=indice de grupo de alumno   [][][0]=idGrupo  [][][1]=nombreGrupo  (SOLO ALUMNOS[][][2]=isDeleted)    DOCENTES( [][][2]=idMateria   [][][3]=nombreMateria   [][][4]=isDeleted )

        int indexOfControl = -1;

        List<byte[]> fotoDePersona = new List<byte[]>();

        Size pbSize = new Size(100, 100);
        Padding padHori = new Padding(3, 3, 3, 10);
        Padding padRestofControls = new Padding(10, 0, 10, 0);
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
                FlowLayoutPanel flpHori = new FlowLayoutPanel();
                FlowLayoutPanel flpVert = new FlowLayoutPanel();
                FlowLayoutPanel flpSpacer = new FlowLayoutPanel();

                PictureBox foto = new PictureBox();
                Label nombre = new Label();
                Label apellido = new Label();
                Label ci = new Label();
                //Label apodo = new Label();
                Label groups = new Label();

                Button btnActividad = new Button();
                Button btnModificar = new Button();
                Button btnBorrar = new Button();
                Button btnDeActivate = new Button();
                //Button btnSalas = new Button();

                loadToLists(x);

                ci = defineLabels(ci, $"lblCi_{x}", $"Ci:\n{personas[x][0]}");
                nombre = defineLabels(nombre, $"lblName_{x}", $"Nombre:\n{personas[x][1]}");
                apellido = defineLabels(apellido, $"lblApellido_{x}", $"Apellido:\n{personas[x][2]}");

                fotoDePersona.Add(Controlador.obtenerFotoPersona(personas[x][0]));
                foto = definePictureBox(foto, $"pb_{x}", fotoDePersona[x]);

                btnActividad = defineButton(btnActividad, $"btnActividad_{x}", "Actividad");
                btnModificar = defineButton(btnModificar, $"btnModificar_{x}", "Modificar");
                btnBorrar = defineButton(btnBorrar, $"btnBorrar_{x}", "Borrar");
                btnDeActivate = defineButton(btnDeActivate, $"btnDeActivate_{x}","Desactivar");
                //btnSalas = defineButton(btnSalas, $"btnSalas_{x}","Salas");
                EventHandler clickOnPerson = new EventHandler(myflowLayoutPanel_Click_flpHori);

                switch (personas[x][4])
                {
                    case "1": //alumno
                        //apodo = defineLabels(apodo, $"lblApodo_{x}", $"Apodo:\n{personas[x][5]}");
                        groups = defineLabels(groups, $"g_{x}", prepareAlumnoGroupLabelText(x));
                        flpHori = defineFlowPanel(flpHori, $"flpHori_{x}", FlowDirection.LeftToRight, Color.PowderBlue);
                        flpVert = defineFlowPanel(flpVert, $"flpVert_{x}", FlowDirection.TopDown, Color.PowderBlue);
                        flpSpacer.BackColor = Color.PowderBlue;
                        flpHori.Click += clickOnPerson;
                        groups.Click += clickOnPerson;
                        nombre.Click += clickOnPerson;
                        apellido.Click += clickOnPerson;
                        ci.Click += clickOnPerson;
                        foto.Click += clickOnPerson;
                        break;
                    case "2": //docente
                        //apodo = defineLabels(apodo, $"lblApodo_{x}", $"Apodo:\n{personas[x][5]}");
                        groups = defineLabels(groups, $"g_{x}", prepareDocenteGroupLabelText(x));
                        flpHori = defineFlowPanel(flpHori, $"flpHori_{x}", FlowDirection.LeftToRight, Color.PeachPuff);
                        flpVert = defineFlowPanel(flpVert, $"flpVert_{x}", FlowDirection.TopDown, Color.PeachPuff);
                        flpSpacer.BackColor = Color.PeachPuff;
                        // EventHandler clickOnPerson = new EventHandler(myflowLayoutPanel_Click_flpHori);
                        flpHori.Click += clickOnPerson;
                        groups.Click += clickOnPerson;
                        nombre.Click += clickOnPerson;
                        apellido.Click += clickOnPerson;
                        ci.Click += clickOnPerson;
                        foto.Click += clickOnPerson;
                        break;
                    case "3": //admin
                        //apodo = defineLabels(apodo, $"lblApodo_{x}", $"Apodo:\n{personas[x][5]}");
                        groups = defineLabels(groups, $"g_{x}", "    ");
                        flpHori = defineFlowPanel(flpHori, $"flpHori_{x}", FlowDirection.LeftToRight, Color.PaleVioletRed);
                        flpVert = defineFlowPanel(flpVert, $"flpVert_{x}", FlowDirection.TopDown, Color.PaleVioletRed);
                        flpSpacer.BackColor = Color.PaleVioletRed;
                        break;
                }
                flpVert.Controls.Add(btnActividad);
                flpVert.Controls.Add(btnModificar);
                flpVert.Controls.Add(btnBorrar);
                flpVert.Controls.Add(btnDeActivate);
                //vert.Controls.Add(btnSalas);


                flpHori.Controls.Add(foto);
                flpHori.Controls.Add(ci);
                flpHori.Controls.Add(nombre);
                flpHori.Controls.Add(apellido);
                flpHori.Controls.Add(groups);

                flpSpacer.AutoSize = false;
                flpSpacer.Height = 2;
                flpSpacer.Width = flowLayoutPanel1.Width - (ci.Width + foto.Width + nombre.Width + apellido.Width + groups.Width + flpVert.Width + 3);

                flpHori.Controls.Add(flpSpacer);
                flpHori.Controls.Add(flpVert);

                flowLayoutPanel1.Controls.Add(flpHori);
            }
        }
        private string prepareAlumnoGroupLabelText(int indexOfpersonInApp)
        {
            string target = "Grupos: ";
            for (int i = 0; i < gruposMateriasDePersonas[indexOfpersonInApp].Count; i++)
            {
                target = $"{target}\n{gruposMateriasDePersonas[indexOfpersonInApp][i][1]}";
                if (gruposMateriasDePersonas[indexOfpersonInApp][i][2] == "True")
                    target = $"{target}--ARCHIVADO";
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
                if (gruposMateriasDePersonas[indexOfpersonInApp][i][4] == "True")
                    target = $"{target}--ARCHIVADO";
            }
            return target;
        }
        private void loadToLists(int indexOFAlumnoInApp)
        {
            foreach (List<string> persona in personas)
            {
                List<List<string>> grupoOrGrupoMateria = new List<List<string>>();
                if (persona[4] == "2") //docente 
                {
                    grupoOrGrupoMateria = Controlador.obtenerGrupoMaterias(persona[0]);
                }
                else if (persona[4] == "1") //alumno
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
            fotoDePersona.Clear();
            personas = Controlador.obtenerPersona();
        }

        private Label defineLabels(Label lbl, string lblName, string lblText)
        {
            lbl.Font = new Font("Cambria", 10, FontStyle.Bold);
            lbl.ForeColor = Color.Black;
            lbl.Dock = DockStyle.Fill;
            lbl.Name = lblName;
            lbl.AccessibleName = lblName;
            lbl.Text = lblText;
            lbl.Margin = padRestofControls;
            lbl.AutoSize = true;
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
            pb.AccessibleName = pbName;
            return pb;
        }
        private FlowLayoutPanel defineFlowPanel(FlowLayoutPanel flp, string flpName, FlowDirection dir, Color color)
        {
            flp.AccessibleName = flpName;
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
            b.BackColor = Color.White;

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
                    b.Text = "Actividad";
                    break;
                case "Desactivar":
                    b.Click += new EventHandler(mybutton_Click_btnDeActivate);
                    b.Text = "Desactivar";
                    break;
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

        private void myflowLayoutPanel_Click_flpHori(object sender, EventArgs e)
        {
            Enabled = false;

            Control x = (Control)sender;
            indexOfControl = int.Parse(x.AccessibleName.Substring(x.AccessibleName.IndexOf('_') + 1));
            Console.WriteLine(indexOfControl);
            loadDGV();
            Enabled = true;
        }
        private void loadDGV()
        {
            try
            {
                dgvListarConsultasPrivs.DataSource = null;
                dgvSalas.DataSource = null;
                if (personas[indexOfControl][4] == "1" || personas[indexOfControl][4] == "2")
                {
                    Console.WriteLine("DOCENTE OR ALUMNO");
                    int indexType = int.Parse(personas[indexOfControl][4]) - 1;
                    // Console.WriteLine(x.AccessibleName);
                    dgvListarConsultasPrivs.DataSource = Controlador.ConsultasPrivada(personas[indexOfControl][0], Convert.ToByte(indexType));
                    dgvListarConsultasPrivs.Columns["idConsultaPrivada"].Visible = false;
                    dgvListarConsultasPrivs.Columns["Tema"].Visible = true;
                    dgvListarConsultasPrivs.Columns["Status"].Visible = false;

                    dgvListarConsultasPrivs.Columns["Alumno"].Visible = true;
                    dgvListarConsultasPrivs.Columns["ciDocente"].Visible = false;
                    dgvListarConsultasPrivs.Columns["Destinatario"].Visible = false;
                    dgvListarConsultasPrivs.Columns["idMensaje"].Visible = false;
                    dgvListarConsultasPrivs.ClearSelection();
                    panelDatagridViews.Visible = true;
                    panelDatagridViews.Enabled = true;
                    //dgvListarConsultasPrivs.Columns["Fecha ultimo mensaje"].AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;
                    dgvListarConsultasPrivs.Columns["Fecha ultimo mensaje"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    foreach (DataGridViewColumn col in dgvListarConsultasPrivs.Columns)
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    loadSalas(cbHistorialSalas.Checked, indexOfControl, Convert.ToByte(personas[indexOfControl][4]), personas[indexOfControl][0]);
                    dgvSalas.Columns["creacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    foreach (DataGridViewColumn col in dgvSalas.Columns)
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //dgvListarConsultasPrivs.Visible = true;
                    //dgvListarConsultasPrivs.Enabled = true;
                    //dgvSalas.Visible = true;
                    //dgvSalas.Enabled = true;
                    dgvListarConsultasPrivs.ClearSelection();
                    dgvSalas.ClearSelection();
                }
                else
                {
                    panelDatagridViews.Visible = false;
                    panelDatagridViews.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
        }
        private void loadSalas(bool loadHistorial, int indexOfControl, byte type, string ci)
        {
            dgvSalas.DataSource = Controlador.loadSalasDePersonaForAdmin(loadHistorial, gruposMateriasDePersonas[indexOfControl], type, ci);
            dgvSalas.Columns["idSala"].Visible = false;
            dgvSalas.Columns["idGrupo"].Visible = false;
            dgvSalas.Columns["idMateria"].Visible = false;
            dgvSalas.Columns["resumen"].Visible = false;
            dgvSalas.Columns["isDone"].Visible = false;

            dgvSalas.Columns["anfitrion"].Visible = true;
            dgvSalas.Columns["creacion"].Visible = true;
            dgvSalas.Columns["Docente"].Visible = true;
        }
        private void mybutton_Click_Actividad(object sender, EventArgs e)
        {
            Enabled = false;
            Button b = (Button)sender;
            int indexFromButton = int.Parse(b.AccessibleName.Substring(13));
            string ci = personas[indexFromButton][0];
            string nombre = personas[indexFromButton][1];
            string apellido = personas[indexFromButton][2];
            string clave = personas[indexFromButton][3];
            string type = personas[indexFromButton][4];
            string apodo = "";
            try
            {
                apodo = personas[indexFromButton][5];
            }
            catch (Exception)
            {
            }
            //List<int> groupsToInt = GroupsToInt(indexFromButton);
            Console.WriteLine($"selected:\n{personas[indexFromButton][0]}\n{personas[indexFromButton][1]}\n{personas[indexFromButton][2]}\n{personas[indexFromButton][3]}\n{personas[indexFromButton][4]}");

            try
            {
                new UserLogs(ci, nombre, apellido).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
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
            string clave = personas[indexFromButton][3];
            string type = personas[indexFromButton][4];
            string apodo = "";
            try
            {
                apodo = personas[indexFromButton][5];
            }
            catch (Exception)
            {
            }
            List<int> groupsToInt = GroupsToInt(indexFromButton);
            new UsuarioRegistro(
                ci,
                nombre,
                apellido,
                apodo,
                clave,
                gruposMateriasDePersonas[indexFromButton],
                int.Parse(type),
                fotoDePersona[indexFromButton]).ShowDialog();
            flowLayoutPanel1.Controls.Clear();
            createControls();
            panelDatagridViews.Visible = false;
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
                Controlador.bajaPersona(ci);
                MessageBox.Show($"El usuario ha sido borrado del sistema!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));

                Controlador.deactivatePerson(ci, true);
            }
            flowLayoutPanel1.Controls.Clear();
            createControls();
            Enabled = true;
        }
        private void mybutton_Click_btnDeActivate(object sender, EventArgs e)
        {

            Enabled = false;
            Button b = (Button)sender;
            int indexFromButton = int.Parse(b.AccessibleName.Substring(14));
            string ci = personas[indexFromButton][0];
            string type = personas[indexFromButton][4];

            try
            {
                Controlador.deactivatePerson(ci, true);
                MessageBox.Show($"La cuenta del usuario ha sido desactivada!\nPara re-activarla ingrese la persona en el formulario de registro");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }

            flowLayoutPanel1.Controls.Clear();
            createControls();
            Enabled = true;
        }
        private void mybutton_Click_btnSalas(object sender, EventArgs e)
        {

            Enabled = false;

            Enabled = true;
        }
        private void btnExit_Click(object sender, EventArgs e) => Dispose();

        private void dgvListarConsultasPrivs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string asunto = dgvListarConsultasPrivs.CurrentRow.Cells["Tema"].Value.ToString();
            int idConsultaPrivada = int.Parse(dgvListarConsultasPrivs.CurrentRow.Cells["idConsultaPrivada"].Value.ToString());
            string ciAlumno = dgvListarConsultasPrivs.CurrentRow.Cells["Alumno"].Value.ToString();
            string ciDocente = dgvListarConsultasPrivs.CurrentRow.Cells["ciDocente"].Value.ToString(); ;
            string status = dgvListarConsultasPrivs.CurrentRow.Cells["Status"].Value.ToString();
            List<List<string>> mensajes = Controlador.getMsgsFromConsulta(idConsultaPrivada, ciAlumno, ciDocente);

            byte type = Convert.ToByte(personas[indexOfControl][4]);
            string ci = personas[indexOfControl][0];
            string nombre = personas[indexOfControl][1];
            string apellido = personas[indexOfControl][2];
            new replyScreen(mensajes, asunto, status, type, ci, nombre, apellido).Show();
        }

        private void cbHistorialSalas_CheckedChanged(object sender, EventArgs e)
        {
            Enabled = false;
            if (cbHistorialSalas.Checked)
            {
                lblSalas.Text = "Salas del usuario archivadas";
            }
            else
            {
                lblSalas.Text = "Salas del usuario";
            }
            loadDGV();
            Enabled = true;
        }

        private void dgvSalas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idSala = int.Parse(dgvSalas.CurrentRow.Cells["idSala"].Value.ToString());
            string asunto = Convert.ToString(dgvSalas.CurrentRow.Cells["resumen"].Value);
            string anfitrion = Convert.ToString(dgvSalas.CurrentRow.Cells["anfitrion"].Value);
            bool isDone = Convert.ToBoolean(dgvSalas.CurrentRow.Cells["isDone"].Value);

            string ci = personas[indexOfControl][0];
            string nombre = personas[indexOfControl][1];
            string apellido = personas[indexOfControl][2];
            try
            {
                new chatScreen(idSala, asunto, anfitrion, anfitrion, isDone, ci, nombre, apellido).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
        }
    }
}
