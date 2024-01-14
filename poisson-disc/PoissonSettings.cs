using System.Numerics;

namespace PoissonDiscConsole;

public struct PoissonSettings {
    public Vector2 BottomLeft;
    public Vector2 TopRight;
    public Vector2 Center;
    public Vector2? StartingPoint;
    public int RandomSeed;
    public float MinimumDistance;
    public int IterationsPerPoint;

    public bool DimensionsContainPoint(float x, float y) {
        return x >= BottomLeft.X && x <= TopRight.X && y >= BottomLeft.Y && y <= TopRight.Y;
    }

    public float CellSize;
    public int GridWidth;
    public int GridHeight;
}
