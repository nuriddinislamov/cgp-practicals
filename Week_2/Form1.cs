using System;
using System.Drawing;
using System.Windows.Forms;

namespace Week_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = SystemColors.InfoText;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            PointF p1 = new Point(100, 100);
            PointF p2 = new Point(500, 100);
            PointF p3 = new Point(300, 446);

            DrawTriangles(e.Graphics, p1, p2, p3);

        }

        private void DrawTriangles(Graphics g, PointF p1, PointF p2, PointF p3, int numberOfTriangles = 0, bool isDarkMode = true)
        {
            // Ternary operator to check if dark mode is enabled
            Color color = isDarkMode ? Color.White : Color.Black;

            // Set the background to light
            if (!isDarkMode) this.BackColor = SystemColors.Info;

            g.DrawPolygon(new Pen(color, 1f), new PointF[] { p1, p2, p3 });

            numberOfTriangles++;

            PointF midP1P2 = MidPoint(p1, p2);
            PointF midP2P3 = MidPoint(p2, p3);
            PointF midP3P1 = MidPoint(p3, p1);

            // Calulate the side lendth of the triangles every time to check if one is smaller than 1px
            float sideLength = Distance(p1, p2);
            
            if (sideLength < 1)
            {
                string text = $"Number of triangles: {numberOfTriangles}";

                
                Font font = new Font("Calibri", 12);

                PointF location = new PointF(10, 10);

                Brush brush = new SolidBrush(color);

                g.DrawString(text, font, brush, location);
                return;
            }

            DrawTriangles(g, midP1P2, midP2P3, midP3P1, numberOfTriangles);
        }

        private PointF MidPoint(PointF p1, PointF p2)
        {
            // Return 1/2 of the both coordinates (X, Y)
            return new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }

        private float Distance(PointF p1, PointF p2)
        {
            // Euclidean distance between two points - formula can be found here: https://en.wikipedia.org/wiki/Euclidean_distance
            return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
