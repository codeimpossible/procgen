using System.Numerics;

namespace PoissonDiscConsole;

public class PoissonSampler {
    private readonly PoissonSettings _settings;
    private readonly PoissonBags _bags;
    private readonly Random _random;
    public PoissonSampler(PoissonSettings settings, PoissonBags? bags = null) {
        _settings = settings;
        _bags = bags ?? CreateBags();
        _random = new Random(settings.RandomSeed);
    }

    public List<Vector2> Points => _bags.SamplePoints;
    public List<Vector2> ActivePoints => _bags.ActivePoints;
    public Vector2? StartingPoint { get; private set; }

    public bool Next(out int iterations) {
        iterations = 0;
        if (_bags.SamplePoints.Count == 0) {
            GetFirstPoint();
        }
        var index = _random.Next(0, _bags.ActivePoints.Count);
        var point = _bags.ActivePoints[index];
        var found = false;
        for(var k = 0; k < _settings.IterationsPerPoint; k++) {
            found |= GetNextPoint(point);
            iterations++;
        }

        if(found == false) {
            _bags.ActivePoints.RemoveAt(index);
        }
        return _bags.ActivePoints.Count > 0;
    }

    public async Task<List<Vector2>> GetSamplePointsAsync() {
        await Task.Run(() => {
            while(!Next(out _)) {

            }
        });
        var list = new List<Vector2>();
        foreach(var point in Points) {
            list.Add(point);
        }
        return list;
    }

    private PoissonBags CreateBags() {
        return new PoissonBags()
        {
            Grid = new Vector2?[_settings.GridWidth + 1, _settings.GridHeight + 1],
            SamplePoints = [],
            ActivePoints = []
        };
    }

    private void GetFirstPoint() {
        var first = new Vector2(
            NextFloat(_settings.BottomLeft.X, _settings.TopRight.X),
            NextFloat(_settings.BottomLeft.Y, _settings.TopRight.Y)
        );
        if (_settings.StartingPoint.HasValue) {
            first = _settings.StartingPoint.Value;
        }
        StartingPoint = first;
        var index = PoissonDisc.GetGridIndex(first, _settings);

        _bags.Grid[(int)index.X, (int)index.Y] = first;
        _bags.SamplePoints.Add(first);
        _bags.ActivePoints.Add(first);
    }

    private bool GetNextPoint(Vector2 point) {
        var found = false;
        var p = GetRandPosInCircle(_settings.MinimumDistance, 2f * _settings.MinimumDistance) + point;

        if (_settings.DimensionsContainPoint(p.X, p.Y) == false) {
            return false;
        }

        var minimum = _settings.MinimumDistance * _settings.MinimumDistance;
        var index = PoissonDisc.GetGridIndex(p, _settings);
        var drop = false;

        // Although it is Mathf.CeilToInt(set.MinimumDistance / set.CellSize) in the formula, It will be 2 after all.
        var around = 2;
        var fieldMin = new Vector2(Math.Max(0, index.X - around), Math.Max(0, index.Y - around));
        var fieldMax = new Vector2(Math.Min(_settings.GridWidth, index.X + around), Math.Min(_settings.GridHeight, index.Y + around));

        for (var i = fieldMin.X; i <= fieldMax.X && drop == false; i++) {
            for (var j = fieldMin.Y; j <= fieldMax.Y && drop == false; j++) {
                var q = _bags.Grid[(int)i, (int)j];
                if (q.HasValue == true && (q.Value - p).LengthSquared() <= minimum) {
                    drop = true;
                }
            }
        }

        if (drop == false) {
            found = true;

            _bags.SamplePoints.Add(p);
            _bags.ActivePoints.Add(p);
            _bags.Grid[(int)index.X, (int)index.Y] = p;
        }

        return found;
    }

    private float NextFloat(float min, float max) {
        var t = _random.Next(0, 65535);
        var range = (float)((float)t/65535f);
        var delta = max - min;
        return min + (delta * range);
    }

    private Vector2 GetRandPosInCircle(float fieldMin, float fieldMax) {
        var theta = NextFloat(0f, MathF.PI * 2);
        var r = NextFloat(fieldMin * fieldMin, fieldMax * fieldMax);
        var radius = MathF.Sqrt(r);

        return new Vector2(radius * MathF.Cos(theta), radius * MathF.Sin(theta));
    }
}
