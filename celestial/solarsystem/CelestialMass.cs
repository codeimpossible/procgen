using System;

namespace Solarsystem
{
    [Serializable]
    public struct CelestialMass {
        private float _massOfEarth;

        /// <summary>
        /// Represents the mass of an object within a solar system.
        /// </summary>
        /// <param name="mass">The mass of the object relative to the mass of earth.</param>
        public CelestialMass(float mass) {
            _massOfEarth = mass;
        }

        /// <summary>
        /// The mass of the <see cref="CelestialBody"/> relative to the mass of the Sun.
        /// </summary>
        /// <remarks>See: https://en.wikipedia.org/wiki/Solar_mass</remarks>
        public float SolarMass {
            get => _massOfEarth * CelestialConstants.EarthSolarMassRatio;
            set => _massOfEarth = value / CelestialConstants.EarthSolarMassRatio;
        }

        /// <summary>
        /// The mass of the <see cref="CelestialBody"/> relative to Jupiters mass.
        /// </summary>
        /// <remarks>See: https://en.wikipedia.org/wiki/Jupiter_mass</remarks>
        public float MassOfJupiter {
            get => _massOfEarth * CelestialConstants.EarthSolarMassRatio / CelestialConstants.JupiterSolarMassRatio;
            set => _massOfEarth = value * CelestialConstants.JupiterSolarMassRatio / CelestialConstants.EarthSolarMassRatio;
        }

        /// <summary>
        /// The mass of the <see cref="CelestialBody" /> relative to Earths mass.
        /// </summary>
        /// <remarks>See: https://en.wikipedia.org/wiki/Earth_mass</remarks>
        public float MassOfEarh {
            get => _massOfEarth;
            set => _massOfEarth = value;
        }

        public static implicit operator float(CelestialMass m) => m.MassOfEarh;
        public static implicit operator CelestialMass(float f) => new CelestialMass(f);

        public static CelestialMass FromSolarMass(float solarMass) => new CelestialMass(0f) { SolarMass = solarMass };
        public static CelestialMass FromEarthMass(float earthMass) => new CelestialMass(0f) { MassOfEarh = earthMass };
    }
}
