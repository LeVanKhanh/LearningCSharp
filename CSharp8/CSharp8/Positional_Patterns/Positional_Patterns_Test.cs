using System;

namespace CSharp8.Positional_Patterns
{
    public class Positional_Patterns_Test : ITest
    {
        public void Exec()
        {
            // Origin
            Console.WriteLine(Positional_Quadrant.GetQuadrant(new Point(0, 0)));
            // One
            Console.WriteLine(Positional_Quadrant.GetQuadrant(new Point(1, 1)));
            // Two
            Console.WriteLine(Positional_Quadrant.GetQuadrant(new Point(-1, 1)));
            // Three
            Console.WriteLine(Positional_Quadrant.GetQuadrant(new Point(1, -1)));
            // Four
            Console.WriteLine(Positional_Quadrant.GetQuadrant(new Point(-1, -1)));
        }
    }
}
