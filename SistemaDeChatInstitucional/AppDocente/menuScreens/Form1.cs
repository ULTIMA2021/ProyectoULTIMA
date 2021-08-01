using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using HtmlElement = System.Windows.Forms.HtmlElement;
using CapaLogica;
namespace AppDocente.menuScreens
{
    public partial class Form1 : Form
    {
        List<List<string>> mensajes;
        public Form1(List<List<string>>mensajes)
        {
            this.mensajes = mensajes;
            InitializeComponent();
            
            this.Show();
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string HTMLtextboxLabel = "<label for=\"txtBox\">Responder: </label>";
            string HTMLtextbox = "<textarea id=\"txtBox\" name=\"txtBox\" rows = \"5\" cols = \"33\" placeholder= \"Responder...\" ></textarea > ";
            string HTMLbutton = "<button type =\"button\" > Click Me!</button>";
            string alumnoNombre = AlumnoControlador.traemeEstaPersona(mensajes[0][1]);
            string content;
            for (int x = 0; x < mensajes.Count; x++)
            {
                if(mensajes[x][7]!=Session.cedula)
                    content = $"<div class=\"Mymsg\"><h3>{Session.nombre}</h3><br><p>{mensajes[x][4]}</p></div><br>";
                else
                    content = $"<div class=\"TheirMsg\"><h3>{alumnoNombre}</h3><br><p>{mensajes[x][4]}</p></div><br>";

                this.webBrowser1.Document.GetElementById("body").InnerHtml += content;
            }
            this.webBrowser1.Document.GetElementById("body").InnerHtml += HTMLtextboxLabel+"<br>"+HTMLtextbox+"<br>"+HTMLbutton ;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        }
    }
}
