using System;

namespace CSharp8
{
    class Program
    {
        static void Main(string[] args)
        {
            //ITest test = new Default_Interface_Methods.Default_Interface_Methods_Test();
            ITest test = new Readonly_Members.Readonly_Members_Test();
            test.Exec();
            Console.ReadLine();
        }
    }
}
