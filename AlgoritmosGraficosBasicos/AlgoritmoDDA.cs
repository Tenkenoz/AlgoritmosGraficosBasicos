using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosGraficosBasicos
{
    internal class AlgoritmoDDA : DibujarLinea
    {
        public override async void CalcularPuntos(PictureBox picCanvas)
        {
            int deltaX = x2 - x1;
            int deltaY = y2 - y1;
            int pasos = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));
            if (pasos == 0)
            {
                GraficarPixel(picCanvas, x1, y1);
                EscribirCoordenadas(x1, y1);
                MostrarCoordenadas(coordenadas);
                return;
            }

            float incX = deltaX / (float)pasos;
            float incY = deltaY / (float)pasos;
            float auxX = x1;
            float auxY = y1;

            for (int i = 0; i <= pasos; i++)
            {
                GraficarPixel(picCanvas, (int)Math.Round(auxX), (int)Math.Round(auxY));
                EscribirCoordenadas((int)Math.Round(auxX), (int)Math.Round(auxY));
                auxX += incX;
                auxY += incY;
                await Task.Delay(1);
            }
            MostrarCoordenadas(coordenadas);
        }
    }
}
