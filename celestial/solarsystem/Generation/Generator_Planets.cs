namespace Solarsystem.Generation
{
    public static partial class Generator {
        public static PlanetData CreatePlanet() {
            var radius = Randoms.InRange(0.1f, 32f);
            var distanceToSun = Randoms.InRange(0.5f, 42f, distribution: RandomDistribution.WalkerVoseAlias); // habitable zone is 0.9 to 1.2 AU
            return new PlanetData() {
                Mass = CelestialMass.FromEarthMass(radius),
                Radius = CelestialRadius.FromEarthRadius(radius),
                Albedo = Randoms.InRange(0.1f, 0.9f), // higher than 0.4 and we're getting into a special planet state, like frozen surface
                RotationTime = Randoms.InRange(0.01f, 32f, distribution: RandomDistribution.WalkerVoseAlias),
                DistanceToSun = distanceToSun,
                OrbitalVelocity = Randoms.InRange(0.1f, 400f, distribution: RandomDistribution.WalkerVoseAlias),
            };
        }
    }
}
