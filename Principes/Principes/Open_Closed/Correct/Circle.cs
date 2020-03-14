using System;

namespace Principes.Open_Closed.Correct
{
    /// <summary>
    /// Derived class extend class 'Shape'
    /// </summary>
    public class Circle: Shape
    {
        public double Radius { get; set; }

        public override double Area()
        {
            return Radius * Radius * Math.PI;
        }
    }
}
