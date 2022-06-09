using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngeniriaProyceto.Contenidos;

namespace IngeniriaProyceto
{
    public partial class Egre : Form
    {
        UserControl ucactual;
        public Egre()
        {
            InitializeComponent();
        }

        private void Menu_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ucactual = new UCIngresos();
            button1.BackColor = Color.FromArgb(251, 191, 0);
            PanelContenido.Controls.Clear();
            PanelContenido.Controls.Add(ucactual);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ucactual = new UCEgresos();
            button1.BackColor = Color.FromArgb(251, 191, 0);
            PanelContenido.Controls.Clear();
            PanelContenido.Controls.Add(ucactual);
        }

        private void BtnTaller_Click(object sender, EventArgs e)
        {
            ucactual = new UCTaller();
            button1.BackColor = Color.FromArgb(251, 191, 0);
            PanelContenido.Controls.Clear();
            PanelContenido.Controls.Add(ucactual);
        }
    }
}
