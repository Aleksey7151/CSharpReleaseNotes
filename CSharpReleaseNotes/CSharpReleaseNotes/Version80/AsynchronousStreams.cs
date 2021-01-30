using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpReleaseNotes.Version80
{
    internal class AsynchronousStreams
    {
        public static async Task Sample()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }
        }

        private static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (var number = 1; number <= 20; number++)
            {
                await Task.Delay(500);
                yield return number;
            }
        }
    }
}
