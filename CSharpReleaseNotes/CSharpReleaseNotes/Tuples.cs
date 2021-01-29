namespace CSharpReleaseNotes
{
    internal class Tuples
    {
        public static (bool Success, int Result) CalculateMethod(int data)
        {
            if (data <= 0)
            {
                return (false, 0);
            }

            return (true, data * 2);
        }
    }
}
