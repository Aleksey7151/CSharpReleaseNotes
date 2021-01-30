using System;

namespace CSharpReleaseNotes.Version80
{
    // ref structs are always located on stack, that is why they can not implement interfaces and have many other limitations.
    internal ref struct Struct
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose ref struct");
        }
    }

    internal class DisposableRefStructs
    {
        public static void Sample()
        {
            using var @struct = new Struct();
            Console.WriteLine("Inside using Ref Struct");
        }
    }
}
