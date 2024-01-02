using System;

namespace Solarsystem
{
    [Serializable]
    public struct CelestialTemperature {
        private float _kelvin;

        public CelestialTemperature(float kelvin) {
            _kelvin = kelvin;
        }

        /// <summary>
        /// The temperature in the celsius temperature scale.
        /// </summary>
        /// <remarks>See: https://en.wikipedia.org/wiki/Celsius</remarks>
        public float Celsius {
            get => _kelvin + CelestialConstants.KelvinToCelsius;
            set => _kelvin = value - CelestialConstants.KelvinToCelsius;
        }

        /// <summary>
        /// The temperature in the farenheit temperature scale.
        /// </summary>
        /// <remarks>See: https://en.wikipedia.org/wiki/Fahrenheit</remarks>
        public float Farenheit {
            get => _kelvin * 1.8f - 459.67f;
            set => _kelvin = value + 459.67f / 1.8f;
        }

        /// <summary>
        /// The temperature in the kelvin temperature scale.
        /// </summary>
        /// <remarks>See: https://en.wikipedia.org/wiki/Kelvin</remarks>
        public float Kelvin {
            get => _kelvin;
            set => _kelvin = value;
        }

        public static implicit operator float(CelestialTemperature ct) => ct.Kelvin;
        public static implicit operator CelestialTemperature(float kelvin) => new CelestialTemperature(kelvin);
    }
}
