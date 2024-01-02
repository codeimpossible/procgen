using System;

namespace Solarsystem
{
    [Serializable]
    public struct CelestialDistance {
        private float _astronomicalUnits;

        public CelestialDistance(float au = 0f) {
            _astronomicalUnits = au;
        }

        /// <summary>
        /// The number of seconds it would take to travel the distance if you were moving at the speed of light
        /// </summary>
        public float LightSeconds {
            get => _astronomicalUnits * CelestialConstants.AUtoLightSeconds;
            set => _astronomicalUnits  = value / CelestialConstants.AUtoLightSeconds;
        }

        public float LightYears {
            get => _astronomicalUnits * CelestialConstants.AUtoLightSeconds / CelestialConstants.SecondsInYear;
            set => _astronomicalUnits = value * CelestialConstants.SecondsInYear / CelestialConstants.AUtoLightSeconds;
        }

        public float AU {
            get => _astronomicalUnits;
            set => _astronomicalUnits = value;
        }

        public static implicit operator float(CelestialDistance c) => c.AU;
        public static implicit operator CelestialDistance(float d) => new CelestialDistance(d);

        public static CelestialDistance FromLightYears(float lightYears) => new CelestialDistance(0f) { LightYears = lightYears };
    }
}
