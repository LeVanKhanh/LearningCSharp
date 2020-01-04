using Principes.Dependency_Inversion.Correct;
using Principes.Interface_Segregation.Correct;
using Principes.Liskov_Substitution.Correct;
using Principes.Liskov_Substitution.Incorrect;
using System;

namespace Principes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lsp_Incorrect_Test test = new Lsp_Incorrect_Test();
            //test.Test();

            Isp_Correct_Test test = new Isp_Correct_Test();
            test.Test();

        }
    }
}
