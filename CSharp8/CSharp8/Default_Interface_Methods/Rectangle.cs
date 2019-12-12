using System.Drawing;

namespace CSharp8.Default_Interface_Methods
{
    public class Rectangle : IPolygon, IDrawing
    {
        private readonly decimal _width;
        private readonly decimal _length;

        public Rectangle(decimal width, decimal length)
        {
            NumberOfSide = 4;
            _width = width;
            _length = length;
        }
        public int NumberOfSide { get; set; }
        public Color MyColor { get; set; }
        public Color BorderColor { get; set; }
        public decimal Area()
        {
            return _width * _length;
        }
    }
}
