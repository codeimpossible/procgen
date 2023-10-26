namespace Solarsystem;

public static partial class Generator {
    public static Star CreateStar(StarClassification classification) {
        return new Star() {
            EffectiveTemperature = GetEffectiveTemperature(classification),
            Mass = GetStarMass(classification),
            Radius = GetStarRadius(classification),
            Rarity = GetStarRarity(classification),
            HydrogenLines = GetStarHydrogenLines(classification),
            Luminosity = GetStarLuminosity(classification),
            Albedo = 1f,
            RotationTime = 1f,
        };
    }

    public static int GetEffectiveTemperature(StarClassification classification) {
        switch(classification) {
            case StarClassification.O: return Randoms.InRange(32_000, 50_000);
            case StarClassification.B: return Randoms.InRange(10_000, 30_000);
            case StarClassification.A: return Randoms.InRange(7_500, 10_000);
            case StarClassification.F: return Randoms.InRange(6_000, 7_500);
            case StarClassification.G: return Randoms.InRange(5_200, 6_000);
            case StarClassification.K: return Randoms.InRange(3_700, 5_200);
            case StarClassification.M:
            default: return Randoms.InRange(2_400, 3_700);
        }
    }

    public static float GetStarLuminosity(StarClassification classification) {
        switch(classification) {
            case StarClassification.O: return Randoms.InRange(30_000, 50_000);
            case StarClassification.B: return Randoms.InRange(25_000, 30_000);
            case StarClassification.A: return Randoms.InRange(5_000, 25_000);
            case StarClassification.F: return Randoms.InRange(1_500, 5_000);
            case StarClassification.G: return Randoms.InRange(600, 1_500);
            case StarClassification.K: return Randoms.InRange(80, 600);
            case StarClassification.M:
            default: return Randoms.InRange(0.01f, 80);
        }
    }

    public static CelestialMass GetStarMass(StarClassification classification) {
        var mass = 0f;
        switch(classification) {
            case StarClassification.O: mass = Randoms.InRange(16f, 3_200f); break;
            case StarClassification.B: mass = Randoms.InRange(2.1f, 16f); break;
            case StarClassification.A: mass = Randoms.InRange(1.4f, 2.1f); break;
            case StarClassification.F: mass = Randoms.InRange(1.04f, 1.4f); break;
            case StarClassification.G: mass = Randoms.InRange(0.8f, 1.04f); break;
            case StarClassification.K: mass = Randoms.InRange(0.45f, 0.8f); break;
            case StarClassification.M:
            default: mass = Randoms.InRange(0.08f, 0.45f); break;
        }
        return CelestialMass.FromSolarMass(mass);
    }

    public static float GetStarRadius(StarClassification classification) {
        switch(classification) {
            case StarClassification.O: return Randoms.InRange(6.6f, 3_200f);
            case StarClassification.B: return Randoms.InRange(1.8f, 6.6f);
            case StarClassification.A: return Randoms.InRange(1.4f, 1.8f);
            case StarClassification.F: return Randoms.InRange(1.15f, 1.4f);
            case StarClassification.G: return Randoms.InRange(0.96f, 1.15f);
            case StarClassification.K: return Randoms.InRange(0.7f, 0.96f);
            case StarClassification.M:
            default: return Randoms.InRange(0.01f, 0.7f);
        }
    }

    public static float GetStarRarity(StarClassification classification) {
        switch(classification) {
            case StarClassification.O: return 0.000030f;
            case StarClassification.B: return 0.12f;
            case StarClassification.A: return 0.61f;
            case StarClassification.F: return 3f;
            case StarClassification.G: return 7.6f;
            case StarClassification.K: return 12f;
            case StarClassification.M:
            default: return 76f;
        }
    }

    public static HydrogenLines GetStarHydrogenLines(StarClassification classification) {
        switch(classification) {
            case StarClassification.O: return HydrogenLines.Weak;
            case StarClassification.B: return HydrogenLines.Medium;
            case StarClassification.A: return HydrogenLines.Strong;
            case StarClassification.F: return HydrogenLines.Medium;
            case StarClassification.G: return HydrogenLines.Weak;
            case StarClassification.K: return HydrogenLines.VeryWeak;
            case StarClassification.M:
            default: return HydrogenLines.VeryWeak;
        }
    }
}
