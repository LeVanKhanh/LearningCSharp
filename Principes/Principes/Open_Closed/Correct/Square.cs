namespace Principes.Open_Closed.Correct
{
    public class Square : Shape
    {
        public int Sides;

        public override int Area()
        {
            return Sides * Sides;
        }
    }
}
