namespace Solarsystem
{
    public struct CelestialChromacity {
        private const float ColorChannelMaxValue = 255f;

        private int _red;
        private int _blue;
        private int _green;
        private int _alpha;
        public CelestialChromacity(int r = 255, int g = 255, int b = 255, int a = 255) {
            _red = r;
            _green = g;
            _blue = b;
            _alpha = a;
            ClampAll();
        }

        public CelestialChromacity(float r = 1f, float g = 1f, float b = 1f, float a = 1f) {
            _red = (int)(r * ColorChannelMaxValue);
            _green = (int)(g * ColorChannelMaxValue);
            _blue = (int)(b * ColorChannelMaxValue);
            _alpha = (int)(a * ColorChannelMaxValue);
            ClampAll();
        }

        public int R {
            get => _red;
            set {
                _red = value;
                ClampAll();
            }
        }
        public int G {
            get => _green;
            set {
                _green = value;
                ClampAll();
            }
        }
        public int B {
            get => _blue;
            set {
                _blue = value;
                ClampAll();
            }
        }
        public int A {
            get => _alpha;
            set {
                _alpha = value;
                ClampAll();
            }
        }
        public string Hex => $"{this}";

        public static implicit operator (float Red, float Green, float Blue)(CelestialChromacity chroma) => (chroma.R/ColorChannelMaxValue, chroma.G/ColorChannelMaxValue, chroma.B/ColorChannelMaxValue);
        public static implicit operator CelestialChromacity((float Red, float Green, float Blue) tuple) => new CelestialChromacity(tuple.Red * ColorChannelMaxValue, tuple.Green * ColorChannelMaxValue, tuple.Blue * ColorChannelMaxValue);
        public static implicit operator CelestialChromacity((int Red, int Green, int Blue) tuple) => new CelestialChromacity(tuple.Red, tuple.Green, tuple.Blue);

        public static CelestialChromacity operator *(float a, CelestialChromacity b) => new CelestialChromacity(b.R * a, b.G * a, b.B * a, b.A * a);
        public static CelestialChromacity operator /(float a, CelestialChromacity b) => new CelestialChromacity(b.R / a, b.G / a, b.B / a, b.A / a);
        public static CelestialChromacity operator +(CelestialChromacity a, CelestialChromacity b) => new CelestialChromacity(b.R + a.R, b.G + a.G, b.B + a.G, b.A + a.A);
        public static CelestialChromacity operator -(CelestialChromacity a, CelestialChromacity b) => new CelestialChromacity(b.R - a.R, b.G - a.G, b.B - a.G, b.A - a.A);

        public override int GetHashCode()
        {
            return (_red, _green, _blue, _alpha).GetHashCode();
        }

        public override string ToString()
        {
            return $"#{_red:X2}{_green:X2}{_blue:X2}{_alpha:X2}";
        }

        private void ClampAll() {
            if (R < 0) R = 0;
            if (G < 0) G = 0;
            if (B < 0) B = 0;
            if (A < 0) A = 0;
            if (R > 255) R = 255;
            if (G > 255) G = 255;
            if (B > 255) B = 255;
            if (A > 255) A = 255;
        }
    }
}
