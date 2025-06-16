using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosGraficosBasicos
{
    internal class AlgoritmoRelleno : TablaPuntos
    {
        List<(int x, int y)> newcoordenadas = new List<(int x, int y)>(); 
        public void RellenarFigura(PictureBox picCanvas, int x, int y, List<(int x, int y)> limites, TableLayoutPanel table)
        {
            foreach (var limite in limites)
            {
                EscribirCoordenadas(limite.x, limite.y);
            }

            object lockDibujo = new object();
            if (EstaDentroDePoligono(x, y, limites) == false)
            {
                MessageBox.Show("No esta dentro de la figura");
                return;
            }

            // Si deseas observar los puntos del rellenado, descomenta la siguiente líne
            tablaPuntos = table;
            //LimpiarTabla();
            Rellenar(picCanvas, x, y, lockDibujo, limites);
            //MostrarCoordenadas(newcoordenadas);
        }

        private void Rellenar(PictureBox picCanvas, int x, int y, object lockDibujo, List<(int x, int y)> limites)
        {
            
            if (coordenadas.Contains((x, y))) return;

            EscribirCoordenadas(x, y);
            newcoordenadas.Add((x, y));

            lock (lockDibujo)
            {
                // Graficamos el punto en el canvas
                GraficarPixelR(picCanvas, x, y);
            }

            var vecinos = new (int dx, int dy)[]
            {
                (1, 0),  // Derecha
                (-1, 0), // Izquierda
                (0, 1),  // Abajo
                (0, -1)  // Arriba
            };

            Parallel.ForEach(vecinos, dir =>
            {
                Rellenar(picCanvas, x + dir.dx, y + dir.dy, lockDibujo, limites);
            });
           
        }

        private bool EstaDentroDePoligono(int x, int y, List<(int x, int y)> limites)
        {
            if (limites == null || limites.Count < 3) {  
                return false; }
           

            var polygon = new System.Drawing.Drawing2D.GraphicsPath();
            var puntosLimites = limites.Select(l => new Point(l.x, l.y)).ToArray(); 
            polygon.AddPolygon(puntosLimites);

            return polygon.IsVisible(x, y);
        }
    }
}
