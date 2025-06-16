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
           float auxX = x1;
           float auxY= y1;
           float m=(float)deltaY / deltaX;    

                if (m < 0)
                {
                    for (int i = 0; i < Math.Abs(deltaX); i++)
                    {
                        GraficarPixel(picCanvas, (int)Math.Round(auxX), (int)Math.Round(auxY));
                        EscribirCoordenadas((int)Math.Round(auxX), (int)Math.Round(auxY));
                        auxX += 1;
                        auxY += m;
                    await Task.Delay(1); 
                }
                }
                else
                {
                    for (int i = 0; i < Math.Abs(deltaY); i++)
                    {
                        GraficarPixel(picCanvas, (int)Math.Round(auxX), (int)Math.Round(auxY));
                    EscribirCoordenadas((int)Math.Round(auxX), (int)Math.Round(auxY));
                    auxX += 1 / m;
                    auxY += 1;
                    await Task.Delay(1); 
                }
            }
                MostrarCoordenadas(coordenadas);
        }

    }
}
