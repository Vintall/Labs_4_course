using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        int iterations_count;
        const int default_iteration_count = 5;

        Bitmap bmp = null;
        List<(int, int)> pixels = new List<(int, int)>();
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("ButtonPressed");
            this.Refresh();
            bmp = new Bitmap(500, 500);

            pixels.Clear();
            for (int i = 100; i <= 400; i++)
                for (int j = 100; j <= 400; j++)
                    pixels.Add((i, j));

            iterations_count = (int)numericUpDown1.Value;

            if(iterations_count <= 0)
                iterations_count = default_iteration_count;
            
            listBox1.Items.Add("HatchinsonStart");
            this.Refresh();

            Hatchinson.Calculate(ref pixels, iterations_count, 3, listBox1,
                () =>
                {
                    listBox1.Items.Add("HatchinsonDone");
                    this.Refresh();

                    CanvasRefresh();
                });
        }
        void CanvasRefresh()
        {
            listBox1.Items.Add("CanvasBackgroundFill");
            Refresh();

            for (int i = 0; i < 500; i++)
                for (int j = 0; j < 500; j++)
                    bmp.SetPixel(i, j, Color.White);

            for (int i = 0; i < pixels.Count; i++)
            {
                if (pixels[i].Item1 < 0 + x_shift || pixels[i].Item1 >= 500 + x_shift)
                    continue;

                if (pixels[i].Item2 < 0 + y_shift || pixels[i].Item2 >= 500 + y_shift)
                    continue;

                bmp.SetPixel(pixels[i].Item1 - x_shift, pixels[i].Item2 - y_shift, Color.Black);
            }

            listBox1.Items.Add("ImageDone");
            Refresh();

            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bmp == null)
                return;

            Hatchinson.Calculate(ref pixels, 1, 4, listBox1,
                () =>
                {
                    pictureBox1.Image = bmp;
                    pictureBox1.Refresh();
                });
        }
        int x_shift = 0;
        int y_shift = 0;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.W)
            {
                y_shift -= 50;

                CanvasRefresh();
            }
            if (keyData == Keys.A)
            {
                x_shift -= 50;

                CanvasRefresh();
            }
            if (keyData == Keys.S)
            {
                y_shift += 50;

                CanvasRefresh();
            }
            if (keyData == Keys.D)
            {
                x_shift += 50;

                CanvasRefresh();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
