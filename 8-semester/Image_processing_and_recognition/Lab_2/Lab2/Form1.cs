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
        Bitmap task2Bmp;

        public Form1()
        {
            InitializeComponent();
            gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.Yellow);
            pictureBox1.Refresh();
            args = Environment.GetCommandLineArgs();
        }
        void LoadImage(string path)
        {
            Image inputImage = Bitmap.FromFile(path);

            gr.DrawImage(inputImage, pictureBox1.DisplayRectangle);

            inputBmp = new Bitmap(inputImage);

            int[] gradesCount = new int[256];

            for (int i = 0; i < inputBmp.Width; ++i)
                for (int j = 0; j < inputBmp.Height; ++j)
                    ++gradesCount[inputBmp.GetPixel(i, j).R];

            chart1.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
                chart1.Series[0].Points.AddXY(i, gradesCount[i]);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            if (openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4) != ".bmp")
                return;

            LoadImage(openFileDialog1.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (inputBmp == null)
                return;

            double trackBarValue = Convert.ToDouble(textBox1.Text);
            outBmp = new Bitmap(inputBmp.Width, inputBmp.Height);

            double gammaCorrection = trackBarValue;

            int chanel;
            int[] gradesCount = new int[256];

            for (int i = 0; i < outBmp.Width; ++i)
                for (int j = 0; j < outBmp.Height; ++j)
                {
                    chanel = (int)(255 * Math.Pow(inputBmp.GetPixel(i, j).R / 255.0, gammaCorrection));

                    if (chanel > 255)
                        chanel = 255;

                    ++gradesCount[chanel];

                    outBmp.SetPixel(i, j, Color.FromArgb(chanel, chanel, chanel));
                }

            chart2.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
                chart2.Series[0].Points.AddXY(i, gradesCount[i]);

            Graphics outGr = pictureBox2.CreateGraphics();

            outGr.DrawImage(outBmp, pictureBox2.DisplayRectangle);
        }

        private void button3_Click(object sender, EventArgs e) //Save
        {
            if (outBmp == null)
                return;

            outBmp.Save($"{args[0].Substring(0, args[0].LastIndexOf('\\'))}\\{textBox2.Text}.bmp");
        }

        int Task2Function(int input, int lowerBound, int upperBound)
        {
            if (input <= lowerBound || input >= upperBound)
                return 0;

            return 256 * (input - lowerBound) / (upperBound - lowerBound);
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (inputBmp == null)
                return;

            task2Bmp = new Bitmap(inputBmp);
            chart3.Series[0].Points.Clear();

            int[] gradesCount = new int[256];

            int lowerBound = int.Parse(textBox4.Text);
            int upperBound = int.Parse(textBox5.Text);

            for (int i = 0; i < task2Bmp.Width; ++i)
                for (int j = 0; j < task2Bmp.Height; ++j)
                {
                    int val = Task2Function(task2Bmp.GetPixel(i, j).R, lowerBound, upperBound);
                    task2Bmp.SetPixel(i, j, Color.FromArgb(val, val, val));
                    ++gradesCount[val];
                }
            
            for (int i = 1; i < 256; ++i)
                chart3.Series[0].Points.AddXY(i, gradesCount[i]);

            Graphics task2Gr = pictureBox3.CreateGraphics();

            task2Gr.DrawImage(task2Bmp, pictureBox3.DisplayRectangle);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (task2Bmp == null)
                return;

            task2Bmp.Save($"{args[0].Substring(0, args[0].LastIndexOf('\\'))}\\{textBox3.Text}.bmp");
        }
    }
}
