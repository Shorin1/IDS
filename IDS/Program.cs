using IDS.Distributions.Continuous;
using IDS.Generators.Discrete;
using System;
using System.IO;
using System.Numerics;

namespace IDS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество итераций");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Интервал записи в файл");
            int interval = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите вероятность p: ");
            var p = double.Parse(Console.ReadLine());
            var bernoulliDist = new BernoulliDistribution(p);

            string fileName = "BernoulliDist.txtdad";

            int count = 0;

            using (var sw = new StreamWriter(fileName))
            {
                for (double i = 1; i <= n; i++)
                {
                    double berVarible = bernoulliDist.Next();

                    if (berVarible == 1)
                    {
                        count++;
                    }

                    if (i % interval == 0)
                    {
                        sw.WriteLine($"{i} {count / i};");
                    }
                }
            }

            Console.WriteLine("--- Bernoulli dist ---");
            Console.WriteLine($"Total: 1000000, Count: {count}, Count/Total: {(double)count / n}");

            Console.WriteLine("Введите дисперсию: ");
            var mu = double.Parse(Console.ReadLine());

            fileName = "LaplaceDist.txt";
            var bigInteger = new BigInteger();

            using (var sw = new StreamWriter(fileName))
            {
                var laplaceDist = new LaplaceDistribution(p, mu);

                for (int i = 0; i < n; i++)
                {
                    var laplaceVarible = laplaceDist.NextDouble();
                    
                    if (i % interval == 0)
                    {
                        sw.WriteLine($"{i} {laplaceVarible}");
                    }
                }
            }

            Console.WriteLine("--- Laplace dist ---");
        }
    }
}
