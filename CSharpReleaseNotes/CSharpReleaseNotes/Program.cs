using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpReleaseNotes.Version70_73;
using CSharpReleaseNotes.Version80;

namespace CSharpReleaseNotes
{
    internal class Program
    {
        internal class Base
        {
        }

        internal class Derived : Base
        {
        }

        private static async Task Main(string[] args)
        {
            // C# 7.0 - 7.3 
            TuplesAndDiscards.Sample();

            GenericConstraints.Sample();

            // C# 8.0
            ReadonlyMembers.Sample();
            SwitchExpressions.Sample();
            PropertyPatterns.Sample();
            TuplePatterns.Sample();
            PositionalPatterns.Sample();
            UsingDeclarations.Sample();
            new StaticLocalFunctions().Sample1();
            new StaticLocalFunctions().Sample2();
            DisposableRefStructs.Sample();
            await AsynchronousStreams.Sample();
            await AsynchronousDisposable.Sample();
            IndicesAndRanges.Sample();
            NullCoalescing.Sample();
            UnmanagedConstructedTypes.Sample();
            StackallocInNestedExpressions.Sample();
        }

        private static void ReturnRefSample()
        {
            var store = new NumberStore();
            Console.WriteLine(store.ToString());

            // здесь значение будет скопировано
            var value1 = store.FindValue(2, 2, 2);
            value1.A += 1; // поэтому эта строка не повлияет на массив значений в классе.
            Console.WriteLine(store.ToString());

            // А вот здесь будет передано значение структуры по ссылке!
            ref var value2 = ref store.FindValue(2, 2, 2);
            value2.A += 1; // поэтому это повлияет на массив значений в классе.
            Console.WriteLine(store.ToString());
        }

        private static void CovarianceAndContrvarianceSample()
        {
            // Covariant
            IEnumerable<Derived> derivedEnumerable = new List<Derived>();
            IEnumerable<Base> baseEnumerable = derivedEnumerable;

            // Contravariance
            Action<Base> baseAction = @base => Console.WriteLine(@base);
            Action<Derived> derivedAction = baseAction;
            derivedAction(new Derived());

            Func<Base, Base> baseBaseFunc = @base => @base;
            Func<Base, Derived> baseDerivedFunc = _ => new Derived();

            Func<Derived, Base> derivedFunc1 = baseBaseFunc;
            Func<Derived, Base> derivedFunc2 = baseDerivedFunc;
            Func<Derived, Derived> derivedFunc3 = baseDerivedFunc;
        }
    }
}
