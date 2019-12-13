using System;
using System.Drawing;

namespace CSharp8.Switch_Expressions
{
    public class SwitchExpressionsExample
    {
        public static Color FromRainbow(Rainbow colorBand) => colorBand switch
        {
            Rainbow.Red => Color.Red,
            Rainbow.Orange => Color.Orange,
            Rainbow.Yellow => Color.Yellow,
            Rainbow.Green => Color.Green,
            Rainbow.Blue => Color.Blue,
            Rainbow.Indigo => Color.Indigo,
            Rainbow.Violet => Color.Violet,
            _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
        };
    }
}
