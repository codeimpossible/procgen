using System.Collections.Generic;

namespace Solarsystem
{
    public class Galaxy {
        public int Id { get; set; }
        public List<SolarSystem> Systems { get; set; } = new List<SolarSystem>();

        public void AddSolarSystem(SolarSystem system) {
            system.GalaxyId = Id;
            Systems.Add(system);
        }
    }
}
