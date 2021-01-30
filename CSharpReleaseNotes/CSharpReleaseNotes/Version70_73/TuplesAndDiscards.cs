using System;
using System.Security.Cryptography.X509Certificates;

namespace CSharpReleaseNotes.Version70_73
{
    internal class TuplesAndDiscards
    {
        public class Point
        {
            public Point(double x, double y)
                => (X, Y) = (x, y);

            public double X { get; }
            public double Y { get; }

            public void Deconstruct(out double x, out double y) =>
                (x, y) = (X, Y);
        }

        public static void Sample()
        {
            (string Alpha, string Beta) namedLetters = ("a", "b");
            Console.WriteLine($"{namedLetters.Alpha}, {namedLetters.Beta}");

            var alphabetStart = (Alpha: "a", Beta: "b");
            Console.WriteLine($"{alphabetStart.Alpha}, {alphabetStart.Beta}");

            var methodResult = CalculateMethod(3);
            if (methodResult.Success)
            {
                Console.WriteLine(methodResult.Result);
            }

            var point = new Point(4, 5);
            (double x, double y) = point;

            int count = 5;
            string label = "Colors used in the map";
            var pair = (count, label); // element names are "count" and "label"
        }

        private static (bool Success, int Result) CalculateMethod(int data)
        {
            if (data <= 0)
            {
                return (false, 0);
            }

            return (true, data * 2);
        }
    }
}
