using System;
using System.Collections.Generic;

namespace CSharp8.Readonly_Members
{
    public class Readonly_Members_Test : ITest
    {
        public void Exec()
        {
            var structExample = new StructExample
            {
                _store = new Dictionary<string, int>
                {
                    { "Prop1", 1 },
                    { "Prop2", 2 },
                    { "Prop3", 3 }
                },

                Prop6 = 8,
                Counter = 9 //not useful
            };

            structExample.Prop2 = 5;
            structExample.Prop3 = 6;

            Console.WriteLine($"Prop2 {structExample.Prop2}");
            Console.WriteLine($"Prop3 {structExample.Prop3}");
            Console.WriteLine($"Prop4 {structExample.Prop4}");
            Console.WriteLine($"Counter {structExample.Counter}");
        }
    }
}
