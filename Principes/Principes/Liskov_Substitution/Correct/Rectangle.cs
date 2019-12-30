namespace Principes.Liskov_Substitution.Correct
{
    public class Rectangle: Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public override int Area()
        {
            return Height * Width;
        }
    }
}
