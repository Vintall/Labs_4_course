using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const int size = 500;
        const int iterationsCount = 300;
        double Function(double x, double a) => 1 - x * x - a * x;
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            Bitmap bmp = new Bitmap(size, size);

            gr.Clear(Color.White);
            for (int x = 0; x < size; ++x)
                for (int a = 0; a < size; ++a)
                {
                    double aNorm = (double)a / size;
                    double xN = (double)x / size;

                    for (int i = 0; i < iterationsCount; ++i)
                        xN = Function(xN, aNorm);

                    if(xN >= 0 && xN * size/2 < size)
                    bmp.SetPixel(a, (int)(xN * size/2), Color.Black);
                }
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }
    }
}
