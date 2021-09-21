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

namespace AppAlumno
{
    public partial class alumnoMainScreen : Form
    {
        System.Windows.Forms.Timer timer;
        string msgCount;

        public alumnoMainScreen()
        {
            InitializeComponent();
            this.Show();   
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

        private void msgLabelAndnotification() {
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
            if (ventanaActiva != null )
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

        
        private void btnMiPerfil_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuMiPerfil);
            enable(btnNuevoMensaje);
            enable(btnMisMensajes);
            enable(btnMisDocentes);
            enable(btnAsignaturas);
            enable(btnConfiguracion);
        }


        private void btnDocentes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuDocentes);
            enable(btnNuevoMensaje);
            enable(btnMisMensajes);
            enable(btnMisDocentes);
            enable(btnAsignaturas);
            enable(btnConfiguracion);
        }


        private void btnAgenda_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            enable(btnNuevoMensaje);
            enable(btnMisMensajes);
            enable(btnMisDocentes);
            enable(btnAsignaturas);
            enable(btnConfiguracion);
            enable(btnSala);

        }


        private void btnMensajes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuMensajes);
            enable(btnNuevoMensaje);
            enable(btnMisMensajes);
            enable(btnMisDocentes);
            enable(btnAsignaturas);
            enable(btnConfiguracion);

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
            Application.Exit();
        }


        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
            btnNormal.BringToFront();
        }

        
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.BringToFront();
        }


        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            openScreen(new menuScreens.configuracion());
            disable(btnConfiguracion);
            enable(btnNuevoMensaje);
            enable(btnMisMensajes);
            enable(btnMisDocentes);
            enable(btnAsignaturas);
            enable(btnSala);

        }


        private void btnAsignaturas_Click(object sender, EventArgs e)
        {
            openScreen(new menuScreens.misAsignaturas());
            disable(btnAsignaturas);
            
            enable(btnMisMensajes);
            enable(btnNuevoMensaje);
            enable(btnMisDocentes);
            enable(btnConfiguracion);
            enable(btnSala);

        }

        private void btnMisDocentes_Click(object sender, EventArgs e)
        {
            disable(btnMisDocentes);
            openScreen(new menuScreens.misDocentes());
            
            enable(btnMisMensajes);
            enable(btnNuevoMensaje);
            enable(btnConfiguracion);
            enable(btnAsignaturas);
            enable(btnSala);


        }

        private void btnNuevoMensaje_Click(object sender, EventArgs e)
        {
            openScreen(new menuScreens.NuevoMensaje());
            disable(btnNuevoMensaje);
            enable(btnMisMensajes);
            enable(btnMisDocentes);
            enable(btnConfiguracion);
            enable(btnAsignaturas);
            enable(btnSala);

        }

        private void btnMisMensajes_Click(object sender, EventArgs e)
        {
            openScreen(new menuScreens.misMensajes());
            disable(btnMisMensajes);
            enable(btnNuevoMensaje);
            enable(btnMisDocentes);
            enable(btnConfiguracion);
            enable(btnAsignaturas);
            enable(btnSala);

        }

        private void alumnoMainScreen_Load(object sender, EventArgs e)
        {
            lblNombre.Text = $"{Session.nombre} {Session.apellido}";
            msgCount = Controlador.getMensajesStatusCount("recibido");
            msgLabelAndnotification();
            setTimer();
        }

        private void btnLogout_Click(object sender, EventArgs e){
            DialogResult confirmLogout = MessageBox.Show("Realmente desea cerrar sesion?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == confirmLogout)
            {
                Dispose();
                Application.Restart();
            }
            
        }

        public void disable(Button boton)
        {
            boton.Enabled = false;
        }

        public void enable(Button boton)
        {
            boton.Enabled = true;
        }

        private void panelOpciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSala_Click(object sender, EventArgs e)
        {
            esconderSubMenu();
            openScreen(new menuScreens.Salas());
            disable(btnSala);
        }

        private void getTextFromComponents()
        {
            menuScreens.configuracion conf = new menuScreens.configuracion();

            //botones del menu
            btnMiPerfil.Text = Resources.btnMiPerfil;            
            btnMensajes.Text = Resources.btnMensajes;
            
            btnDocentes.Text = Resources.btnDocentes;
            btnSala.Text = Resources.btnSala;
            btnLogout.Text = Resources.btnLogout;

            //botones de submenu
            btnConfiguracion.Text = Resources.btnConfiguracion;
            btnAsignaturas.Text = Resources.btnMisAsignaturas;
            btnMisDocentes.Text = Resources.btnMisDocentes;
            btnInstitucion.Text = Resources.btnInstitucion;
            btnNuevoMensaje.Text = Resources.btnNuevoMensaje;
            btnMisMensajes.Text = Resources.btnMisMensajes;

            

        }

        private void selectIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = selectIdioma.SelectedIndex;
            
            if(selectIdioma.Items[index].ToString() == "Ingles/English")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
             
                getTextFromComponents();
            }

            if (selectIdioma.Items[index].ToString() == "Español/Spanish")
            {

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                getTextFromComponents();

               
            }

            {

            }
        }
    }
}
