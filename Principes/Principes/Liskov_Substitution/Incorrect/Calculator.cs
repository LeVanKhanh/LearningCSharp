namespace Principes.Liskov_Substitution.Incorrect
{
    public static class Calculator
    {
        public static int Area(Rectangle rectangle)
        {
            return rectangle.Height * rectangle.Width;
        }

        public static int Area(Square square)
        {
            return square.Height * square.Height;
        }
    }
}
