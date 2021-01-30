using System;

namespace CSharpReleaseNotes.Version80
{
    internal class TuplePatterns
    {
        public static void Sample()
        {
            Console.WriteLine(RockPaperScissors("rock", "scissors"));
        }

        private static string RockPaperScissors(string first, string second)
        {
            return (first, second) switch
            {
                ("rock", "paper") => "rock is covered by paper. Paper wins.",
                ("rock", "scissors") => "rock breaks scissors. Rock wins.",
                (_, _) => "tie",
            };
        }
    }
}
