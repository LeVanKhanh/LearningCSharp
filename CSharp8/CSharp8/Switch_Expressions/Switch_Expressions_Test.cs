using System;

namespace CSharp8.Switch_Expressions
{
    public class Switch_Expressions_Test : ITest
    {
        public void Exec()
        {
            var result = SwitchExpressionsExample.FromRainbow(Rainbow.Orange);
            Console.WriteLine(result);
        }
    }
}
