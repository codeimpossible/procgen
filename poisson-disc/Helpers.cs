using System.Diagnostics;
using System.Numerics;
using SkiaSharp;

namespace PoissonDiscConsole;

public static class Helpers {
    public static async Task<List<(SKColor Color, List<Vector2> Points)>> GetPoints(int width, int height, float radius, int seed = 1024) {
        var results = new List<(SKColor Color, List<Vector2> Points)>();
        var channels = new List<SKColor>() {
            new(255, 0, 0, 255),
            new(0, 255, 0, 255),
            new(0, 0, 255, 255),
        };
        int count = 0;
        foreach(var channel in channels) {
            count++;
            var settings = PoissonDisc.CreateSettings(Vector2.Zero, new Vector2(width, height), radius, seed: seed << count);
            var points = await Task.Run(() => {
                var sampler = new PoissonSampler(settings);
                while(sampler.Next(out _)) {
                    // continue on...
                }
                return sampler.Points;
            });
            results.Add((channel, points));
        }
        return results;
    }
}
