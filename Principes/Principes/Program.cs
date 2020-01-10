using Principes.Interface_Segregation.Correct;

namespace Principes
{
    class Program
    {
        static void Main()
        {
            ITest test = new Isp_Correct_Test();
            test.Test();
        }
    }
}
