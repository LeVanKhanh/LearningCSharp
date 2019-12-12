using System.Drawing;

namespace CSharp8.Default_Interface_Methods
{
    public interface I2DShape : IShape
    {
        #region overrides are not permitted
        // explicitly named
        //override bool IShape.HasColor()
        //{
        //    return true;
        //}

        // implicitly named
        //override bool HasColor()
        //{
        //    return true;
        //}
        #endregion
    }
}
