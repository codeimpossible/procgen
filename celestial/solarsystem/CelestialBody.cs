namespace Solarsystem;

public class CelestialBody {
    /// <summary>
    /// The fraction of the incoming solar energy scattered by a planet back to space is referred to as the planetary albedo.
    /// </summary>
    public float Albedo { get; set; }

    /// <summary>
    /// The sidereal rotation period (or sidereal day), i.e., the time that the object takes to complete a full rotation around its axis relative to the background stars (inertial space) expressed in a ratio of earth days.
    /// </summary>
    /// <remarks>A value of <c>0.5</c> would mean that this body completes a full rotation in 12h or 1/2 an earth day</remarks>
    public float RotationTime { get; set; }

    /// <summary>
    /// The distance between the center to the circumference of a circle or sphere.
    /// </summary>
    public CelestialRadius Radius { get; set; }

    public float GravityForce => Mass;

    /// <summary>
    /// An Earth mass is a unit of mass equal to the mass of the planet Earth.
    /// </summary>
    public CelestialMass Mass { get; set; }

    /// <summary>
    /// The id of the system that this body belongs to
    /// </summary>
    public int SystemId { get; set; } = -1;
}
