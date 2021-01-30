using System;

namespace CSharpReleaseNotes.Version80
{
    internal class StackallocInNestedExpressions
    {
        public static void Sample()
        {
            Span<int> numbers = stackalloc[] {1, 2, 3, 4, 5, 6};
            var index = numbers.IndexOfAny(stackalloc[] {2, 4, 6, 8});
            Console.WriteLine(index);
        }
    }
}
