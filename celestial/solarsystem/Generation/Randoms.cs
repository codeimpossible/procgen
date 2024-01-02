using System;

namespace Solarsystem.Generation {
    public enum RandomDistribution {
        Standard,
        Normal,
        WalkerVoseAlias,
    }

    public static class Randoms {
        private static readonly WeightedList<float> _weightedRange;
        private static readonly WeightedList<float> _bellRange;
        private static readonly Random _random = new Random(CelestialConstants.Seed);

        static Randoms() {
            _weightedRange = new WeightedList<float>(_random);
            _weightedRange.Add(0.1f, 85);
            _weightedRange.Add(0.2f, 80);
            _weightedRange.Add(0.3f, 65);
            _weightedRange.Add(0.4f, 60);
            _weightedRange.Add(0.5f, 45);
            _weightedRange.Add(0.6f, 40);
            _weightedRange.Add(0.7f, 25);
            _weightedRange.Add(0.8f, 20);
            _weightedRange.Add(0.9f, 10);
            _weightedRange.Add(1f, 5);

            _bellRange = new WeightedList<float>(_random);
            _bellRange.Add(0.0f,  1);
            _bellRange.Add(0.1f,  5);
            _bellRange.Add(0.2f, 10);
            _bellRange.Add(0.3f, 20);
            _bellRange.Add(0.4f, 30);
            _bellRange.Add(0.5f, 40);
            _bellRange.Add(0.6f, 30);
            _bellRange.Add(0.7f, 20);
            _bellRange.Add(0.8f, 10);
            _bellRange.Add(0.9f,  5);
            _bellRange.Add(1.0f,  1);
        }

        public static float Chance() {
            return Randoms.InRange(0.0f, 1.0f);
        }

        public static bool Chance(float odds) {
            var result = Randoms.InRange(0.0f, 1.0f);
            return result <= odds;
        }

        public static float InRange(float minimum, float maximum, RandomDistribution distribution = RandomDistribution.Standard) {
            if (distribution == RandomDistribution.Standard)
                return (float)_random.NextDouble() * (maximum - minimum) + minimum;
            else {
                var delta = maximum - minimum;
                var mod = distribution == RandomDistribution.Normal ? _bellRange.Next() : _weightedRange.Next();
                return minimum + (delta * mod);
            }
        }
        public static int InRange(int minimum, int maximum, RandomDistribution distribution = RandomDistribution.Standard) {
            if (distribution == RandomDistribution.Standard)
                return _random.Next(minimum, maximum);
            else {
                var delta = maximum - minimum;
                var mod = distribution == RandomDistribution.Normal ? _bellRange.Next() : _weightedRange.Next();
                return (int)(minimum + (delta * mod));
            }
        }
    }
}
