namespace Principes.Liskov_Substitution.Correct
{
    public class Square: Shape
    {
        public int Sides;

        public override int Area()
        {
            return Sides * Sides;
        }
    }
}
