using System.Drawing;
using System.Windows.Forms;

namespace Week_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Use lamba function
            Paint += (object sender, PaintEventArgs e) => {

                int numberOfTriangles = 3;

                PointF p1 = new Point(100, 100);
                PointF p2 = new Point(500, 100);
                PointF p3 = new Point(300, 446);

                string text = $"Number of triangles: {numberOfTriangles}";
                Font font = new Font("Arial", 14);
                PointF location = new PointF(10, 10); // Top-left corner
                e.Graphics.DrawString(text, font, Brushes.Black, location);

                DrawTriangle(e.Graphics, p1, p2, p3, numberOfTriangles);
            };

        }
        private void DrawTriangle(Graphics g, PointF p1, PointF p2, PointF p3, int remainingTriangles)
        {
            // Limit to drawing only the number of 'numberOfTriangles' triangles, therefore if none left to draw then terminate the program.
            if (remainingTriangles == 0) return;
            g.DrawPolygon(Pens.Black, new[] { p1, p2, p3});

            PointF midP1P2 = MidPoint(p1, p2);
            PointF midP2P3 = MidPoint(p2, p3);
            PointF midP3P1 = MidPoint(p3, p1);

            // Recursively draw the next triangle inside the current one
            DrawTriangle(g, midP1P2, midP2P3, midP3P1, remainingTriangles - 1);
        }

        private PointF MidPoint(PointF p1, PointF p2)
        {
            return new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }
    }
}
