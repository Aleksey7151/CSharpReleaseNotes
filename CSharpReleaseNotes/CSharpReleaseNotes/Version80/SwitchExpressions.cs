using System;

namespace CSharpReleaseNotes.Version80
{
    internal enum Rainbow
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    internal class SwitchExpressions
    {
        public static void Sample()
        {
            Console.WriteLine(GetColorName(Rainbow.Blue));
        }

        private static string GetColorName(Rainbow rainbow)
        {
            return rainbow switch
            {
                Rainbow.Blue => "Blue",
                Rainbow.Green => "Green",
                _ => throw new ArgumentException(nameof(rainbow))
            };
        }
    }
}
