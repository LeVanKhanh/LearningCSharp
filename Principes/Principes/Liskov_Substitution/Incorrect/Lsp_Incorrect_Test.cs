using System;

namespace Principes.Liskov_Substitution.Incorrect
{
    public class Lsp_Incorrect_Test : ITest
    {
        public void Test()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 3;
            rectangle.Height = 4;

            //Rectangle class couldn't replaced by class Square
            //We set Width = 3; Height = 4
            //But Area = 0
            Rectangle square = new Square();
            square.Width = 3;
            square.Height = 4;

            Console.WriteLine("Total Rectangle Area: " + Calculator.Area(rectangle, square));
        }
    }
}
