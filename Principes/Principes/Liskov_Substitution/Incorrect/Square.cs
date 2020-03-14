namespace Principes.Liskov_Substitution.Incorrect
{
    public class Square : Rectangle
    {
        public double Side { get; set; }
        public override double Area()
        {
            return Side * Side;
        }
    }
}
