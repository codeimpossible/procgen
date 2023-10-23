// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

class CelestialBody {
    float Albedo;
    float RotationTime;
    float Radius;
    float GravityForce;
    float Mass;
    int SystemId;
}

class PlanetData : CelestialBody {
    float OrbialVelocity;
    float DistanceToSun;
}

enum StarClassification {
    O,
    B,
    A,
    F,
    G,
    K,
    M,
}

class Star : CelestialBody {
    StarClassification Class;
    int EffectiveTempKelvin;
    Color Chromacity;
}


var systemNoise = new FastNoiseLite();
systemNoise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
systemNoise.SetSeed(Helpers.ElevationSeed);
systemNoise.SetFrequency(0.05f);
systemNoise.SetFractalType(FastNoiseLite.FractalType.FBm);
systemNoise.SetFractalOctaves(4);
systemNoise.SetFractalLacunarity(.65f);
systemNoise.SetFractalGain(0.96f);
systemNoise.SetFractalWeightedStrength(2.98f);
