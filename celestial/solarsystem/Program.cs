using System;
using Newtonsoft.Json;
using Solarsystem;

var systemNoise = new FastNoiseLite();
systemNoise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
systemNoise.SetSeed(Constants.Seed);
systemNoise.SetFrequency(0.05f);
systemNoise.SetFractalType(FastNoiseLite.FractalType.FBm);
systemNoise.SetFractalOctaves(4);
systemNoise.SetFractalLacunarity(.65f);
systemNoise.SetFractalGain(0.96f);
systemNoise.SetFractalWeightedStrength(2.98f);


var star = Generator.CreateStar(StarClassification.K);
var planet = Generator.CreatePlanet();
Console.WriteLine(JsonConvert.SerializeObject(star, Formatting.Indented));
Console.WriteLine(JsonConvert.SerializeObject(planet, Formatting.Indented));
