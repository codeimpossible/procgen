namespace Solarsystem
{
    public class Star : CelestialBody {
        public StarClassification Class { get; set; }

        /// <summary>
        /// The effective temperature of a body such as a star or planet is the temperature of a black body that would emit the same total amount of electromagnetic radiation.
        /// </summary>

        public CelestialTemperature EffectiveTemperature { get; set; }

        /// <summary>
        /// Chromaticity is an objective specification of the quality of a color regardless of its luminance.
        /// </summary>
        public CelestialChromacity Chromacity { get; set; }

        /// <summary>
        /// In astronomy, luminosity is the total amount of electromagnetic energy emitted per unit of time by a star, galaxy, or other astronomical objects. Values for luminosity are given in the terms of the luminosity of the Sun.
        /// </summary>
        public float Luminosity { get; set; }


        public HydrogenLines HydrogenLines { get; set; }


        public float Rarity { get; set; }
    }
}
