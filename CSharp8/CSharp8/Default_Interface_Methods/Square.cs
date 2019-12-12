namespace CSharp8.Default_Interface_Methods
{
    public class Square : Rectangle
    {
        public Square(decimal width) : base(width, width)
        {
        }

        public bool HasColor()
        {
            return (this as IShape).HasColor();
        }
    }
}
