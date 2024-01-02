using System.Collections.Generic;

namespace Solarsystem
{
    public class SolarSystem {
        private Star _star = new Star();

        public int Id { get; set; }

        public int GalaxyId { get; set; }

        public Star Star {
            get => _star;
            set {
                _star = value;
                _star.SystemId = Id;
            }
        }

        public List<PlanetData> Planets { get; set; } = new List<PlanetData>();

        public void AddPlanet(PlanetData planet) {
            planet.SystemId = Id;
            Planets.Add(planet);
            Planets.Sort((a,b) => a.DistanceToSun < b.DistanceToSun ? -1 : 1);
        }
    }
}
