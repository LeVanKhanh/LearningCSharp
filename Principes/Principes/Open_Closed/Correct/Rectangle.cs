namespace Principes.Open_Closed.Correct
{
    /// <summary>
    /// Derived class extend class 'Shape'
    /// </summary>
    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public override double Area()
        {
            return Height * Width;
        }
    }
}
