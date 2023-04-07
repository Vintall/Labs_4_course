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
using System.Numerics;


namespace Lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        const float escape_radius = 2;
        int max_iterations_count;
        const int default_iteration_count = 300;

        const int canvas_width = 500;
        const int canvas_height = 500;

        Bitmap bmp = null;

        private void button1_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(canvas_width, canvas_height);

            max_iterations_count = (int)numericUpDown1.Value;

            if(max_iterations_count <= 0)
                max_iterations_count = default_iteration_count;

            CanvasRefresh();
        }
        void CanvasRefresh()
        {
            int iteration = 0;
            double zx;
            double zy;

            string[] c = comboBox1.SelectedItem.ToString().Split('|');
            double cx = double.Parse(c[0]);
            double cy = double.Parse(c[1]);

            for (int x_pixel = 0; x_pixel < canvas_width; x_pixel++)
                for (int y_pixel = 0; y_pixel < canvas_height; y_pixel++)
                {
                    double x_pos = (double)(x_pixel - canvas_width / 2 + x_shift) / canvas_width * escape_radius * scale;
                    double y_pos = (double)(y_pixel - canvas_height / 2 + y_shift) / canvas_height * escape_radius * scale;


                    zx = x_pos;
                    zy = y_pos;

                    iteration = 0;
                    while (zx * zx + zy * zy < escape_radius && iteration < max_iterations_count)
                    {
                        double new_zx = zx * zx - zy * zy + cx;
                        double new_zy = 2 * zx * zy + cy;

                        zx = new_zx;
                        zy = new_zy;

                        iteration++;
                    }

                    if (iteration == max_iterations_count)
                        bmp.SetPixel(x_pixel, y_pixel, Color.Black);
                    else
                        bmp.SetPixel(x_pixel, y_pixel, Color.FromArgb((int)Math.Min((256f * trackBar1.Value * iteration / max_iterations_count), 255), 0, 0));
                }
            pictureBox1.Image = bmp;
            Refresh();
        }

        int x_shift = 0;
        int y_shift = 0;
        double scale = 1;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Q)
            {
                scale /= 1.5;

                CanvasRefresh();
            }
            if (keyData == Keys.E)
            {
                scale *= 1.5;

                CanvasRefresh();
            }
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
    }
}
