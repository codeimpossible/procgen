using System;

namespace Solarsystem
{
    [Serializable]
    public struct CelestialRadius {
        private float _solarRadius;

        public CelestialRadius(float f) {
            _solarRadius = f;
        }

        public float RadiusOfEarth {
            get => _solarRadius * 109;
            set => _solarRadius = value / 109;
        }

        public float RadiusOfJupiter {
            get => _solarRadius * 10;
            set => _solarRadius = value / 10;
        }

        public float SolarRadius {
            get => _solarRadius;
            set => _solarRadius = value;
        }

        public static implicit operator float(CelestialRadius r) => r.SolarRadius;
        public static implicit operator CelestialRadius(float f) => new CelestialRadius(f);

        public static CelestialRadius FromEarthRadius(float radius) => new CelestialRadius(0f) { RadiusOfEarth = radius };
    }
}
