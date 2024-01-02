namespace Solarsystem.Generation
{
    public static partial class Generator {
        public static SolarSystem CreateSolarSystem(int id, int planetMin = 0, int planetMax = 10) {
            var roll = Randoms.Chance();
            var system = new SolarSystem() { Id = id };
            if (roll <= 0.76f) {
                // create a M class star
                system.Star = Generator.CreateStar(StarClassification.M);
            } else if (roll >= 0.76f && roll <= 0.88f) {
                // create a K class star
                system.Star = Generator.CreateStar(StarClassification.K);
            } else if (roll > 0.88f && roll <= 0.96f) {
                // create a G class star
                system.Star = Generator.CreateStar(StarClassification.G);
            } else if (roll > 0.96f && roll < 0.99f) {
                // create a F class star
                system.Star = Generator.CreateStar(StarClassification.F);
            } else if (roll >= 0.99f) {
                roll = Randoms.Chance();
                if (roll <= 0.61f) {
                    // create a A class star
                    system.Star = Generator.CreateStar(StarClassification.A);
                } else if (roll > 0.61f && roll <= 0.73f) {
                    // create a B class star
                    system.Star = Generator.CreateStar(StarClassification.B);
                } else { // this isn't the true rarity of this star, but oh well
                    // create a O class star
                    system.Star = Generator.CreateStar(StarClassification.O);
                }
            }

            var planetCount = Randoms.InRange(planetMin, planetMax);
            for(var i = 0; i < planetCount; i++) {
                var planet = Generator.CreatePlanet();
                system.AddPlanet(planet);
            }

            return system;
        }

        public static Galaxy CreateGalaxy(int id, int solarSystemMin = 1, int solarSystemMax = 9) {
            var galaxy = new Galaxy() { Id = id };
            var systemCount = Randoms.InRange(solarSystemMin, solarSystemMax);
            for(var i = 0; i < systemCount; i++) {
                var system = CreateSolarSystem(id * (i + 1));
                galaxy.AddSolarSystem(system);
            }
            return galaxy;
        }

        public static Universe CreateUniverse(int galaxyMin = 3, int galaxyMax = 12) {
            var universe = new Universe();
            var galaxyCount = Randoms.InRange(galaxyMin, galaxyMax);
            for(var i = 0; i < galaxyCount; i++) {
                var galaxy = CreateGalaxy(i);
                universe.Galaxies.Add(galaxy);
            }
            return universe;
        }
    }
}
