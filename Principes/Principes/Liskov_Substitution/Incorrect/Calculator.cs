﻿namespace Principes.Liskov_Substitution.Incorrect
{
    /// <summary>
    /// Calculate Area
    /// </summary>
    public static class Calculator
    {
        public static double Area(params Rectangle[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.Area();
            }
            return area;
        }
    }
}
