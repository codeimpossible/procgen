namespace Solarsystem;

public class PlanetData : CelestialBody {
    /// <summary>
    /// The speed at which it orbits around either the barycenter or, if one body is much more massive than the other bodies of the system combined, its speed relative to the center of mass of the most massive body.
    /// </summary>
    /// <remarks>Value is in km/s</remarks>
    public CelestialVelocity OrbitalVelocity  { get; set; }

    /// <summary>
    /// The distance from this planet to its nearest star, in <see cref="Constants.AU"/>.
    /// </summary>
    public CelestialDistance DistanceToSun { get; set; }
}
