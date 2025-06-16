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
    public partial class FrmBresenham : Form
    {
        private static FrmBresenham _instance;

        AlgortimoBresenham algortimoBresenham = new AlgortimoBresenham();
        private List<Point> puntosClick = new List<Point>();
        public static FrmBresenham Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {

                            _instance = new FrmBresenham();                       
                }
                return _instance;
            }
        }

        private FrmBresenham()
        {
            InitializeComponent();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TablaPuntos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picCanvas_Click(object sender, EventArgs e)
        {
           
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            puntosClick.Add(new Point(e.X, e.Y));
            MessageBox.Show($"Punto agregado: {e.X}, {e.Y}");

            if (puntosClick.Count == 2)
            {

                algortimoBresenham.ObtenerPuntos(puntosClick[0].X, puntosClick[0].Y, puntosClick[1].X, puntosClick[1].Y, TablaPuntos);
                algortimoBresenham.CalcularPuntos(picCanvas);
                puntosClick.Clear();

            }
        }
    }
}
