using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace AppDocente
{
    public partial class docenteMainScreen : Form
    {
        System.Windows.Forms.Timer timer;
        string msgCount;

        public docenteMainScreen()
        {
            InitializeComponent();
            btnAgenda.Visible = false;
            btnAgenda.Enabled = false;
            btnAlumnos.Visible = false;
            btnAlumnos.Enabled = false;
        }
            
        
        // Metodos para desplazar ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void timer_Tick(Object sender, EventArgs e)
        {
            Console.WriteLine("IM CHECKING");
            try
            {
                msgCount = Controlador.getMensajesStatusCount("recibido");
                msgLabelAndnotification();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Controlador.errorHandler(ex));
            }
        }
        private void msgLabelAndnotification()
        {
            btnMensajes.Text = $"            Mensajes: {msgCount}";
            btnMisMensajes.Text = $"●  Mis mensajes: {msgCount}";

            if (int.Parse(msgCount) > 0)
            {
                Console.WriteLine("LABELS SHOULDVE CHANGED");
                btnMisMensajes.BackColor = Color.Firebrick;
                btnMensajes.BackColor = Color.Firebrick;
            }
            else
            {
                btnMensajes.BackColor = btnSala.BackColor;
                btnMisMensajes.BackColor = btnConfiguracion.BackColor;
            }
        }
        private void setTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = (1000 * 25);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        public void esconderSubMenu()
        {
            if(subMenuMiPerfil.Visible == true)
            {
                subMenuMiPerfil.Visible = false;
            }

            if (subMenuDocentes.Visible == true)
            {
                subMenuDocentes.Visible = false;
            }

            if (subMenuMensajes.Visible == true)
            {
                subMenuMensajes.Visible = false;
            }

        }

        public void mostrarSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                esconderSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private Form ventanaActiva = null;
        public void openScreen(Form ventana)
        {
            if (ventanaActiva != null)
            {
                ventanaActiva.Close();
            }

            ventanaActiva = ventana;
            ventana.TopLevel = false;
            ventana.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(ventana);
            panelContenedor.Tag = ventana;
            ventana.BringToFront();
            ventana.Show();
           
        }
        private void setConfig(menuScreens.configuracion ventana)
        {
            ventana.CustomFormClosed += CloseListener;
            openScreen(ventana);
        }
        private void setMisAsignaturas(menuScreens.misAsignaturas ventana)
        {
            ventana.CustomFormClosed += CloseListener;
            openScreen(ventana);
        }
        private void setSala(menuScreens.Salas ventana)
        {
            ventana.CustomFormClosed += CloseListener;
            openScreen(ventana);
        }
        private void setAgenda(menuScreens.agenda ventana)
        {
            ventana.CustomFormClosed += CloseListener;
            openScreen(ventana);
        }
        private void setMisMsg(menuScreens.misMensajes ventana)
        {
            ventana.CustomFormClosed += CloseListener;
            openScreen(ventana);
        }

        private void btnMiPerfil_Click(object sender, EventArgs e) => mostrarSubMenu(subMenuMiPerfil);
        private void btnAlumnos_Click(object sender, EventArgs e) => mostrarSubMenu(subMenuDocentes);
        private void btnMensajes_Click(object sender, EventArgs e) => mostrarSubMenu(subMenuMensajes);

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            Enabled = false;
            menuScreens.agenda window = new menuScreens.agenda();
            setAgenda(window);
            enableButtonsExceptSelected(btnAgenda);
            Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Dispose();
            Application.Exit(); 
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btnNormal.BringToFront();
        }

        private void btnMinimizar_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        
        private void btnNormal_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            btnMaximizar.BringToFront();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            Enabled = false;
            menuScreens.configuracion window = new menuScreens.configuracion();
            setConfig(window);
            enableButtonsExceptSelected(btnConfiguracion);
            Enabled = true;
        }

        private void btnAsignaturas_Click(object sender, EventArgs e)
        {
            Enabled = false;
            menuScreens.misAsignaturas window = new menuScreens.misAsignaturas();
            setMisAsignaturas(window);
            enableButtonsExceptSelected(btnAsignaturas);
            Enabled = true;
        }

        private void btnMisAlumnos_Click(object sender, EventArgs e)
        {
            Enabled = false;
            //menuScreens.misAlumnos window = new menuScreens.misAlumnos();
            //setMisAlumnos(window);
            enableButtonsExceptSelected(btnMisAlumnos);
            Enabled = true;
        }

        private void btnMisMensajes_Click(object sender, EventArgs e)
        {
            Enabled = false;
            menuScreens.misMensajes window = new menuScreens.misMensajes();
            setMisMsg(window);
            enableButtonsExceptSelected(btnMisMensajes);
            Enabled = true;
        }

        private void btnSala_Click(object sender, EventArgs e)
        {
            Enabled = false;
            esconderSubMenu();
            menuScreens.Salas window = new menuScreens.Salas();
            setSala(window);
            enableButtonsExceptSelected(btnSala);
            Enabled = true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirmLogout = MessageBox.Show("Realmente desea cerrar sesion?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == confirmLogout)
            {
                Dispose();
                Application.Restart();
            }
        }

        private void alumnoMainScreen_Load(object sender, EventArgs e)
        {
            lblNombre.Text = $"{Session.nombre} {Session.apellido}";
            msgCount = Controlador.getMensajesStatusCount("recibido");
            msgLabelAndnotification();
            setTimer();
            try
            {
                MemoryStream ms = new MemoryStream(Session.foto);
                fotoAlumno.Image = Image.FromStream(ms);
            }
            catch (ArgumentNullException ex)
            {
            }
        }

        private void panelOpciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        private void enableButtonsExceptSelected(Button butt) {
            foreach (Button b in GetAll(this,typeof(Button)))
            {
                if (b == butt)
                    b.Enabled = false;
                else
                    b.Enabled = true;
            }

        }
        // returns all controls of a given type in the form 
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private void getTextFromComponents()
        {
            menuScreens.configuracion conf = new menuScreens.configuracion();

            //botones del menu
            btnMiPerfil.Text = Resources.btnMiPerfil;
            btnMensajes.Text = Resources.btnMensajes;
            btnAgenda.Text = Resources.btnAgenda;
            btnAlumnos.Text = Resources.btnAlumnos;
            btnSala.Text = Resources.btnSala;
            btnLogout.Text = Resources.btnLogout;

            //botones de submenu
            btnConfiguracion.Text = Resources.btnConfiguracion;
            btnAsignaturas.Text = Resources.btnMisAsignaturas;
            btnInstitucion.Text = Resources.btnInstitucion;
            btnMisMensajes.Text = Resources.btnMisMensajes;
            btnMisAlumnos.Text = Resources.btnMisAlumnos;
        }
        private void CloseListener(object sender, EventArgs e, string test)
        {
            //DO SHIT HERE
            enableButtonsExceptSelected(null);
        }

        private void selectIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = selectIdioma.SelectedIndex;
            if (selectIdioma.Items[index].ToString() == "Ingles/English")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                getTextFromComponents();
            }

            if (selectIdioma.Items[index].ToString() == "Español/Spanish")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                getTextFromComponents();
            }
        }

        private void docenteMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
