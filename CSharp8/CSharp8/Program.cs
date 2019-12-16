using System;

namespace CSharp8
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Do you want to continue(y)?");
                var yes = Console.ReadLine();
                if (!string.Equals("y", yes, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                Console.WriteLine("Test Available:");
                Console.WriteLine(TestName.DEFAULT_INTERFACE_METHODS);
                Console.WriteLine(TestName.READONLY_MEMBERS);
                Console.WriteLine(TestName.SWITCH_EXPRESSIONS);
                Console.WriteLine(TestName.PROPERTY_PATTERNS);
                Console.WriteLine(TestName.TUPLE_PATTERNS);
                Console.WriteLine(TestName.USING_DECLARATIONS);
                Console.WriteLine("Please enter test Name");
                var testName = Console.ReadLine();
                var testFactory = new TestFactory();
                ITest test = testFactory.GetTest(testName);
                test.Exec();
            }
        }
    }
}
