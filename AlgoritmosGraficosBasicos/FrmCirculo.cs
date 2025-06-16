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
    public partial class FrmCirculo : Form
    {
        private static FrmCirculo _instance;
        AlgoritmoCirculoBresenham algoritmoCirculoBresenham = new AlgoritmoCirculoBresenham();
        AlgoritmoRelleno algoritmoRelleno = new AlgoritmoRelleno(); // Instanciamos el algoritmo de relleno
        public static FrmCirculo Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmCirculo();
                }
                return _instance;
            }
        }
        public FrmCirculo()
        {
            InitializeComponent();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            int SF = 20;
            int xc = pictureBox1.Width / 2;
            int yc = pictureBox1.Height / 2;
            int r = Convert.ToInt32(txtRadio.Text) * SF;
            algoritmoCirculoBresenham.CircleMidPointAsync(pictureBox1, xc, yc, r, TablaPuntos);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int clickX = e.X;
            int clickY = e.Y;
            algoritmoRelleno.RellenarFigura(pictureBox1, clickX, clickY, algoritmoCirculoBresenham.ObtenerCoordenadas(), TablaPuntos);
        }
    }
}
