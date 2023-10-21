using SkiaSharp;

public static class Helpers
{
    public static int ElevationSeed = 4096;
    public static int MoistureSeed = 8192;

    public static void CreateBitmap(string filename, int width, int height, Func<int, int, SKColor> pxDelegate) {
        using var bitmap = new SKBitmap(width, height);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var px = pxDelegate(x, y);
                bitmap.SetPixel(x, y, px);
            }
        }
        using var file = File.OpenWrite(filename);
        bitmap.Encode(file, SKEncodedImageFormat.Png, 100);
    }

    public static Dictionary<char, SKColor> Palette = new() {
        { Constants.OCEAN, SKColor.Parse("44447a") },
        { Constants.BEACH, SKColor.Parse("a09077") },
        { Constants.SCORCHED, SKColor.Parse("bbbbaa") },
        { Constants.BARE, SKColor.Parse("888888") },
        { Constants.TUNDRA, SKColor.Parse("c9d29b") },
        { Constants.TAIGA, SKColor.Parse("889977") },
        { Constants.SNOW, SKColor.Parse("dddde4") },
        { Constants.TEMPERATE_DESERT, SKColor.Parse("d2b98b") },
        { Constants.SHRUBLAND, SKColor.Parse("88aa55") },
        { Constants.GRASSLAND, SKColor.Parse("99aa77") },
        { Constants.TEMPERATE_DECIDUOUS_FOREST, SKColor.Parse("679459") },
        { Constants.TEMPERATE_RAIN_FOREST, SKColor.Parse("889977") },
        { Constants.SUBTROPICAL_DESERT, SKColor.Parse("559944") },
        { Constants.TROPICAL_SEASONAL_FOREST, SKColor.Parse("448855") },
        { Constants.TROPICAL_RAIN_FOREST, SKColor.Parse("337755") },
    };

    public static char GetBiome(float e, float m)
    {
        // these thresholds will need tuning to match your generator
        if (e < 0.1f) return Constants.OCEAN;
        if (e < 0.12f) return Constants.BEACH;

        if (e > 0.8f)
        {
            if (m < 0.1f) return Constants.SCORCHED;
            if (m < 0.2f) return Constants.BARE;
            if (m < 0.5f) return Constants.TUNDRA;
            return Constants.SNOW;
        }

        if (e > 0.6f)
        {
            if (m < 0.33f) return Constants.TEMPERATE_DESERT;
            if (m < 0.66f) return Constants.SHRUBLAND;
            return Constants.TAIGA;
        }

        if (e > 0.3f)
        {
            if (m < 0.16f) return Constants.TEMPERATE_DESERT;
            if (m < 0.50f) return Constants.GRASSLAND;
            if (m < 0.83f) return Constants.TEMPERATE_DECIDUOUS_FOREST;
            return Constants.TEMPERATE_RAIN_FOREST;
        }

        if (m < 0.16f) return Constants.SUBTROPICAL_DESERT;
        if (m < 0.33f) return Constants.GRASSLAND;
        if (m < 0.66f) return Constants.TROPICAL_SEASONAL_FOREST;
        return Constants.TROPICAL_RAIN_FOREST;
    }
}
