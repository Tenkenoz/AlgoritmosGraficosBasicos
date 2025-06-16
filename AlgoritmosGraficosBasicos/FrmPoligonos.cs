using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosGraficosBasicos
{
    public partial class FrmPoligonos : Form
    {
        private static FrmPoligonos _instance;
        Poligonos poligonos = new Poligonos();
        AlgoritmoRelleno algoritmoRelleno = new AlgoritmoRelleno(); // Instanciamos el algoritmo de relleno

        public static FrmPoligonos Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmPoligonos();
                }
                return _instance;
            }
        }

        public FrmPoligonos()
        {
            InitializeComponent();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            poligonos.ReadData(txtLados,txtamaño);
            poligonos.GraficarPoligono(picCanvas, picCanvas.Width / 2, picCanvas.Height / 2, TablaPuntos);
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            int clickX = e.X;
            int clickY = e.Y;
            algoritmoRelleno.RellenarFigura(picCanvas, clickX, clickY, poligonos.ObtenerCoordenadas(),TablaPuntos );
        }
    }
}
