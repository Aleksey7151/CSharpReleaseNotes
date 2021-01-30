using System;
using System.Collections.Generic;

namespace CSharpReleaseNotes.Version80
{
    internal class NullCoalescing
    {
        public static void Sample()
        {
            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>(); // if numbers == NULL, than it will be assigned with ( new List<int>() )
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine(i);
        }
    }
}
