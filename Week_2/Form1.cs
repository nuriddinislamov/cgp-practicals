using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            PointF p1 = new Point(100, 100);
            PointF p2 = new Point(500, 100);
            PointF p3 = new Point(300, 446);

            DrawTriangle(e.Graphics, p1, p2, p3, 3);
        }
        private void DrawTriangle(Graphics g, PointF p1, PointF p2, PointF p3, int remainingTriangles)
        {
            // Limit to drawing only 3 triangles, therefore if none left to draw then terminate the program.
            if (remainingTriangles == 0) return;
            g.DrawPolygon(Pens.Black, new[] { p1, p2, p3});

            PointF midP1P2 = MidPoint(p1, p2);
            PointF midP2P3 = MidPoint(p2, p3);
            PointF midP3P1 = MidPoint(p3, p1);

            // Recursively draw the next triangle inside the current one until if condition is met
            // before this is method is called again at the third iteration
            DrawTriangle(g, midP1P2, midP2P3, midP3P1, remainingTriangles - 1);
        }

        private PointF MidPoint(PointF p1, PointF p2)
        {
            return new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }

        private float Distance(PointF p1, PointF p2)
        {
            // Euclidean distance
            // Formula from https://en.wikipedia.org/wiki/Euclidean_distance
            return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
