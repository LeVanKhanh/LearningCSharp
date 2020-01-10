using System;

namespace Principes.Liskov_Substitution.Incorrect
{
    public class Lsp_Incorrect_Test : ITest
    {
        public void Test()
        {
            Rectangle rectangle = new Square();
            rectangle.Width = 10;
            rectangle.Height = 5;

            // Expected 10*5 = 50;
            // Result is 5 * 5 = 25;
            Console.WriteLine(Calculator.Area(rectangle));
        }
    }
}
