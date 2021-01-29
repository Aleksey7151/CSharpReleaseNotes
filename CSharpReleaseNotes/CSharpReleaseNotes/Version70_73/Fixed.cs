namespace CSharpReleaseNotes.Version70_73
{
    internal unsafe struct Struct
    {
        public fixed int FixedFiled[10];
    }

    internal class Fixed
    {
        private readonly Struct _struct = new Struct();

        // in C# 7.3 we can write like this:
        public unsafe void MethodUsingCSharp73()
        {
            int p = _struct.FixedFiled[5];
        }

        public unsafe void MethodUsingBefore73()
        {
            fixed (int* ptr = _struct.FixedFiled)
            {
                int p = ptr[5];
            }
        }
    }
}
