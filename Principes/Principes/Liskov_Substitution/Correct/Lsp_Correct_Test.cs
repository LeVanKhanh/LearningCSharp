using System;

namespace Principes.Liskov_Substitution.Correct
{
    public class Lsp_Correct_Test
    {
        public void Test()
        {
            Shape square = new Square { Sides = 5 };
            Shape rectangle = new Rectangle { Width = 10, Height = 5 };

            Console.WriteLine("Square Area {0}", square.Area());
            Console.WriteLine("Rectangle Area {0}", rectangle.Area());
        }
    }
}
