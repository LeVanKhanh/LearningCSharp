using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8.Static_Local_Functions
{
    public class Static_Local_Functions_Test : ITest
    {
        public void Exec()
        {
            var localFunction = new LocalFunction();
            // 2 + 3 = 5
            Console.WriteLine(localFunction.Power(1));
            // 2^2 + 3^2 = 13
            Console.WriteLine(localFunction.Power(2));
        }
    }
}
