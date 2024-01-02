using System;

namespace Solarsystem
{
    public static class CelestialConstants {
        /// <summary>
        /// The astronomical unit is a unit of length, roughly the distance from Earth to the Sun and approximately equal to 150 million kilometres (93 million miles) or 8.3 light-minutes. The astronomical unit is used primarily for measuring distances within the Solar System or around other stars.
        /// </summary>
        public const long AU = 149_597_870_700;

        /// <summary>
        /// The surface gravity, g, of an astronomical object is the gravitational acceleration experienced at its surface at the equator, including the effects of rotation.
        /// </summary>
        public const float Gravity = 9.80665f;

        /// <summary>
        /// Global seed value. Changing this can alter other seeds.
        /// </summary>
        public const int Seed = 501_922;

        /// <summary>
        /// Returns a multiplier to convert Mass of Earth values to Solar Mass
        /// </summary>
        public const float EarthSolarMassRatio = 1f/333000f;

        /// <summary>
        /// Returns a multiplier to convert Mass of Jupiter values to Solar Mass
        /// </summary>
        public const float JupiterSolarMassRatio = 1f/1047f;

        public const int AUtoLightSeconds = 499;

        public const int SecondsInYear = 60 * 60 * 24 * 365;

        public const float KilometersToMiles = 0.621371f;

        public const float KelvinToCelsius = -273.15f;

        /// <summary>
        /// The speed of light in vacuum, commonly denoted c, is a universal physical constant that is exactly equal to 299,792,458 metres per second.
        /// </summary>
        public const int SpeedOfLight = 299_792_458;

        // /// <summary>
        // /// The solar mass (M☉) is a standard unit of mass in astronomy, equal to approximately 2×1030 kg.
        // /// </summary>
        // public const long SolarMassUnit = (long)(2 * Math.Pow(10, 30));

        // /// <summary>
        // /// Jupiter mass, also called Jovian mass, is the unit of mass equal to the total mass of the planet Jupiter.
        // /// </summary>
        // public const long JupiterMassUnit = (long)(1.89813d * Math.Pow(10, 27));

        // /// <summary>
        // /// An Earth mass (denoted as ⊕M, where ⊕ is the standard astronomical symbol for Earth), is a unit of mass equal to the mass of the planet Earth.
        // /// </summary>
        // public const long MassOfEarth = (long)(5.97219d * Math.Pow(10, 24));
    }
}
