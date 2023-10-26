namespace Solarsystem;

public struct CelestialVelocity {
    private float _kilometersPerSecond = 0f;

    public CelestialVelocity(float kilometersPerSecond) {
        _kilometersPerSecond = kilometersPerSecond;
    }

    public float SpeedOfLight {
        get => _kilometersPerSecond * 1000f / Constants.SpeedOfLight;
        set => _kilometersPerSecond = value * Constants.SpeedOfLight / 1000f;
    }

    public float KilometersPerSecond {
        get => _kilometersPerSecond;
        set => _kilometersPerSecond = value;
    }

    public float MilesPerHour {
        get => _kilometersPerSecond * Constants.KilometersToMiles / 60 / 60;
        set => _kilometersPerSecond = value * 60 * 60 / Constants.KilometersToMiles;
    }

    public static implicit operator float(CelestialVelocity cv) => cv.KilometersPerSecond;
    public static implicit operator CelestialVelocity(float velocity) => new CelestialVelocity(velocity);
}
