using System;
using System.Collections.Generic;

namespace CSharpReleaseNotes.Version70_73
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

    internal struct Coordinates<T> where T : unmanaged
    {
        public T X;
        public T Y;
    }

    internal static class GenericConstraints
    {
        public static void Sample()
        {
            var map = EnumNamedValues<Rainbow>();
            foreach (var pair in map)
            {
                Console.WriteLine($"{pair.Key}:\t{pair.Value}");
            }

            Action source = () => Console.WriteLine("source");
            Action target = () => Console.WriteLine("target");
            var combined = source.CombineSafe(target);
            combined();

            DisplaySize<Coordinates<int>>();
            DisplaySize<Coordinates<double>>();
        }

        private static unsafe void DisplaySize<T>() where T : unmanaged
        {
            Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
        }

        private static TDelegate CombineSafe<TDelegate>(this TDelegate source, TDelegate target)
            where TDelegate : Delegate
        {
            return Delegate.Combine(source, target) as TDelegate;
        }

        private static Dictionary<int, string> EnumNamedValues<T>() where T : Enum
        {
            var result = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
            {
                result.Add(item, Enum.GetName(typeof(T), item));
            }

            return result;
        }
    }
}
