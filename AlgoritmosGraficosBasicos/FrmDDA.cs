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
    public partial class FrmDDA : Form
    {
        private static FrmDDA _instance;
        DibujarLinea objdibujarLinea = new AlgoritmoDDA();
        private List<Point> puntosClick = new List<Point>();
        public static FrmDDA Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmDDA();
                }
                return _instance;
            }
        }
        public FrmDDA()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            puntosClick.Add(new Point(e.X, e.Y));
            MessageBox.Show($"Punto agregado: {e.X}, {e.Y}");

            if (puntosClick.Count == 2)
            {

                objdibujarLinea.ObtenerPuntos(puntosClick[0].X, puntosClick[0].Y, puntosClick[1].X, puntosClick[1].Y, TablaPuntos);
                objdibujarLinea.CalcularPuntos(picCanvas);
                puntosClick.Clear();

            }
           
        }
    }


}