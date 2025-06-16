using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosGraficosBasicos
{
    internal class Poligonos : AlgortimoBresenham
    {
        private float mSide;
        private int numberSide; 
        private const float SF = 20; 
        public Poligonos()
        {
            mSide = 0.0f;
        }

        public  void GraficarPoligono(PictureBox picCanvas, int x, int y, TableLayoutPanel table)
        {
            if (numberSide < 3)
            {
                MessageBox.Show("El número de lados debe ser mayor o igual a 3.");
                return;
            }

            float size = mSide * SF;
            float xo = picCanvas.Width / 2f;
            float yo = picCanvas.Height / 2f;

            PointF[] pts = new PointF[numberSide];
            double anguloInicial = -Math.PI / 2;

            for (int i = 0; i < numberSide; i++)
            {
                double angulo = anguloInicial + i * 2 * Math.PI / numberSide;
                float xa = xo + size * (float)Math.Cos(angulo);
                float ya = yo + size * (float)Math.Sin(angulo);
                pts[i] = new PointF(xa, ya);
            }

            for (int i = 0; i < numberSide; i++)
            {
                Point p1 = Point.Round(pts[i]);
                Point p2 = Point.Round(pts[(i + 1) % numberSide]);
                ObtenerPuntos(p1.X, p1.Y, p2.X, p2.Y, table);
                CalcularPuntos(picCanvas);
            }
        }


        public void ReadData(TextBox txtSide, TextBox txtNumber)
        {
            try
            {
                mSide = float.Parse(txtSide.Text);

                numberSide = int.Parse(txtNumber.Text);
            }
            catch
            {
                MessageBox.Show("Error los datos no validos");
            }
        }
    }
}
