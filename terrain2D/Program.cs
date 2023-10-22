using SkiaSharp;

int height = 240;
int width = 320;

DrawMap("m01", width, height, -width, -height);
DrawMap("m02", width, height, 0, -height);
DrawMap("m03", width, height, +width, -height);

DrawMap("m04", width, height, -width, 0);
DrawMap("m05", width, height, 0, 0);
DrawMap("m06", width, height, +width, 0);

DrawMap("m07", width, height, -width, height);
DrawMap("m08", width, height, 0, height);
DrawMap("m09", width, height, +width, height);


void DrawMap(string mapName, int width, int height, int offsetX, int offsetY) {
    float[,] elevation = new float[height, width];
    float[,] moisture = new float[height, width];
    // build elevation
    var elevationNoise = new FastNoiseLite();
    elevationNoise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
    elevationNoise.SetSeed(Helpers.ElevationSeed);
    elevationNoise.SetFrequency(0.05f);
    elevationNoise.SetFractalType(FastNoiseLite.FractalType.FBm);
    elevationNoise.SetFractalOctaves(4);
    elevationNoise.SetFractalLacunarity(.65f);
    elevationNoise.SetFractalGain(0.96f);
    elevationNoise.SetFractalWeightedStrength(2.98f);
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            var el = elevationNoise.GetNoise(x + offsetX, y + offsetY)/ 2.0f + 0.5f;
            elevation[y, x] = el;
        }
    }

    // build moisture
    var moistureNoise = new FastNoiseLite();
    moistureNoise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
    moistureNoise.SetSeed(Helpers.MoistureSeed);
    moistureNoise.SetFrequency(0.01f);
    moistureNoise.SetFractalType(FastNoiseLite.FractalType.FBm);
    moistureNoise.SetFractalOctaves(6);
    moistureNoise.SetFractalLacunarity(2f);
    moistureNoise.SetFractalGain(0.3f);
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            var m = moistureNoise.GetNoise(x + offsetX, y + offsetY)/ 2.0f + 0.5f;
            moisture[y, x] = m;
        }
    }

    Console.WriteLine($"elevation cell: (x: {offsetX}, y: {offsetY}) (width: {width}, height: {height})");
    Helpers.CreateBitmap($"./{mapName}-elevation.png", width, height, (x, y) => {
        var f = elevation[y, x];
        var c = (byte)(255 * f);
        var color = new SKColor(c, c, c, 255);
        return color;
    });
    Console.WriteLine($" moisture cell: (x: {offsetX}, y: {offsetY}) (width: {width}, height: {height})");
    Helpers.CreateBitmap($"./{mapName}-moisture.png", width, height, (x, y) => {
        var m = moisture[y, x];
        var c = (byte)(255 * m);
        var color = new SKColor(c, c, c, 255);
        return color;
    });
    Console.WriteLine($"      map cell: (x: {offsetX}, y: {offsetY}) (width: {width}, height: {height})");
    Helpers.CreateBitmap($"./{mapName}-generatedimage.png", width, height, (x, y) => {
        var f = elevation[y, x];
        var m = moisture[y, x];
        var c = Helpers.GetBiome(f, m);
        return Helpers.Palette[c];
    });
    Console.WriteLine("Done!");
}
