using System.Numerics;

namespace PoissonDiscConsole;

public class PoissonDisc {
    public const float InvertRootTwo = 0.70710678118f; // Becaust two dimension grid.
    public const int DefaultIterationPerPoint = 30;

    public static PoissonSettings CreateSettings(Vector2 bottomLeft, Vector2 topRight, float min, Vector2? startingPoint = null, int seed = 1024, int iterations = DefaultIterationPerPoint) {
        var dimension = (topRight - bottomLeft);
        var cell = min * InvertRootTwo;
        return new PoissonSettings() {
            BottomLeft = bottomLeft,
            TopRight = topRight,
            RandomSeed = seed,
            StartingPoint = startingPoint,
            Center = (bottomLeft + topRight) * 0.5f,

            MinimumDistance = min,
            IterationsPerPoint = iterations,

            CellSize = cell,
            GridWidth = MathHelpers.CeilToInt(dimension.X / cell),
            GridHeight = MathHelpers.CeilToInt(dimension.Y / cell)
        };
    }

    public static Vector2 GetGridIndex(Vector2 point, PoissonSettings set) {
        return new Vector2(
            MathHelpers.FloorToInt((point.X - set.BottomLeft.X) / set.CellSize),
            MathHelpers.FloorToInt((point.Y - set.BottomLeft.Y) / set.CellSize)
        );
    }
}
