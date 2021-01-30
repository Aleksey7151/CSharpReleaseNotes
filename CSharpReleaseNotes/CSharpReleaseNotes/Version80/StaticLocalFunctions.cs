using System;

namespace CSharpReleaseNotes.Version80
{
    internal class StaticLocalFunctions
    {
        public void Sample1()
        {
            int y;
            LocalFunction();
            Console.WriteLine(y);

            // this is simple local function
            void LocalFunction()
            {
                y = 7;  // local function captures variable y, declared in enclosing scope
            }
        }

        public void Sample2()
        {
            var x = 5;
            var y = 7;
            Console.WriteLine(LocalFunction(x, y));

            // static functions can not access any variables from the enclosing scope
            static int LocalFunction(int a, int b) => a + b;
        }
    }
}
