using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosGraficosBasicos
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void lineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDDA aux = FrmDDA.Instance;
            aux.MdiParent = this;
            aux.Show();

        }

        private void bresenhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBresenham aux = FrmBresenham.Instance;
            aux.MdiParent = this;
            aux.Show();
        }

        private void circuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCirculo frmCirculo = FrmCirculo.Instance;
            frmCirculo.MdiParent = this;
            frmCirculo.Show();
        }

        private void poligonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPoligonos frmPoligonos = FrmPoligonos.Instance;
            frmPoligonos.MdiParent = this;
            frmPoligonos.Show();
        }
    }
}
