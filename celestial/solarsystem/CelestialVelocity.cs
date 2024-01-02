namespace Solarsystem
{
    public struct CelestialVelocity {
        private float _kilometersPerSecond;

        public CelestialVelocity(float kilometersPerSecond) {
            _kilometersPerSecond = kilometersPerSecond;
        }

        public float SpeedOfLight {
            get => _kilometersPerSecond * 1000f / CelestialConstants.SpeedOfLight;
            set => _kilometersPerSecond = value * CelestialConstants.SpeedOfLight / 1000f;
        }

        public float KilometersPerSecond {
            get => _kilometersPerSecond;
            set => _kilometersPerSecond = value;
        }

        public float MilesPerHour {
            get => _kilometersPerSecond * CelestialConstants.KilometersToMiles / 60 / 60;
            set => _kilometersPerSecond = value * 60 * 60 / CelestialConstants.KilometersToMiles;
        }

        public static implicit operator float(CelestialVelocity cv) => cv.KilometersPerSecond;
        public static implicit operator CelestialVelocity(float velocity) => new CelestialVelocity(velocity);
    }
}
