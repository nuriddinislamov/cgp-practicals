using System;
using System.Drawing;
using System.Windows.Forms;

namespace Week_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Width = 500;
            this.Height = 500;
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Adjustable!
            int rotationAngle = 123;

            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Black);
            Font myFont = new Font("Helvetica", 9);
            Brush blackwriter = new SolidBrush(Color.Black);

            Rectangle rect = new Rectangle(100, 50, 100, 50);
            g.DrawRectangle(blackPen, rect);
            g.DrawString("Original", myFont, blackwriter, rect.Left, rect.Top - 20);

            PointF center = new PointF(rect.X + rect.Width / 2.0f, rect.Y + rect.Height / 2.0f);

            PointF[] points = new PointF[]
            {
                new PointF(rect.Left, rect.Top),
                new PointF(rect.Right, rect.Top),
                new PointF(rect.Right, rect.Bottom),
                new PointF(rect.Left, rect.Bottom)
            };

            points = Tmatrix.matrixRotate(rotationAngle, center, points);

            float maxX = points[0].X;
            foreach (PointF p in points)
            {
                if (p.X > maxX)
                    maxX = p.X;
            }
            float translation = rect.Right - maxX + 100; // 100 is the buffer distance between the shapes

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointF(points[i].X + translation, points[i].Y);
            }

            g.DrawPolygon(blackPen, points);
            g.DrawString("Rotated " + rotationAngle + " degrees", myFont, blackwriter, points[0].X, points[0].Y - 20);
        }
    }

    public static class Tmatrix
    {
        public static PointF[] matrixRotate(float angle, PointF center, PointF[] points)
        {
            // Rotates the shape using an angle,
            // the center of the shape (along which it will be rotated)
            // and the array of points
            PointF[] rotatedPoints = new PointF[points.Length];

            // calcluating cosT & sinT
            double radians = angle * Math.PI / 180.0;
            double cosTheta = Math.Cos(radians);
            double sinTheta = Math.Sin(radians);

            for (int i = 0; i < points.Length; i++)
            {
                // applying the formula for each
                // point of the shape

                float x = points[i].X - center.X;
                float y = points[i].Y - center.Y;

                float newX = (float)(x * cosTheta - y * sinTheta);
                float newY = (float)(x * sinTheta + y * cosTheta);

                rotatedPoints[i] = new PointF(newX + center.X, newY + center.Y);
            }

            return rotatedPoints;
        }
    }
}
