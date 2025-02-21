using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graficadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btndibujar_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            panel1.Update();

            // Obtener las coordenadas de los TextBox
            if (int.TryParse(txtX1.Text, out int x1) && int.TryParse(txtY1.Text, out int y1) &&
                int.TryParse(txtX2.Text, out int x2) && int.TryParse(txtY2.Text, out int y2) &&
                int.TryParse(txtX3.Text, out int x3) && int.TryParse(txtY3.Text, out int y3))
            {
                // Calcular el tamaño del panel
                int minX = Math.Min(Math.Min(x1, x2), x3);
                int minY = Math.Min(Math.Min(y1, y2), y3);
                int maxX = Math.Max(Math.Max(x1, x2), x3);
                int maxY = Math.Max(Math.Max(y1, y2), y3);

                // Ajustar el tamaño del panel
                int padding = 5; // Espacio adicional para el borde
                int newWidth = maxX - minX + padding;
                int newHeight = maxY - minY + padding;

                // Establecer un tamaño mínimo para el panel
                int minWidth = 400; // Ancho mínimo
                int minHeight = 350; // Alto mínimo

                panel1.Width = Math.Max(newWidth, minWidth);
                panel1.Height = Math.Max(newHeight, minHeight);

                // Mantener el panel en la parte inferior derecha
                panel1.Location = new Point(this.ClientSize.Width - panel1.Width - 10, this.ClientSize.Height - panel1.Height - 10);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
                // Obtener las coordenadas de los TextBox
            if (int.TryParse(txtX1.Text, out int x1) && int.TryParse(txtY1.Text, out int y1) &&
                int.TryParse(txtX2.Text, out int x2) && int.TryParse(txtY2.Text, out int y2)) //&&
                //int.TryParse(txtX3.Text, out int x3) && int.TryParse(txtY3.Text, out int y3))
            {
                // Invertir las coordenadas Y
                int invertedY1 = panel1.Height - y1;
                int invertedY2 = panel1.Height - y2;
                //int invertedY3 = panel1.Height - y3;

                // Dibujar los puntos
                e.Graphics.FillEllipse(Brushes.Red, x1 - 5, y1 - 5, 10, 10); // Punto A
                e.Graphics.FillEllipse(Brushes.Blue, x2 - 5, y2 - 5, 10, 10); // Punto B
                //e.Graphics.FillEllipse(Brushes.Green, x3 - 5, y3 - 5, 10, 10); // Punto C

                // Dibujar una línea entre los puntos
                e.Graphics.DrawLine(Pens.White, x1, y1, x2, y2); // Línea A-B
                //e.Graphics.DrawLine(Pens.White, x2, y2, x3, y3); // Línea B-C
                //e.Graphics.DrawLine(Pens.White, x3, y3, x1, y1); // Línea C-A
            }
            else
            {
                MessageBox.Show("Por favor, ingrese coordenadas válidas.");
            }
        }
    }
}
