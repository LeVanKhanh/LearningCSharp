namespace Principes.Liskov_Substitution.Incorrect
{
    public class Rectangle
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public virtual double Area()
        {
            return Height * Width;
        }
    }
}
