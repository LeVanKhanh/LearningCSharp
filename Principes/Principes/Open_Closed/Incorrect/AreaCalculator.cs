using System;

namespace Principes.Open_Closed.Incorrect
{
    /// <summary>
    /// Calculate Area
    /// </summary>
    public class AreaCalculator
    {
        /// <summary>
        /// Sum Area of shapes
        /// With this code, if we add more type of shape we have to modify it(add more conditions).
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns></returns>
        public double Area(object[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                if (shape is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)shape;
                    area += rectangle.Width * rectangle.Height;
                }
                else
                {
                    Circle circle = (Circle)shape;
                    area += circle.Radius * circle.Radius * Math.PI;
                }
            }

            return area;
        }
    }
}
