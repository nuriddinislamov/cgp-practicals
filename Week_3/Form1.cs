using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Week_3
{
    public partial class Form1 : Form
    {
        Rectangle aRect;
        Rectangle anEllipse;
        Rectangle moving;
        int x, y;
        public Form1()
        {
            InitializeComponent();
            aRect = new Rectangle(100, 100, 200, 200);
            anEllipse = new Rectangle(150, 150, 200, 100);
            x = ClientSize.Width - 10;
            y = 30;
            moving = new Rectangle(x, y, 10, 10);

            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            Width = 500;
            Height = 500;
            BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush redBrush = new SolidBrush(Color.Red);
            Brush greenBrush = new SolidBrush(Color.Green);
            
            g.FillRectangle(redBrush, aRect);
            g.FillEllipse(greenBrush, anEllipse);
            
            while (x >= 0 && y <= ClientSize.Height - moving.Height)
            {
                moving.Location = new Point(x, y);
                Point screenLocation = this.PointToScreen(moving.Location);

                ControlPaint.FillReversibleRectangle(new Rectangle(screenLocation, moving.Size), Color.Red);
                Thread.Sleep(10);
                ControlPaint.FillReversibleRectangle(new Rectangle(screenLocation, moving.Size), Color.Red);

                x--;
                y++;
                moving = new Rectangle(x, y, 10, 10);
                
                Invalidate();
                Update();
            }
        }
    }
}
