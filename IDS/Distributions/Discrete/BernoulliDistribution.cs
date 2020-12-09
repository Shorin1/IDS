using System;

namespace IDS.Generators.Discrete
{
    public class BernoulliDistribution
    {
        private double _alpha;
        private Random _ran;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alpha">Вероятность успеха</param>
        public BernoulliDistribution(double alpha)
        {
            _alpha = alpha;
            _ran = new Random();
            Console.WriteLine("Test");
        }

        public int Next()
        {
            return Sample() ? 1 : 0;
        }

        private bool Sample()
        {
            var randomValue = _ran.NextDouble();
            return randomValue < _alpha;
        }
    }
}
