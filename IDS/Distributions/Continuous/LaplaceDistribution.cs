using System;

namespace IDS.Distributions.Continuous
{
    public class LaplaceDistribution
    {
        private double _alpha;
        private double _mu;
        private Random _rand;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alpha">Мат ожидание</param>
        /// <param name="mu">Дисперсия</param>
        public LaplaceDistribution(double alpha, double mu)
        {
            _alpha = alpha;
            _mu = mu;
            _rand = new Random();
        }

        public double NextDouble()
        {
            return Sample();
        }

        private double Sample()
        {
            var rand = 0.5 - _rand.NextDouble();
            var tmp = IsZero(rand)
                ? double.NegativeInfinity
                : Math.Log(2.0 * Math.Abs(rand));
            return _mu - _alpha * Math.Sign(rand) * tmp;
        }

        private bool IsZero(double rand)
        {
            return rand == 0;
        }
    }
}
