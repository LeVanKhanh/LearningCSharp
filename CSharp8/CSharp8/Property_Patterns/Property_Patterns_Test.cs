using System;

namespace CSharp8.Property_Patterns
{
    public class Property_Patterns_Test : ITest
    {
        public void Exec()
        {
            Console.Write(Tax.ComputeSalesTax(new Address { State = "MI" }, 0.5M));
        }
    }
}
