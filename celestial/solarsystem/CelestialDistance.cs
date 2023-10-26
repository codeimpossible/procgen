namespace Solarsystem;

public struct CelestialDistance {
    private float _astronomicalUnits = 0f;

    public CelestialDistance(float au) {
        _astronomicalUnits = au;
    }

    /// <summary>
    /// The number of seconds it would take to travel the distance if you were moving at the speed of light
    /// </summary>
    public float LightSeconds {
        get => _astronomicalUnits * Constants.AUtoLightSeconds;
        set => _astronomicalUnits  = value / Constants.AUtoLightSeconds;
    }

    public float LightYears {
        get => _astronomicalUnits * Constants.AUtoLightSeconds / Constants.SecondsInYear;
        set => _astronomicalUnits = value * Constants.SecondsInYear / Constants.AUtoLightSeconds;
    }

    public float AU {
        get => _astronomicalUnits;
        set => _astronomicalUnits = value;
    }

    public static implicit operator float(CelestialDistance c) => c.AU;
    public static implicit operator CelestialDistance(float d) => new CelestialDistance(d);

    public static CelestialDistance FromLightYears(float lightYears) => new CelestialDistance(0f) { LightYears = lightYears };
}
