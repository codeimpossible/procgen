namespace Solarsystem;

public struct CelestialTemperature {
    private float _kelvin = 0f;

    public CelestialTemperature(float kelvin) {
        _kelvin = kelvin;
    }

    public float Celsius {
        get => _kelvin + Constants.KelvinToCelsius;
        set => _kelvin = value - Constants.KelvinToCelsius;
    }

    public float Farenheit {
        get => _kelvin * 1.8f - 459.67f;
        set => _kelvin = value + 459.67f / 1.8f;
    }

    public float Kelvin {
        get => _kelvin;
        set => _kelvin = value;
    }

    public static implicit operator float(CelestialTemperature ct) => ct.Kelvin;
    public static implicit operator CelestialTemperature(float kelvin) => new(kelvin);
}
