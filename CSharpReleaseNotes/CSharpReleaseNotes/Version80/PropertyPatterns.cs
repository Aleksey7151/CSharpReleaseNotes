using System;

namespace CSharpReleaseNotes.Version80
{
    internal class Address
    {
        public string State { get; set; }
    }

    internal class PropertyPatterns
    {
        public static void Sample()
        {
            Console.WriteLine(ComputeSalesTax(new Address(){State = "MN"}, 5M));
        }

        private static decimal ComputeSalesTax(Address address, decimal salePrice)
        {
            return address switch
            {
                { State: "WA" } => salePrice * 0.06M,
                { State: "MN" } => salePrice * 0.075M,
                // ...
                _ => 0M,
            };
        }
    }
}
