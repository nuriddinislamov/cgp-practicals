using System;
using System.Drawing;
using System.Windows.Forms;

namespace Week_4
{
    public partial class Form1 : Form
    {
        Rectangle rect;
        int x = 0;
        int y = 200;
        int deltaX = 1;
        int deltaY = 1;
        Timer timer;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 500;
            this.Height = 500;
            rect = new Rectangle(x, y, 100, 100);

            // creates infinite loop
            timer = new Timer();
            timer.Interval = 10; // Refresh interval
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // this line checks if the moving rect has hit the left or right
            if (x < 0 || x > this.ClientSize.Width - rect.Width) deltaX *= -1;
            
            // this line checks if the moving rect has hit the top or bottom
            if (y < 0 || y > this.ClientSize.Height - rect.Height) deltaY *= -1;

            x += deltaX;
            y += deltaY;

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            using (Graphics g2 = Graphics.FromImage(backBuffer))
            {
                // Draw on the back buffer
                g2.FillRectangle(Brushes.White, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

                // some cool texting (nostalgia)
                // author: 2117032
                string text = "DVD";
                Font font = new Font("Helvetica", 10);
                SizeF textSize = g2.MeasureString(text, font);
                PointF textLocation = new PointF(
                    x + (rect.Width - textSize.Width) / 2,
                    y + (rect.Height - textSize.Height) / 2); // This is the center of the square

                g2.DrawString(text, font, Brushes.Black, textLocation);

                g2.DrawRectangle(Pens.Black, x, y, rect.Width, rect.Height);
                g2.DrawString("Moving rectangle", font, Brushes.Red, 150, 150);

            }
            e.Graphics.DrawImage(backBuffer, 0, 0);

            backBuffer.Dispose();
        }
    }
}
