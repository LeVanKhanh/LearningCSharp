namespace Principes.Liskov_Substitution.Correct
{
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side)
        {

        }

        public double Side { get; private set; }
    }
}
