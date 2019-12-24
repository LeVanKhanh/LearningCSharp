using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp8.Static_Local_Functions
{
    public class LocalFunction
    {
        public int M1()
        {
            int y;
            LocalFunction();
            return y;
            //The local function LocalFunction accesses the variable y, declared in the enclosing scope (the method M). 
            //Therefore, LocalFunction can't be declared with the static modifier
            void LocalFunction() => y = 0;
        }

        public double Power(double power)
        {
            double y = Math.Pow(2, power);
            double x = Math.Pow(3, power);

            return Add(x, y);

            static double Add(double left, double right) => left + right;
        }
    }
}
