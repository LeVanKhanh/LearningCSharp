using System;
using System.Drawing;

namespace CSharp8.Default_Interface_Methods
{
    public class Default_Interface_Methods_Test : ITest
    {
        public void Exec()
        {
            IShape rectangle1 = new Rectangle(3, 5);
            rectangle1.BorderColor = Color.Black;
            Console.WriteLine($"IShape_rectangle HasColor: {rectangle1.HasColor()}");

            IDrawing rectangle2 = new Rectangle(3, 5);
            //rectangle2.BorderColor = Color.Black; // IDrawing hasn't property BorderColor
            Console.WriteLine($"IDrawing_rectangle HasColor: {rectangle2.HasColor()}");

            var rectangle3 = new Rectangle(3, 5);
            rectangle3.BorderColor = Color.Black;
            // Direct instance Rectangle hasn't method HasColor()
            //Console.WriteLine($"IDrawing HasColor: {0}", rectangle3.HasColor());

            var square = new Square(3);
            square.BorderColor = Color.Black;
            //square re-define HasColor()
            Console.WriteLine($"Instance_square HasColor: {square.HasColor()}");
        }
    }
}
