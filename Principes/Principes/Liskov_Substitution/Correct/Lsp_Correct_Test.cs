using System;

namespace Principes.Liskov_Substitution.Correct
{
    public class Lsp_Correct_Test: ITest
    {
        public void Test()
        {
            Rectangle rectangle = new Rectangle(3, 4);
            Rectangle square = new Square(4);

            Console.WriteLine("Total Rectangle Area: " + Calculator.Area(rectangle, square));
        }
    }
}
