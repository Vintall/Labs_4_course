using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding("koi8-u");

            while (true)
            {
                try
                {
                    Console.WriteLine("Обчислення оптимальної стратегії за критерієм Вальда");
                    Console.WriteLine("Введіть матрицю N*K (n - строки)");

                    Console.Write("Введіть N: ");
                    int n = int.Parse(Console.ReadLine());

                    Console.Write("Введіть K: ");
                    int k = int.Parse(Console.ReadLine());

                    float[,] matrix = new float[n, k];
                    float[] max_values = new float[n];
                    float min_from_max_values = 0;

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < k; j++)
                        {
                            Console.Write($"Введіть елемент а[{i+1};{j+1}]: ");
                            matrix[i, j] = float.Parse(Console.ReadLine());

                            if (j == 0)
                                max_values[i] = matrix[i, j];
                            else if (matrix[i, j] > max_values[i])
                                max_values[i] = matrix[i, j];
                        }
                        if (i == 0)
                            min_from_max_values = max_values[i];
                        else if (max_values[i] < min_from_max_values)
                            min_from_max_values = max_values[i];

                        Console.WriteLine($"Max(a[{i+1}]) = {max_values[i]}");
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"Мінімальне значення: {min_from_max_values}");
                    Console.ReadKey();
                }
                catch
                {
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
