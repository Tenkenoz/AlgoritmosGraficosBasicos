using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosGraficosBasicos
{
    internal class AlgoritmoCirculoBresenham : TablaPuntos
    {

        public AlgoritmoCirculoBresenham()
        {
        }

        public void CircleMidPointAsync(PictureBox picCanvas, int xc, int yc, int r, TableLayoutPanel table)
        {
            tablaPuntos = table;
            InicializarTabla();
            int x = 0, y = r;
            int p = 1 - r;
            DrawSymmetricPoints(picCanvas, xc, yc, x, y);
            while (x < y)
            {
                x++;
                if (p < 0)
                {
                    p += 2 * x + 1;
                }
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }
                DrawSymmetricPoints(picCanvas, xc, yc, x, y);

            }
            MostrarCoordenadas(coordenadas);
        }

        private void DrawSymmetricPoints(PictureBox g, int xc, int yc, int x, int y)
        {

            GraficarPixel(g, xc + x, yc + y);
            EscribirCoordenadas(xc + x, yc + y);
            GraficarPixel(g, xc - x, yc + y);
            EscribirCoordenadas(xc - x, yc + y);
            GraficarPixel(g, xc + x, yc - y);
            EscribirCoordenadas(xc + x, yc - y);
            GraficarPixel(g, xc - x, yc - y);
            EscribirCoordenadas(xc - x, yc - y);
            GraficarPixel(g, xc + y, yc + x);
            EscribirCoordenadas(xc + y, yc + x);
            GraficarPixel(g, xc - y, yc + x);
            EscribirCoordenadas(xc - y, yc + x);
            GraficarPixel(g, xc + y, yc - x);
            EscribirCoordenadas(xc + y, yc - x);
            GraficarPixel(g, xc - y, yc - x);
            EscribirCoordenadas(xc - y, yc - x);

        }


    }

}