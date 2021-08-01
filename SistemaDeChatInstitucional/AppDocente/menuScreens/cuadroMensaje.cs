using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDocente.menuScreens
{
    public partial class cuadroMensaje : Form
    {
        public cuadroMensaje()
        {
            InitializeComponent();
        }

        public cuadroMensaje(string mensaje, string nombre)
        {
            InitializeComponent();
            txtMensajeAlumno.Text = mensaje;
            lblNombrePersona.Text = nombre;
        }

        
    }
}
