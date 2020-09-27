using IDS.Generators.Discrete;
using System;
using System.IO;

namespace IDS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите вероятность p: ");
            var p = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите n ");
            int n = int.Parse(Console.ReadLine());
            var bernoulliDist = new BernoulliDistribution(p);

            string fileName = "BernoulliDist.txt";

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

                    if (i % 10 == 0)
                    {
                        sw.WriteLine($"{i} {count / i};");
                    }
                }
            }

            //Console.WriteLine("Bernoulli dist");
            //Console.WriteLine($"Total: 1000000, Count: {count}, Count/Total: {count / 1000000}");

            //var mu = 0.5;
            //var laplaceDist = new LaplaceDistribution(alpha, mu);
            //var bigInteger = new BigInteger();

            //for (int i = 0; i < 1000000; i++)
            //{
            //    var laplaceVarible = laplaceDist.NextDouble();
            //    bigInteger += (int)laplaceVarible;
            //}

            //Console.WriteLine("Laplace dist");
            //Console.WriteLine($"Total: 1000000, Count: {bigInteger}, Count/Total: {(double)bigInteger / 1000000.0}");
        }
    }
}
