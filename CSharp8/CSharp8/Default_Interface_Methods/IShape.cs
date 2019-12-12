using System.Drawing;

namespace CSharp8.Default_Interface_Methods
{
    public interface IShape
    {
        //Method Require to Implement
        decimal Area();
        Color MyColor { get; set; }
        Color BorderColor { get; set; }
        //Optional to implement
        bool HasColor()
        {
            return MyColor != null || BorderColor != null;
        }
    }
}
