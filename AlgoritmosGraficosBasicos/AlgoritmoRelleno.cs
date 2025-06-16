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
        // Método para rellenar figura con límites específicos (polígono cerrado)
        List<(int x, int y)> newcoordenadas = new List<(int x, int y)>(); // Lista para almacenar las coordenadas visitadas
        public void RellenarFigura(PictureBox picCanvas, int x, int y, List<(int x, int y)> limites, TableLayoutPanel table)
        {
            // Primero guardamos los límites en las coordenadas (para el polígono cerrado)
            foreach (var limite in limites)
            {
                // Agregamos las coordenadas como tuplas (x, y) directamente a la lista
                EscribirCoordenadas(limite.x, limite.y);
            }

            // Para que el acceso a la lista de coordenadas sea seguro en un entorno multi-hilo
            object lockDibujo = new object();
            if (EstaDentroDePoligono(x, y, limites) == false)
            {
                MessageBox.Show("No esta dentro de la figura");
                // Si el punto no está dentro del polígono, no hacemos nada
                return;
            }

            // Si deseas observar los puntos de la tabala, descomenta la siguiente línea
            tablaPuntos = table;
            //LimpiarTabla();
            Rellenar(picCanvas, x, y, lockDibujo, limites);
            //MostrarCoordenadas(newcoordenadas);
        }

        // Método recursivo de relleno
        private void Rellenar(PictureBox picCanvas, int x, int y, object lockDibujo, List<(int x, int y)> limites)
        {
            
            // Si el punto ya fue visitado, no lo volvemos a rellenar
            if (coordenadas.Contains((x, y))) return;

            // Agregamos las coordenadas al listado de la clase base (usando la lista 'coordenadas' de la clase padre)
            EscribirCoordenadas(x, y);
            newcoordenadas.Add((x, y));

            lock (lockDibujo)
            {
                // Graficamos el punto en el canvas
                GraficarPixelR(picCanvas, x, y);
            }

            // Definimos los vecinos (puntos adyacentes)
            var vecinos = new (int dx, int dy)[]
            {
                (1, 0),  // Derecha
                (-1, 0), // Izquierda
                (0, 1),  // Abajo
                (0, -1)  // Arriba
            };

            // Usamos Parallel.ForEach para hacer el relleno en paralelo
            Parallel.ForEach(vecinos, dir =>
            {
                Rellenar(picCanvas, x + dir.dx, y + dir.dy, lockDibujo, limites);
            });
           
        }

        // Método para verificar si el punto (x, y) está dentro del polígono cerrado
        private bool EstaDentroDePoligono(int x, int y, List<(int x, int y)> limites)
        {
            // Si no hay límites definidos, consideramos que todo está permitido
            if (limites == null || limites.Count < 3) {  
                return false; }
           

            // Creamos un polígono a partir de los puntos límites
            var polygon = new System.Drawing.Drawing2D.GraphicsPath();
            var puntosLimites = limites.Select(l => new Point(l.x, l.y)).ToArray(); // Convertimos tuplas a Points
            polygon.AddPolygon(puntosLimites);

            // Verificamos si el punto está dentro del polígono
            return polygon.IsVisible(x, y);
        }
    }
}
