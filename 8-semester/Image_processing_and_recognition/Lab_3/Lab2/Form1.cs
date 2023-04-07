using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        string[] args;
        Graphics gr;

        Bitmap inputBmp;
        Bitmap outBmp;

        public Form1()
        {
            InitializeComponent();
            gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.Yellow);
            pictureBox1.Refresh();
            args = Environment.GetCommandLineArgs();
            label4.Text = $"Pixel radius: {trackBar1.Value}";
        }
        void LoadImage(string path)
        {
            Image inputImage = Bitmap.FromFile(path);

            gr.DrawImage(inputImage, pictureBox1.DisplayRectangle);

            inputBmp = new Bitmap(inputImage);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            //if (openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4) != ".bmp")
            //    return;

            LoadImage(openFileDialog1.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (inputBmp == null)
                return;

            outBmp = ApplyEmbossFilter(inputBmp);
            Graphics outGr = pictureBox2.CreateGraphics();

            outGr.DrawImage(outBmp, pictureBox2.DisplayRectangle);
        }
        Bitmap ApplyEmbossFilter(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            Random rnd = new Random();
            for (int x = 0; x < image.Width; ++x)
                for (int y = 0; y < image.Height; ++y)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    Color embossedColor = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);

                    int border = trackBar1.Value;

                    int newX = x - rnd.Next(Math.Max(x - image.Width + 1, -border), Math.Min(x, border));
                    int newY = y - rnd.Next(Math.Max(y - image.Height + 1, -border), Math.Min(y, border));

                    Color prevPixelColor = image.GetPixel(newX, newY);

                    int diffR = pixelColor.R - prevPixelColor.R + 128;
                    int diffG = pixelColor.G - prevPixelColor.G + 128;
                    int diffB = pixelColor.B - prevPixelColor.B + 128;

                    embossedColor = Color.FromArgb(Clamp(diffR, 0, 255), Clamp(diffG, 0, 255), Clamp(diffB, 0, 255));

                    result.SetPixel(x, y, embossedColor);
                }

            return result;
        }

        static int Clamp(int value, int minValue, int maxValue)
        {
            if (value < minValue)
            {
                return minValue;
            }
            else if (value > maxValue)
            {
                return maxValue;
            }
            else
            {
                return value;
            }
        }
        private void button3_Click(object sender, EventArgs e) //Save
        {
            if (outBmp == null)
                return;

            outBmp.Save($"{args[0].Substring(0, args[0].LastIndexOf('\\'))}\\{textBox2.Text}.bmp");
        }

        private void trackBar1_Scroll(object sender, EventArgs e) => label4.Text = $"Pixel radius: {trackBar1.Value}";
    }
}
