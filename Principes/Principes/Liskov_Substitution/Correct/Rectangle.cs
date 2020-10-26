namespace Principes.Liskov_Substitution.Correct
{
    public class Rectangle
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public double Height { get; private set; }
        public double Width { get; private set; }
        public double Area()
        {
            return Height * Width;
        }
    }
}
