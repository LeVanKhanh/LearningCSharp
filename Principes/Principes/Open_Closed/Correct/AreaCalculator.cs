namespace Principes.Open_Closed.Correct
{
    /// <summary>
    /// Calculate Area
    /// </summary>
    public class AreaCalculator
    {
        /// <summary>
        /// Sum Area of shapes.
        /// With this code if we add more type of Shape, we haven't to modify it.
        /// Just add more derived class extend class 'Shape'
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns></returns>
        public double Area(params Shape[] shapes)
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
