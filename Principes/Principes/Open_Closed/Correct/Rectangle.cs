namespace Principes.Open_Closed.Correct
{
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
