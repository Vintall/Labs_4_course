using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

namespace Lab_1
{
    internal class Program
    {
        public struct Pixel
        {
            public byte r;
            public byte g; 
            public byte b;
        };
        static void Main(string[] args)
        {
            //Path
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string inputFileName = "Input.bmp";
            string outputFileName = "Output.bmp";

            string fullInputPath = $"{basePath}/{inputFileName}";
            string fullOutputPath = $"{basePath}/{outputFileName}";

            //All bytes
            List<byte> file = new List<byte>(File.ReadAllBytes(fullInputPath));

            int width = BitConverter.ToInt32(file.ToArray(), 18);
            int height = BitConverter.ToInt32(file.ToArray(), 22);

            int headerSize = BitConverter.ToInt32(file.ToArray(), 14);
            int colorsBytes = BitConverter.ToInt32(file.ToArray(), 46) * 4;


            //Size
            Console.WriteLine($"Width: {width}  Height: {height}");
            Console.WriteLine($"Bytes: {file.Count}");
            Console.WriteLine($"Bits per Pixel: {BitConverter.ToInt16(file.ToArray(), 28)}");
            Console.WriteLine($"Colors count: {colorsBytes / 4}");
            Console.WriteLine($"Header size: {headerSize}");
            Console.WriteLine($"Full size: {14 + headerSize + colorsBytes}");
            Console.Read();

            //Image sheet
            Pixel[,] image = new Pixel[height, width];

            int byteIndex = 14 + headerSize + colorsBytes * 8;
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    byte b = file[byteIndex++];
                    byte g = file[byteIndex++];
                    byte r = file[byteIndex++];
                    //byteIndex++;

                    image[i, j] = new Pixel { r = r, g = g, b = b };
                }

            //Modifications
            for (int i = 0; i < height; i++)
                for (int j = width - 35; j < width; j++)
                    image[i, j] = new Pixel {r = 0, g = 0, b = 255};

            //Output bytes writing
            byteIndex = 14 + headerSize + colorsBytes * 8;
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    file[byteIndex++] = image[i, j].b;
                    file[byteIndex++] = image[i, j].g;
                    file[byteIndex++] = image[i, j].r;
                    //byteIndex++;
                }

            //File writing
            if (!File.Exists(fullOutputPath))
                File.Create(fullOutputPath);

            File.WriteAllBytes(fullOutputPath, file.ToArray());
        }
    }
}
