using System;
using System.Collections.Generic;

namespace CSharpReleaseNotes.Version80
{
    internal class IndicesAndRanges
    {
        // Index from the end operator: ^
        // sequence[^0] - throws an exception, because it is the same as sequence[sequence.Length]
        // ^n --> sequence.Length - n
        private static readonly string[] Words = 
        {
            // index from start    index from end
            "The",      // 0                   ^9
            "quick",    // 1                   ^8
            "brown",    // 2                   ^7
            "fox",      // 3                   ^6
            "jumped",   // 4                   ^5
            "over",     // 5                   ^4
            "the",      // 6                   ^3
            "lazy",     // 7                   ^2
            "dog"       // 8                   ^1
        };

        public static void Sample()
        {
            Console.WriteLine(Words[^1]);

            var quickBrownFox = Words[1..4];    // it includes 1, 2, 3 from Words: quick, brown, fox
            Print(quickBrownFox);

            var lazyDog = Words[^2..^0];        // it includes (Length - 2), (Length - 1) elements from Words. (Length - 0) is not included.
            Print(lazyDog);

            var allWords = Words[..]; // contains all sequence elements from Words.
            Print(allWords);

            var firstElements = Words[..4]; // contains first 3 elements from Words
            Print(firstElements);

            var lastElements = Words[6..]; // contains last elements starting from element at index 6
            Print(lastElements);

            // now it is possible to declare ranges variables
            Range range = 1..5;
            var text = Words[range];
            Print(text);
        }

        private static void Print<T>(IEnumerable<T> elements)
        {
            foreach (var element in elements)
            {
                Console.Write(element + " ");
            }
        }
    }
}
