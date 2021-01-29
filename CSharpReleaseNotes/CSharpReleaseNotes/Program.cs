using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpReleaseNotes.Version70_73;

namespace CSharpReleaseNotes
{
    internal class Program
    {
        internal class Base
        {

        }

        internal class Derived : Base
        {
            public async ValueTask<int> Method()
            {
                await Task.Delay(300);

                return 5;
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void GenericConstraintSample()
        {
            var map = GenericConstraints.EnumNamedValues<Rainbow>();
            foreach (var pair in map)
            {
                Console.WriteLine($"{pair.Key}:\t{pair.Value}");
            }

            Action source = () => Console.WriteLine("source");
            Action target = () => Console.WriteLine("target");
            var combined = source.CombineSafe(target);
            combined();

            GenericConstraints.DisplaySize<Coordinates<int>>();
            GenericConstraints.DisplaySize<Coordinates<double>>();
        }

        private static void TuplesSample()
        {
            var methodResult = Tuples.CalculateMethod(3);
            if (methodResult.Success)
            {
                Console.WriteLine(methodResult.Result);
            }
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
