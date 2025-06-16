using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AlgoritmosGraficosBasicos
{
    internal abstract class TablaPuntos
    {
        public TableLayoutPanel tablaPuntos;
        private int contador;
        public Pen pen = new Pen(Color.Black, 4);
        public Pen penR = new Pen(Color.Red, 1);
        public Graphics graphics;

        public List<(int x, int y)> coordenadas = new List<(int x, int y)>();
        private readonly object lockCoordenadas = new object();

        public void SetTableLayoutPanel(TableLayoutPanel panel)
        {
            tablaPuntos = panel ?? throw new ArgumentNullException(nameof(panel));
            tablaPuntos.AutoScroll = true;
        }
        public List<(int x, int y)> ObtenerCoordenadas()
        {
            return coordenadas;
        }


        public void InicializarTabla()
        {
            if (tablaPuntos == null)
                throw new InvalidOperationException("TableLayoutPanel no asignado.");

            tablaPuntos.SuspendLayout();
            tablaPuntos.Controls.Clear();
            tablaPuntos.ColumnStyles.Clear();
            tablaPuntos.RowStyles.Clear();

            tablaPuntos.ColumnCount = 3;
            tablaPuntos.RowCount = 1;

            for (int i = 0; i < 3; i++)
                tablaPuntos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));

            tablaPuntos.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var encabezados = new[] { "N°", "X", "Y" };
            for (int col = 0; col < encabezados.Length; col++)
                tablaPuntos.Controls.Add(CrearLabel(encabezados[col], true), col, 0);

            contador = 1;
            tablaPuntos.ResumeLayout();
            ActualizarScroll();
        }

        public void EscribirCoordenadas(int x, int y)
        {
            lock (lockCoordenadas)
            {
                coordenadas.Add((x, y));
            }
        }

        public void MostrarCoordenadas(List<(int x, int y)> coordenadas)
        {
            if (tablaPuntos == null)
                return;

            tablaPuntos.SuspendLayout();

            foreach (var (x, y) in coordenadas)
            {
                int fila = tablaPuntos.RowCount++;
                tablaPuntos.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                tablaPuntos.Controls.Add(CrearLabel(contador.ToString()), 0, fila);
                tablaPuntos.Controls.Add(CrearLabel(x.ToString()), 1, fila);
                tablaPuntos.Controls.Add(CrearLabel(y.ToString()), 2, fila);
                contador++;
            }

            tablaPuntos.ResumeLayout();
            ActualizarScroll();
        }

        public void LimpiarTabla()
        {
            InicializarTabla();
        }

        public void BorrarCoordenadas()
        {
            lock (lockCoordenadas)
            {
                coordenadas.Clear();
            }
            contador = 1;
            LimpiarTabla();
        }


        private void ActualizarScroll()
        {
            var pref = tablaPuntos.GetPreferredSize(Size.Empty);
            tablaPuntos.AutoScrollMinSize = new Size(0, pref.Height);
        }

        public void GraficarPixel(PictureBox picCanvas, int x, int y) {
            graphics = picCanvas.CreateGraphics();
            graphics.DrawRectangle(pen, x, y, 1, 1);
        }
        public void GraficarPixelR(PictureBox picCanvas, int x, int y)
        {
            graphics = picCanvas.CreateGraphics();
            graphics.DrawRectangle(penR, x, y, 1, 1);
        }

        private Label CrearLabel(string texto, bool esEncabezado = false)
        {
            return new Label
            {
                Text = texto,
                AutoSize = true,
                Font = new Font("Segoe UI", 9, esEncabezado ? FontStyle.Bold : FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(3)
            };
        }
    }
}
