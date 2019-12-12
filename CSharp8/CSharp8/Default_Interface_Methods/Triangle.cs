using System.Drawing;

namespace CSharp8.Default_Interface_Methods
{
    public class Triangle : IPolygon
    {
        public Triangle()
        {
            NumberOfSide = 3;
        }

        public int NumberOfSide { get; set; }
        public Color BorderColor { get; set; }
        public Color MyColor { get; set; }

        public decimal Area()
        {
            throw new System.NotImplementedException();
        }
    }
}
