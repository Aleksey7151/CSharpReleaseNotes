using System;

namespace CSharpReleaseNotes.Version80
{
    // in C# 7.3 this type is not unmanaged
    // in C# 8.0 this type is unmanaged
    internal struct Coords<T>
    {
        public T X;
        public T Y;
    }

    internal class UnmanagedConstructedTypes
    {
        public static void Sample()
        {
            // For any unmanaged type, you can create pointer to variable of this type or allocate a block memory on the STACK
            Span<Coords<int>> coordinates = stackalloc[]
            {
                new Coords<int> {X = 0, Y = 0},
                new Coords<int> {X = 1, Y = 1},
            };
        }
    }
}
