using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultorio
{
    public partial class VistaMenu : Form
    {
        public VistaMenu()
        {
            InitializeComponent();
        }

        private void medicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaMedico vista = new VistaMedico();
            vista.MdiParent = this;
            vista.Show();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaPaciente vista = new VistaPaciente();
            vista.MdiParent = this;
            vista.Show();
        }

        private void citasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaCita vista = new VistaCita();
            vista.MdiParent = this;
            vista.Show();
        }
    }
}
