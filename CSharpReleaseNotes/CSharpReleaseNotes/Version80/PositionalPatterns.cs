using System;

namespace CSharpReleaseNotes.Version80
{
    internal class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) => (X, Y) = (x, y);

        public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
    }

    internal enum Quadrant
    {
        Unknown,
        Origin,
        One,
        Two,
        Three,
        Four,
        OnBorder
    }

    internal class PositionalPatterns
    {
        public static void Sample()
        {
            Console.WriteLine(GetQuadrant(new Point(3, 2)));
        }

        private static Quadrant GetQuadrant(Point point)
        {
            var quadrant = point switch
            {
                (0, 0) => Quadrant.Origin,
                var (x, y) when x > 0 && y > 0 => Quadrant.One,
                var (x, y) when x < 0 && y > 0 => Quadrant.Two,
                var (x, y) when x < 0 && y < 0 => Quadrant.Three,
                var (x, y) when x > 0 && y < 0 => Quadrant.Four,
                var (_, _) => Quadrant.OnBorder,
                _ => Quadrant.Unknown,
            };

            return quadrant;
        }
    }
}
