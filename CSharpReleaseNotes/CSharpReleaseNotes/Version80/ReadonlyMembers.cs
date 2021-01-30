using System;

namespace CSharpReleaseNotes.Version80
{
    // You can apply the readonly modifier to members of a struct. It indicates that the member doesn't modify state.
    internal struct Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        // This method does not modify struct state, so it can be marked as readonly
        public readonly double Distance => Math.Sqrt(X * X + Y * Y);
    }

    internal class ReadonlyMembers
    {
        public static void Sample()
        {
        }
    }
}
