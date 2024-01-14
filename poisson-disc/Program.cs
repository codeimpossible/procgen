using System.Diagnostics;
using PoissonDiscConsole;
using SkiaSharp;

T GetArgument<T>(string name, T defaultValue = default(T)) {
    object result = null;
    foreach(var arg in Environment.GetCommandLineArgs()) {
        if (arg.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)) {
            var val = arg.Split('=')[1];
            if (defaultValue is long) {
                result = Convert.ToInt64(val);
                break;
            }
            if (defaultValue is int) {
                result = Convert.ToInt32(val);
                break;
            }
            if (defaultValue is short) {
                result = Convert.ToInt16(val);
                break;
            }
            if (defaultValue is float) {
                result = Convert.ToSingle(val);
                break;
            }
            if (defaultValue is string) {
                result = val;
                break;
            }
        }
    }
    return result == null ? defaultValue : (T)result;
}

var arguments = Environment.GetCommandLineArgs();
var bitmapName = $"{GetArgument<string>("--prefix", "disc")}";
var runs = GetArgument<int>("--count", 1);
int width = GetArgument<int>("--width", 512);
int height = GetArgument<int>("--height", 512);
int seed = GetArgument<int>("--seed", 1024);
float radius = GetArgument<float>("--radius", 8f);

for(var i = 0; i < runs; i++) {
    Console.WriteLine("Creating a new sample...");
    var sw = Stopwatch.StartNew();
    var results = await Helpers.GetPoints(width, height, radius, seed);
    var pointGenerationTime = sw.ElapsedMilliseconds;
    sw.Restart();
    using var bitmap = new SKBitmap(width, height);
    new SKCanvas(bitmap).Clear(new SKColor(0,0,0,255));
    foreach(var (color, points) in results) {
        foreach(var p in points) {
            bitmap.SetPixel((int)p.X, (int)p.Y, color);
        }
    }
    using var file = File.OpenWrite($"./{bitmapName}-{width}-{height}-{radius}-{seed}-{i}.png");
    bitmap.Encode(file, SKEncodedImageFormat.Png, 100);
    var bitmapTime = sw.ElapsedMilliseconds;
    sw.Stop();
    Console.WriteLine($"Done! points={results.Sum(r => r.Points.Count)}, pointTime={pointGenerationTime}ms, imgTime={bitmapTime}ms");
}
