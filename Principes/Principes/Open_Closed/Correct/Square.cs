﻿namespace Principes.Open_Closed.Correct
{
    /// <summary>
    /// Derived class extend class 'Shape'
    /// </summary>
    public class Square : Shape
    {
        public int Sides;

        public override double Area()
        {
            return Sides * Sides;
        }
    }
}
