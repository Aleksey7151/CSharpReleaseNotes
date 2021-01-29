namespace CSharpReleaseNotes
{
    internal struct Value
    {
        public int A;
        public int B;
        public int C;

        public override readonly string ToString()
        {
            return $"({A}, {B}, {C})";
        }
    }

    internal class NumberStore
    {
        public readonly Value[] Values =
        {
            new Value {A = 1, B = 1, C = 1}, new Value {A = 2, B = 2, C = 2}, new Value {A = 3, B = 3, C = 3},
        };

        public ref Value FindValue(int a, int b, int c)
        {
            for (var index = 0; index < Values.Length; index++)
            {
                if (Values[index].A == a && Values[index].B == b && Values[index].C == c)
                {
                    return ref Values[index];
                }
            }

            return ref Values[0];
        }

        public ref Value FindValue(int abc)
        {
            ref var @return = ref Values[0];
            var index = Values.Length - 1;

            while (index >= 0 && Values[index].A != abc)
            {
                @return = ref Values[index];    // можно переназначать.
                index--;
            }

            return ref @return;
        }

        public override string ToString() => string.Join(" ", Values);
    }
}
