using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 500;
            this.Height = 500;
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Red, 3);

            int squareX = 100;
            int squareY = 100;
            int sideLength = 200;

            g.DrawRectangle(blackPen, squareX, squareY, sideLength, sideLength);

            int circleDiameter = sideLength;

            g.DrawEllipse(blackPen, squareX, squareY, circleDiameter, circleDiameter);

        }
    }
}
