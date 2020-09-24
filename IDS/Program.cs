using IDS.Distributions.Continuous;
using IDS.Generators.Discrete;
using System;
using System.Numerics;

namespace IDS
{
    class Program
    {
        static void Main(string[] args)
        {
            var alpha = 0.8;
            var bernoulliDist = new BernoulliDistribution(alpha);
            double count = 0;

            for (int i = 0; i < 1000000; i++)
            {
                var berVarible = bernoulliDist.Next();

                if (berVarible == 1)
                {
                    count++;
                }
            }

            Console.WriteLine("Bernoulli dist");
            Console.WriteLine($"Total: 1000000, Count: {count}, Count/Total: {count / 1000000}");

            var mu = 0.5;
            var laplaceDist = new LaplaceDistribution(alpha, mu);
            var bigInteger = new BigInteger();

            for (int i = 0; i < 1000000; i++)
            {
                var laplaceVarible = laplaceDist.NextDouble();
                bigInteger += (int)laplaceVarible;
            }

            Console.WriteLine($"Total: 1000000, Count: {bigInteger}, Count/Total: {(double)bigInteger / 1000000.0}");
        }
    }
}
