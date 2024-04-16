using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week_5
{
    public partial class Form1 : Form
    {
        List<Point> pointsTable = new List<Point>
        {
            new Point(200, 200),
            new Point(400, 200),
            new Point(400, 300),
            new Point(200, 300),
            
            new Point(200, 400),
            new Point(600, 400),
            new Point(600, 300),

            new Point(600, 200),
            new Point(600, 250),
            new Point(400, 250)
        };

        List<(int start, int end)> linesTable = new List<(int start, int end)>
        {
            (3, 0),
            (0, 1),
            (1, 2),

            (3, 4),
            (4, 5),
            (5, 6),
            (6, 3),

            (1, 7),
            (7, 8),
            (8, 9)
        };

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString("SID: 2117032", new Font("Helvetica", 9), Brushes.Black, new Point(200, 180));

            foreach (var line in linesTable)
            {
                g.DrawLine(Pens.Black, pointsTable[line.start], pointsTable[line.end]);
            }
        }
    }
}
