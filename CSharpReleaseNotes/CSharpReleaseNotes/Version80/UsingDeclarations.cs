using System;

namespace CSharpReleaseNotes.Version80
{
    internal class Disposable : IDisposable
    {
        public void Dispose()
        {
        }
    }

    internal class UsingDeclarations
    {
        public static void Sample()
        {
            using var disposable = new Disposable();

            var sum = 0;
            for (var i = 0; i < 5; i++)
            {
                sum += i;
            }

            // here disposable is disposed
        }
    }
}
